using bank.Dto;

namespace bank.Service
{
    public interface ICustomerService
    {
        CustomerDTO? GetCustomerById(string id);
        List<CustomerDTO> GetAllCustomers();
        List<CustomerDTO> SearchCustomers(string keyword);
        CustomerDTO CreateCustomer(CustomerDTO dto);
        CustomerDTO UpdateCustomer(string id, CustomerDTO dto);
        void DeleteCustomerById(string id);
        void DeleteAllCustomers();
    }
}
