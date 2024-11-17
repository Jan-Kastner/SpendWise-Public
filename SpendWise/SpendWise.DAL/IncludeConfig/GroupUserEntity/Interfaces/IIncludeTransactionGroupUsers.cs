namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeTransactionGroupUsers
    {
        IThenTguIncludeTransaction ThenTguIncludeTransaction(string path = "TransactionGroupUsers.Transaction");
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeUser IncludeUser(string path = "User");
        IIncludeLimit IncludeLimit(string path = "Limit");
    }
}
