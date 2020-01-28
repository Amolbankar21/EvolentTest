using EvolentTest.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentTest.Contract
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        Contact GetContactById(int contactId);

        Contact GetContactByFirstAndLastName(string firstName, string lastName);

        bool ContactAlreadyExist(string firstName, string lastName);
    }
}
