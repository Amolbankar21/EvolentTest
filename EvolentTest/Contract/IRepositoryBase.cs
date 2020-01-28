
using EvolentTest.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EvolentTest.Contract
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

    }
}
