using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Column("InsertDate", Order = 10)]
        public DateTime InsertDate { get; set; }
        [Column("UpdateDate", Order = 11)]
        public Nullable<DateTime> UpdateDate { get; set; }
        

    }
}
