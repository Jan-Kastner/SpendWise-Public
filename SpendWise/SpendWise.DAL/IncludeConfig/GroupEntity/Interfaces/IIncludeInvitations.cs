namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IIncludeInvitations
    {
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
    }
}
