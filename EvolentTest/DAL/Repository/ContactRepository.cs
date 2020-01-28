
using EvolentTest.Contract;
using EvolentTest.DAL.DBContext;
using EvolentTest.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolentTest.DAL.Repository
{
    class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {
        }

        public Contact GetContactById(int contactId)
        {
            return FindByCondition(contact => contact.ID.Equals(contactId))
               .FirstOrDefault();
        }


        public Contact GetContactByFirstAndLastName(string firstName, string lastName)
        {
            return  FindByCondition(contact => contact.FirstName.Equals(firstName)  && contact.LastName.Equals(lastName))
               .FirstOrDefault();            
        }

        public bool ContactAlreadyExist(string firstName, string lastName)
        {
            var contactFound = FindByCondition(contact => contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
               .FirstOrDefault();

            if (contactFound != null)
                return true;
            else
                return false;

        }       
                              
    }
}
