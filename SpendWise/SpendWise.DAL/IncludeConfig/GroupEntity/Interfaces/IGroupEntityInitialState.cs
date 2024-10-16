namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IGroupEntityInitialState
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
    }
}
