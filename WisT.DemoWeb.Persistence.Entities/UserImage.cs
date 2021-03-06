using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Imaging;
using System.IO;
using WisT.Recognizer.Contracts;

namespace WisT.DemoWeb.Persistence.DataEntities
{
    public partial class UserImage
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        public UserImage()
        {
        }

        public UserImage(IFaceImage faceImage)
        {
            MemoryStream memoryStream = new MemoryStream();
            faceImage.ImageOfFace.Save(memoryStream, ImageFormat.Bmp);
            byte[] image = memoryStream.ToArray();

            Image = image;
        }

        public User User { get; set; }
    }
}
