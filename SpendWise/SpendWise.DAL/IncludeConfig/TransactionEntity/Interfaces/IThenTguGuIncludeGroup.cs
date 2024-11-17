namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IThenTguGuIncludeGroup
    {
        IThenTguGuGIncludeGroupUsers ThenTguGuGIncludeGroupUsers(string path = "TransactionGroupUsers.GroupUser.Group.GroupUsers");
        IIncludeCategory IncludeCategory(string path = "Category");
        IThenTguGuIncludeUser ThenTguGuIncludeUser(string path = "TransactionGroupUsers.GroupUser.User");
    }
}
