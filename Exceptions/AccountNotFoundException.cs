namespace bank.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string accountId): base($"Account with ID '{accountId}' was not found.")
        {
        }
    }
}
