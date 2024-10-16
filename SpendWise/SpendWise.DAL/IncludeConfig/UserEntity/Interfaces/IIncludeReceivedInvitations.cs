namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IIncludeReceivedInvitations
    {
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
