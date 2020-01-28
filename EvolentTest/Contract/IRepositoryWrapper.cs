using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentTest.Contract
{
    public interface IRepositoryWrapper
    {
        IContactRepository Contact { get; }
        void Save();
    }
}
