using bank.Entity;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace bank.Repository.Implementation
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {

        private readonly AppDbContext _context = context;

        public void Delete(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                _context.Customers.Remove(existingCustomer);
                _context.SaveChanges();
            }
        }

        public void DeleteAll(List<Customer> customers)
        {
            ArgumentNullException.ThrowIfNull(customers);
            foreach (Customer customer in customers)
            {
                if(customer != null)
                {
                    Delete(customer);
                }
            }
        }

        public void DeleteAll()
        {
            var allCustomers = _context.Customers.ToList();
            _context.Customers.RemoveRange(allCustomers);
            _context.SaveChanges();
        }

        public void DeleteById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id cannot be null or empty", nameof(id));
            }
            else
            {
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }
            }
        }

        public List<Customer> FindAll()
        {
            return [.. _context.Customers];
        }

        public Customer? FindById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id cannot be null or empty", nameof(id));
            }
            return _context.Customers.Find(id);
        }

        public Customer Save(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            }
            else
            {
                _context.Customers.Add(customer);
            }
            _context.SaveChanges();
            return customer;
        }

        public List<Customer> SaveAll(List<Customer> customers)
        {
            ArgumentNullException.ThrowIfNull(customers);
            List<Customer> result = [];
            foreach (Customer customer in customers)
            {
                result.Add(Save(customer));
            }
            return result;
        }

        public List<Customer> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("Keyword cannot be null or empty", nameof(keyword));
            }

            return
            [
                .. _context.Customers
                                .Where(c => c.FirstName.Contains(keyword) || c.LastName.Contains(keyword))
,
            ];
        }
    }
}
