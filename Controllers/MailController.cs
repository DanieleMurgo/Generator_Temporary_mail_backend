using Microsoft.AspNetCore.Mvc;
using SmorcIRL.TempMail;
using SmorcIRL.TempMail.Models;
using Temp_Mail_API.Models;
using Temp_Mail_Project.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Temp_mail_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {

        private readonly IMailServices _iMailServices;

        public MailController(IMailServices iMailServices)
        {
            _iMailServices = iMailServices;
        }


        [HttpGet ("getDomains")]
        public Task<string> GetDomainsAsync()
        {

            return _iMailServices.GetDomainsAsync();
        }


        // POST api/<MailController>
        [HttpPost("newAccount")]
        public Task<string> PostAccount([FromBody] MailAccount mailAccount)
        {
            return _iMailServices.CreateUserAsync(mailAccount.Username, mailAccount.Password);
        }

        // DELETE api/<MailController>/5
        [HttpDelete("account")]
        public void Delete(string email, string password)
        {
            _iMailServices.DeleteAccountAsync(email, password);
        }


        // GET: api/<MailController>
        [HttpGet("allMessages")]
        public Task<string> GetMessages(string email, string password)
        {
            return _iMailServices.RetrieveMessages(email, password);
        }

        // GET api/<MailController>/5
        [HttpGet("message/{id}")]
        public Task<string> GetMessage(string email, string password, string id)
        {
            return _iMailServices.RetrieveSingleMessage(email, password, id);
        }


        // DELETE api/<MailController>/5
        [HttpDelete("message/{id}")]
        public void DeleteMessage(string email, string password, string id)
        {
            _iMailServices.DeleteSingleMessage(email, password, id);
        }


        // PUT api/<MailController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

    }
}
