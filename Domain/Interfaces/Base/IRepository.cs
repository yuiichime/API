using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity 
    {
        T Insert(T Obj);
        T Update(T Obj);
        void Delete(int Id);
        T Select(int Id);
        IList<T> Select();
    }
}
