using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Address")]
    public class AddressEntity : BaseEntity   
    {
        public int UserId { get; set; }
        public virtual UserEntity User{ get; set; }
    }
}