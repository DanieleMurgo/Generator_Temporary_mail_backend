using SmorcIRL.TempMail;
using SmorcIRL.TempMail.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using Temp_mail_API;
using Temp_mail_API.Models;
using Temp_Mail_API.Models;

namespace Temp_Mail_Project.Services


{
    public class MailServices : IMailServices
    {

        //mail.tm is a great temporary/disposable mail service, and also recently was launched a new 10 minute mail service called mail.gw
        private readonly MailClient client = new MailClient(new Uri("https://api.mail.tm/"));

        public async Task<string> CreateUserAsync(string username, string password)
        {
            Console.WriteLine($"Avviato funzione async");
            //Retrieve list of available domains
            //DomainInfo[] domains = await client.GetAvailableDomains();


            try
            {
            //Get first available domain
            string domain = await client.GetFirstAvailableDomainName();
            Console.WriteLine($"Terminata verifica primo dominio disponibile: {domain}");


            //Register User
            await client.Register(username, domain, password);

            Console.WriteLine($"Nuovo account creato: {username}@{domain}");


            //Create user json solo con info necessarie
            MailAccount mailAccount = new MailAccount(username, password, domain);
            string jsonString = JsonSerializer.Serialize(mailAccount);

            return jsonString;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }


        public async Task DeleteAccountAsync(string email, string password)
        {
            try
            {

            await client.Login(email, password);
            await client.DeleteAccount();
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        public async Task<string> RetrieveMessages (string email, string password)
        {
            //aggiornare con credenziali da importare dal frontend

            try
            {

            await client.Login(email, password);

            MessageInfo [] messages = await client.GetAllMessages();


            string jsonMessages = JsonSerializer.Serialize(messages);

            return jsonMessages;

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<string> RetrieveSingleMessage (string email, string password, string id)
        {

            await client.Login(email, password);

            MessageInfo message = await client.GetMessage(id);

            string jsonMessage = JsonSerializer.Serialize(message);

            return jsonMessage;

        }


        public async Task DeleteSingleMessage(string email, string password, string id)
        {
            await client.Login(email, password);

            await client.DeleteMessage(id);

            Console.WriteLine("Messaggio eliminato con successo");
        }

        public async Task<string> GetDomainsAsync()
        {
            DomainInfo[] domains = await client.GetAvailableDomains();

            string jsonDomains = JsonSerializer.Serialize(domains);

            return jsonDomains;
        }

    }
}
