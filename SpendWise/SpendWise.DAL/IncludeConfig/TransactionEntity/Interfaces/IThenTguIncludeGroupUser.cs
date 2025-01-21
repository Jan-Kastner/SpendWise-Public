namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IThenTguIncludeGroupUser
    {
        IIncludeCategory IncludeCategory(string path = "Category");
        IThenTguGuIncludeUser ThenTguGuIncludeUser(string path = "TransactionGroupUsers.GroupUser.User");
        IThenTguGuIncludeGroup ThenTguGuIncludeGroup(string path = "TransactionGroupUsers.GroupUser.Group");
    }
}
