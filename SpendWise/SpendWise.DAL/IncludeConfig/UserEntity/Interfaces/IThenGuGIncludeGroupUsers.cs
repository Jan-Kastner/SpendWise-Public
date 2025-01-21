namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IThenGuGIncludeGroupUsers
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IThenGuGGuIncludeUser ThenGuGGuIncludeUser(string path = "GroupUsers.Group.GroupUsers.User");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
