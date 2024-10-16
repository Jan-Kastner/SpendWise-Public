namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IIncludeSentInvitations
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
    }
}
