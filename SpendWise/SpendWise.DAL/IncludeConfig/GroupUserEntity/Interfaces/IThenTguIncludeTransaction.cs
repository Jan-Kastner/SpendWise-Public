namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IThenTguIncludeTransaction
    {
        IThenTguTIncludeCategory ThenTguTIncludeCategory(string path = "TransactionGroupUsers.Transaction.Category");
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeUser IncludeUser(string path = "User");
        IIncludeLimit IncludeLimit(string path = "Limit");
    }
}
