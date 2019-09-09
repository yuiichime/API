using System;
using System.Collections.Generic;

namespace Infrastructure.CrossCutting.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }

        public virtual IEnumerable<Address> Address { get; set; }
        public virtual IEnumerable<Phones> Phones { get; set; }
    }
}
