namespace DataLayer.Base.Interfaces
{
    internal interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}
