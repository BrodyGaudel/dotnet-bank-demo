using bank.Entity;

namespace bank.Repository
{
    public interface IAccountRepository
    {
        Account? FindById(string id);
        Account? FindByCustomerId(string customerId);
        List<Account> FindAll();
        Account Save(Account account);
        List<Account> SaveAll(List<Account> accounts);
        void DeleteById(string id);
        void Delete(Account account);
        void DeleteAll(List<Account> accounts);
        void DeleteAll();
    }
}
