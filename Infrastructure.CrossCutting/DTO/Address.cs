using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CrossCutting.Models
{
    public class Address
    {
        public int UserId { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public int IdCity { get; set; }
        public int IdState { get; set; }
        public int IdCountry { get; set; }
        public DateTime InsertDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }

        public virtual User User { get; set; }
    }
}
