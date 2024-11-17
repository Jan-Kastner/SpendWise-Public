namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IIncludeTransactionGroupUsers
    {
        IThenTguIncludeGroupUser ThenTguIncludeGroupUser(string path = "TransactionGroupUsers.GroupUser");
        IIncludeCategory IncludeCategory(string path = "Category");
    }
}
