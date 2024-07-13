using bank.Dto;
using bank.Entity;

namespace bank.Util
{
    public interface IMappers
    {
        Customer FromCustomerDTO(CustomerDTO dto);
        CustomerDTO FromCustomer(Customer customer);
        List<CustomerDTO> FromListOfCustomers(List<Customer> customers);
        Account FromAccountDTO(AccountDTO dto);
        AccountDTO FromAccount(Account account);
        List<AccountDTO> FromListOfAccounts(List<Account> accounts);
        OperationResponseDTO FromOperation(Operation operation);
        List<OperationResponseDTO> FromListOfOperations(List<Operation> operations);
        
    }
}
