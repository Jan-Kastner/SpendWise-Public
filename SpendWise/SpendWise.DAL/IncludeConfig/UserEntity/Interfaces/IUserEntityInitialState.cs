namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IUserEntityInitialState
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
