namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IThenGuIncludeTransactionGroupUsers
    {
        IThenGuTguIncludeTransaction ThenGuTguIncludeTransaction(string path = "GroupUsers.TransactionGroupUsers.Transaction");
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IThenGuIncludeGroup ThenGuIncludeGroup(string path = "GroupUsers.Group");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
