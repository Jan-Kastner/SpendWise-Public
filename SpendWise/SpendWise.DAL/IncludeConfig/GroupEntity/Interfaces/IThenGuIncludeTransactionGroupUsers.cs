namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuIncludeTransactionGroupUsers
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
        IThenGuTguIncludeTransaction ThenGuTguIncludeTransaction(string path = "GroupUsers.TransactionGroupUsers.Transaction");
        IThenGuIncludeLimit ThenGuIncludeLimit(string path = "GroupUsers.Limit");
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
    }
}
