namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a transaction entity with various properties.
    /// </summary>
    public interface ITransactionEntity : IEntity, IDescription, IAmount, IDate, ITransactionType, ICategoryId
    {
    }
}