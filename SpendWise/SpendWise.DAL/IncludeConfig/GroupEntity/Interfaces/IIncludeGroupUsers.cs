namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IIncludeGroupUsers
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
        IThenGuIncludeLimit ThenGuIncludeLimit(string path = "GroupUsers.Limit");
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
    }
}
