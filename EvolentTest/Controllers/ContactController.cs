using EvolentTest;
using EvolentTest.Contract;
using EvolentTest.DAL.Model;
using EvolentTest.Error;
using EvolentTest.Exception;
using EvolentTest.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvolentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        //private ILoggerManager _logger;
        private IRepositoryWrapper repository;
       
        public ContactController(IRepositoryWrapper repository)
        {            
            this.repository = repository;           
        }

        // GET api/Contact
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            List<Contact> contacts = repository.Contact.GetAll().ToList();

            if (contacts == null)
            {
                throw new ContactNotFoundException(Constants.NoContactFound);
            }

            return Ok(repository.Contact.GetAll());
        }

        [HttpPost]
        [Authorize]
        public void Post([FromBody] Contact contact)
        {            
            bool contactAlreadyExist = repository.Contact.ContactAlreadyExist(contact.FirstName, contact.LastName);
            if(!contactAlreadyExist)
            {
                repository.Contact.Create(contact);
                repository.Save();
                Ok(HttpStatusCode.Created);
            }
            else
            {
                throw new DuplicateContactException(contact.FirstName, contact.LastName);
            }                          
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] Contact contact)
        {            
            Contact orgContact = repository.Contact.GetContactById(id);

            if (orgContact != null)
            {
                orgContact.ID = id;
                orgContact.FirstName = contact.FirstName;
                orgContact.LastName = contact.LastName;
                orgContact.Email = contact.Email;
                orgContact.PhoneNumber = contact.PhoneNumber;
                orgContact.Status = contact.Status;

                bool contactAlreadyExist = repository.Contact.ContactAlreadyExist(orgContact.FirstName, orgContact.LastName);

                if (!contactAlreadyExist)
                {
                    repository.Contact.Update(orgContact);
                    repository.Save();
                    Ok(HttpStatusCode.Created);
                }
                else
                {
                    throw new DuplicateContactException(orgContact.FirstName, orgContact.LastName);
                }
            }
            else
            {
                throw new ContactNotFoundException(Constants.NoContactToUpdate);
            }            
        }

        // DELETE api/Contact/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {           
            Contact orgContact = repository.Contact.GetContactById(id);

            if (orgContact != null)
            {
                repository.Contact.Delete(orgContact);
                repository.Save();
                Ok(HttpStatusCode.Accepted);
            }
            else
            {
                throw new ContactNotFoundException(Constants.NoContactToDelete);               
            }            
        }
    }
}
