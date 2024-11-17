namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuIncludeTransactionGroupUsers
    {
        IThenGuTguIncludeTransaction ThenGuTguIncludeTransaction(string path = "GroupUsers.TransactionGroupUsers.Transaction");
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
    }
}
