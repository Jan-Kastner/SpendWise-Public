namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeTransactionGroupUsers
    {
        IIncludeUser IncludeUser(string path = "User");
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IThenTguIncludeTransaction ThenTguIncludeTransaction(string path = "TransactionGroupUsers.Transaction");
    }
}
