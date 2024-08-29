namespace SpendWise.Common.Enums
{
    /// <summary>
    /// Represents the type of a transaction.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Represents an income transaction.
        /// </summary>
        Income,

        /// <summary>
        /// Represents an expense transaction.
        /// </summary>
        Expense,

        /// <summary>
        /// Represents a transfer transaction between accounts.
        /// </summary>
        Transfer,

        /// <summary>
        /// Represents a refund transaction.
        /// </summary>
        Refund,

        /// <summary>
        /// Represents a loan transaction.
        /// </summary>
        Loan,

        /// <summary>
        /// Represents an investment transaction.
        /// </summary>
        Investment,

        /// <summary>
        /// Represents a payment transaction.
        /// </summary>
        Payment
    }
}
