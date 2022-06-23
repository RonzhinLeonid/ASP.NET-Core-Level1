namespace DataLayer.Base.Interfaces
{
    internal interface IOrderedEntity : IEntity
    {
        int Order { get; set; }
    }
}
