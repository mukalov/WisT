using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public User(ILabel label)
        {
            Name = label.Name;
            UserImages = new HashSet<UserImage>();
        }

        public virtual ICollection<UserImage> UserImages { get; set; }
    }
}
