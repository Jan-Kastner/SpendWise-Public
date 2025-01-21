namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IIncludeGroupUsers
    {
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IThenGuIncludeGroup ThenGuIncludeGroup(string path = "GroupUsers.Group");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
