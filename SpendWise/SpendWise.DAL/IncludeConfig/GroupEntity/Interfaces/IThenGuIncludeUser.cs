namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuIncludeUser
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
        IThenGuIncludeLimit ThenGuIncludeLimit(string path = "GroupUsers.Limit");
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
    }
}
