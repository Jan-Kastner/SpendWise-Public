namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeTransactionGroupUsers
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IThenTguIncludeTransaction ThenTguIncludeTransaction(string path = "TransactionGroupUsers.Transaction");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeUser IncludeUser(string path = "User");
    }
}
