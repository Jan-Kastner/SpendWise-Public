namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IIncludeGroupUsers
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
        IThenGuIncludeGroup ThenGuIncludeGroup(string path = "GroupUsers.Group");
    }
}
