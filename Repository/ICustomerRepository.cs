using bank.Entity;

namespace bank.Repository
{
    public interface ICustomerRepository
    {
        Customer? FindById(string id);
        List<Customer> FindAll();
        List<Customer> Search(string keyword);
        Customer Save(Customer customer);
        List<Customer> SaveAll(List<Customer> customers);
        void DeleteById(string id);
        void Delete(Customer customer);
        void DeleteAll(List<Customer> customers);
        void DeleteAll();

    }
}
