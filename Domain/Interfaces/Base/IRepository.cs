using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity 
    {
        void Insert(T Obj);
        void Update(T Obj);
        void Delete(T Obj);
        T Select(int Id);
        IList<T> SelectAll();
    }
}
