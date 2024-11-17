namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IThenTguGuGIncludeGroupUsers
    {
        IThenTguGuGGuIncludeUser ThenTguGuGGuIncludeUser(string path = "TransactionGroupUsers.GroupUser.Group.GroupUsers.User");
        IIncludeCategory IncludeCategory(string path = "Category");
    }
}
