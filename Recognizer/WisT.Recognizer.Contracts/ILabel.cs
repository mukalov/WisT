namespace WisT.Recognizer.Contracts
{
    public interface ILabel
    {           
        //There also can be additional information about user which will be storaged in db
        IIdentifier Id { get; set; }
        string Name { get; set; }
    }
}
