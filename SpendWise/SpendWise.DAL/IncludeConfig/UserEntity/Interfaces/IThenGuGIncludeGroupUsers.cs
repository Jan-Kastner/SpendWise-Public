namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IThenGuGIncludeGroupUsers
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
        IThenGuGGuIncludeUser ThenGuGGuIncludeUser(string path = "GroupUsers.Group.GroupUsers.User");
    }
}
