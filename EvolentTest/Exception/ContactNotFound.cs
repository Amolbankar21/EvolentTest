using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentTest.Exception
{
    public class ContactNotFoundException : System.Exception
    {
        public ContactNotFoundException()             
        { 

        }

        public ContactNotFoundException(string message)
            : base(message)
        {

        }
    }
}
