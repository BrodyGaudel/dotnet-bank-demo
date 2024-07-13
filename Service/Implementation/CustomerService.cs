using bank.Dto;
using bank.Entity;
using bank.Exceptions;
using bank.Repository;
using bank.Util;

namespace bank.Service.Implementation
{
    public class CustomerService(ICustomerRepository icustomerRepository, IMappers imappers) : ICustomerService
    {

        private readonly ICustomerRepository customerRepository = icustomerRepository;
        private readonly IMappers mappers = imappers;

        public CustomerDTO CreateCustomer(CustomerDTO dto)
        {
            Customer customer = mappers.FromCustomerDTO(dto);
            customer.Id = Guid.NewGuid().ToString();
            Customer savedCustomer = customerRepository.Save(customer);
            return mappers.FromCustomer(savedCustomer);
        }

        public void DeleteAllCustomers()
        {
            customerRepository.DeleteAll();
        }

        public void DeleteCustomerById(string id)
        {
            customerRepository.DeleteById(id);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            List<Customer> customers = customerRepository.FindAll();
            return mappers.FromListOfCustomers(customers);
        }

        public CustomerDTO? GetCustomerById(string id)
        {
            Customer? customer = customerRepository.FindById(id);
            return customer == null ? throw new CustomerNotFoundException(id) : mappers.FromCustomer(customer);
        }

        public List<CustomerDTO> SearchCustomers(string keyword)
        {
            List<Customer> customers = customerRepository.Search(keyword);
            return mappers.FromListOfCustomers(customers);
        }

        public CustomerDTO UpdateCustomer(string id, CustomerDTO dto)
        {
            Customer? existingCustomer = customerRepository.FindById(id) ?? throw new CustomerNotFoundException(id);
            existingCustomer.FirstName = dto.FirstName;
            existingCustomer.LastName = dto.LastName;
            existingCustomer.PlaceOfBirth = dto.PlaceOfBirth;
            existingCustomer.DateOfBirth = dto.DateOfBirth;
            existingCustomer.Gender = dto.Gender;
            existingCustomer.Nationality = dto.Nationality;

            Customer updatedCustomer = customerRepository.Save(existingCustomer);
            return mappers.FromCustomer(updatedCustomer);
        }
    }
}
