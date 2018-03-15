namespace Wist.Recognizer.Contracts
{
     public interface ILabel
    {
        string Name { get; }               
        IIdentifier Id { get; set; }
    }
}
