using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WisT.Recognizer.Contracts;

namespace WisT.DemoWeb.Persistence.DataEntities
{
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserImages = new HashSet<UserImage>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public User(ILabel label)
        {
            Name = label.Name;
            UserImages = new HashSet<UserImage>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserImage> UserImages { get; set; }
    }
}
