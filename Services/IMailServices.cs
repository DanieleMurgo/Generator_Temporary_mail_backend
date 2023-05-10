using SmorcIRL.TempMail.Models;

namespace Temp_Mail_Project.Services
{
    public interface IMailServices
    {

        Task<string> CreateUserAsync(string username, string password);

        Task DeleteAccountAsync(string email, string password);

        Task<string> RetrieveMessages(string email, string password);

        Task<string> RetrieveSingleMessage(string email, string password, string idEmail);

        Task<string> GetDomainsAsync();

        Task DeleteSingleMessage(string email, string password, string idEmail);
    }
}
