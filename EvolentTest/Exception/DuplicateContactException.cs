using EvolentTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentTest.Exception
{
    public class DuplicateContactException : System.Exception
    {
        public DuplicateContactException()
        {

        }

        public DuplicateContactException(string firstName, string lastName)
            : base(String.Format(Constants.ContactAlreadtExist, firstName, lastName))
        {

        }
    }
}
