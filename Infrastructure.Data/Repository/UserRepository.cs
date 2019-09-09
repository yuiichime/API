using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        private readonly SqlContext context;
        public UserRepository(SqlContext _context) : base(_context)
        {
            context = _context;
        }


        
        public override UserEntity Select(int Id)
        {
            var user = context.Set<UserEntity>().Find(Id);
            user.Password = String.Empty;
            return user;
        }
    }
}
