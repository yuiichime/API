﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CrossCutting.Models
{
    public class Phones
    {
        public int UserId { get; set; }
        public string PhonePrefix { get; set; }
        public string PhoneNumber { get; set; }

        public string CelphonePrefix { get; set; }
        public string CelPhoneNumber { get; set; }
        public DateTime InsertDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }

        public virtual User User { get; set; }
    }
}
