namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IThenTguTIncludeCategory
    {
        IIncludeUser IncludeUser(string path = "User");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
