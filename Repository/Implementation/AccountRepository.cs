using bank.Entity;

namespace bank.Repository.Implementation
{
    public class AccountRepository(AppDbContext context) : IAccountRepository
    {
        private readonly AppDbContext _context = context;

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        public void DeleteAll(List<Account> accounts)
        {
            _context.Accounts.RemoveRange(accounts);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var allAccounts = _context.Accounts.ToList();
            _context.Accounts.RemoveRange(allAccounts);
            _context.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var account = _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
        }

        public List<Account> FindAll()
        {
            return _context.Accounts.ToList();
        }

        public Account? FindByCustomerId(string customerId)
        {
            return _context.Accounts.FirstOrDefault(a => a.CustomerId == customerId);
        }

        public Account? FindById(string id)
        {
            return _context.Accounts.Find(id);
        }

        public Account Save(Account account)
        {
            var existingAccount = _context.Accounts.Find(account.Id);
            if (existingAccount != null)
            {
                _context.Entry(existingAccount).CurrentValues.SetValues(account);
            }
            else
            {
                _context.Accounts.Add(account);
            }
            _context.SaveChanges();
            return account;
        }

        public List<Account> SaveAll(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var existingAccount = _context.Accounts.Find(account.Id);
                if (existingAccount != null)
                {
                    _context.Entry(existingAccount).CurrentValues.SetValues(account);
                }
                else
                {
                    _context.Accounts.Add(account);
                }
            }
            _context.SaveChanges();
            return accounts;
        }
    }
}
