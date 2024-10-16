namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface IThenGuIncludeUser
    {
        IIncludeTransaction IncludeTransaction(string path = "Transaction");
    }
}
