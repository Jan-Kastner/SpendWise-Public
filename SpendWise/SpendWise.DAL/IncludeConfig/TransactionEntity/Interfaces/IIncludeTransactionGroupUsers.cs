namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IIncludeTransactionGroupUsers
    {
        IIncludeCategory IncludeCategory(string path = "Category");
        IThenTguIncludeGroupUser ThenTguIncludeGroupUser(string path = "TransactionGroupUsers.GroupUser");
    }
}
