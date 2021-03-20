using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Address")]
    public class AddressEntity : BaseEntity   
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

        public virtual UserEntity User { get; set; }
    }
}