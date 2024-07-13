using bank.Entity;
using bank.Dto;
using bank.Repository;
using bank.Util;
using bank.Exceptions;

namespace bank.Service.Implementation
{
    public class AccountService(IAccountRepository iaccountRepository, ICustomerRepository icustomerRepository, IMappers imappers) : IAccountService
    {

        private readonly IAccountRepository accountRepository = iaccountRepository;
        private readonly ICustomerRepository customerRepository = icustomerRepository;
        private readonly IMappers mappers = imappers;

        public AccountDTO CreateAccount(AccountDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            Customer? customer = customerRepository.FindById(dto.CustomerId) ?? throw new CustomerNotFoundException(dto.CustomerId);
            Account account = mappers.FromAccountDTO(dto);
            account.Id = GenerateAccountId();
            account.CustomerId = customer.Id;
            account.Customer = customer;

            Account accountSaved = accountRepository.Save(account);
            return mappers.FromAccount(accountSaved);
        }

        public void DeleteAccountById(string id)
        {
            accountRepository.DeleteById(id);
        }

        public void DeleteAllAccount()
        {
            accountRepository.DeleteAll();
        }

        public AccountDTO? GetAccountByCustomerId(string customerId)
        {
            Account? account = accountRepository.FindByCustomerId(customerId);
            return account == null ? throw new AccountNotFoundException(customerId) : mappers.FromAccount(account);
        }

        public AccountDTO? GetAccountById(string id)
        {
            Account? account = accountRepository.FindById(id);
            return account == null ? throw new AccountNotFoundException(id) : mappers.FromAccount(account);
        }

        public List<AccountDTO> GetAllAccounts()
        {
            List<Account> accounts = accountRepository.FindAll();
            return mappers.FromListOfAccounts(accounts);

        }


        private static string GenerateAccountId()
        {
            Random random = new();
            long minValue = 1000000000000L;
            long maxValue = 9999999999999L;
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            long longRand = BitConverter.ToInt64(buffer, 0);

            return (Math.Abs(longRand % (maxValue - minValue)) + minValue).ToString();
        }
    }
}
