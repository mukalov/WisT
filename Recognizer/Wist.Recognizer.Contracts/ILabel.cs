namespace WistRecognizerContracts
{
     public interface ILabel
    {
        string Name { get; }               
        IIdentifier Id { get; set; }
    }
}
