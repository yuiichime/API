using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
        public virtual ICollection<AddressEntity> Address { get; set; }
        public virtual ICollection<PhonesEntity> Phones { get; set; }

    }
}
