using bank.Dto;

namespace bank.Service
{
    public interface IAccountService
    {
        AccountDTO? GetAccountById(string id);
        AccountDTO? GetAccountByCustomerId(string customerId);
        List<AccountDTO> GetAllAccounts();
        AccountDTO CreateAccount(AccountDTO dto);
        void DeleteAccountById(string id);
        void DeleteAllAccount();
    }
}
