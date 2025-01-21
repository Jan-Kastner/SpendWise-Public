namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface IIncludeTransaction
    {
        void ThenTIncludeCategory(string path = "Transaction.Category");
    }
}
