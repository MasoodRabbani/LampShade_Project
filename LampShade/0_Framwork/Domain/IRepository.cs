using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Domain
{
    public interface IRepository<TKet,T> where T:class
    {
        T Get(TKet Id);
        List<T> Get();
        void Create(T Entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
