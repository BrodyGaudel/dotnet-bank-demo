namespace bank.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string accountId, double amount)
            : base($"Account with ID '{accountId}' has insufficient balance for the requested debit of {amount}.")
        {
        }
    }
}
