using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Phones")]
    public class PhonesEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string PhonePrefix { get; set; }
        public string PhoneNumber { get; set; }
        public string CelphonePrefix { get; set; }
        public string CelPhoneNumber { get; set; }

        public virtual UserEntity User { get; set; }
    }
}