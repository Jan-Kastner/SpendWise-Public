namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IThenTguTIncludeCategory
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeUser IncludeUser(string path = "User");
    }
}
