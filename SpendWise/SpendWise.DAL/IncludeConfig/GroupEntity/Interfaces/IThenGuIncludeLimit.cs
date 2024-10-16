namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuIncludeLimit
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
    }
}
