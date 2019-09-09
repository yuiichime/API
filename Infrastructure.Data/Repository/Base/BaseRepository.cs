using Domain.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlContext context;

        public BaseRepository(SqlContext _context)
        {
            context = _context;
        }

        public T Insert(T obj)
        {
            obj.InsertDate = DateTime.Now;
            context.Set<T>().Add(obj);
            context.SaveChanges();
            return context.Set<T>().Find(obj.Id);
        }

        public T Update(T obj)
        {
            obj.UpdateDate = DateTime.Now;
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return context.Set<T>().Find(obj.Id);
        }

        public void Delete(int id)
        {
            //context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public virtual IList<T> Select()
        {
            return  context.Set<T>().ToList();
        }

        public virtual T Select(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}

