using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Phones")]
    public class PhonesEntity : BaseEntity
    {
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}