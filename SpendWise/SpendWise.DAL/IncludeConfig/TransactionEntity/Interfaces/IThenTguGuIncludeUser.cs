namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IThenTguGuIncludeUser
    {
        IThenTguGuIncludeGroup ThenTguGuIncludeGroup(string path = "TransactionGroupUsers.GroupUser.Group");
        IIncludeCategory IncludeCategory(string path = "Category");
    }
}
