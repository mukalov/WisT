namespace ValidationLLD
{
     public interface ILabel
    {
        string Name { get; }               
        IIdentifier ID { get; set; }
    }
}
