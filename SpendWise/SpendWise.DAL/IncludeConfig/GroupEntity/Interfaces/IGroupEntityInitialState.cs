namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IGroupEntityInitialState
    {
        IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers");
    }
}
