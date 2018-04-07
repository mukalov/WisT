using System.Drawing;


namespace WisT.Recognizer.Contracts
{
    public interface IFaceImage
    {
        Bitmap ImageOfFace { get; set; }
        IIdentifier Id { get; set; }
    }
}
