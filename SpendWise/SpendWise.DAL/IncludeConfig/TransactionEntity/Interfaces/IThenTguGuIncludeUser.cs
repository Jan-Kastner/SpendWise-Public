namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface IThenTguGuIncludeUser
    {
        IIncludeCategory IncludeCategory(string path = "Category");
    }
}
