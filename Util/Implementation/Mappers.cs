using bank.Dto;
using bank.Entity;

namespace bank.Util.Implementation
{
    public class Mappers : IMappers
    {
        public AccountDTO FromAccount(Account account)
        {
            ArgumentNullException.ThrowIfNull(account);
            return new AccountDTO
            {
                Balance = account.Balance,
                Currency = account.Currency,
                CustomerId = account.CustomerId,
                Id = account.Id
            };
        }

        public Account FromAccountDTO(AccountDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return new Account
            {
                Balance = dto.Balance,
                Currency = dto.Currency,
                CustomerId = dto.CustomerId,
                Id = dto.Id
            };
        }

        public CustomerDTO FromCustomer(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);
            return new CustomerDTO
            {
                Id = customer.Id,
                PlaceOfBirth = customer.PlaceOfBirth,
                DateOfBirth = customer.DateOfBirth,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Nationality = customer.Nationality,
                Gender = customer.Gender,
                AccountId = GetAccountId(customer.Account)
            };
        }

        public Customer FromCustomerDTO(CustomerDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return new Customer
            {
                Id = dto.Id,
                PlaceOfBirth = dto.PlaceOfBirth,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Nationality = dto.Nationality
            };
        }

        public List<AccountDTO> FromListOfAccounts(List<Account> accounts)
        {
            ArgumentNullException.ThrowIfNull(accounts);
            List<AccountDTO> accountDTOs = [];
            foreach (var account in accounts)
            {
                if (account != null)
                {
                    accountDTOs.Add(FromAccount(account));
                }
            }
            return accountDTOs;
        }

        public List<CustomerDTO> FromListOfCustomers(List<Customer> customers)
        {
            ArgumentNullException.ThrowIfNull(customers);
            List<CustomerDTO> customerDTOs = [];
            foreach (var customer in customers)
            {
                if (customer != null)
                {
                    customerDTOs.Add(FromCustomer(customer));
                }
            }
            return customerDTOs;
        }

        public List<OperationResponseDTO> FromListOfOperations(List<Operation> operations)
        {
            ArgumentNullException.ThrowIfNull(operations);
            List<OperationResponseDTO> operationsDTOs = [];
            foreach (var operation in operations)
            {
                if (operation != null)
                {
                    operationsDTOs.Add(FromOperation(operation));
                }
            }
            return operationsDTOs;
        }

        public OperationResponseDTO FromOperation(Operation operation)
        {
            ArgumentNullException.ThrowIfNull(operation);
            return new OperationResponseDTO
            {
                Type = operation.Type,
                AccountId = operation.AccountId,
                DateTime = operation.DateTime,
                Description = operation.Description,
                Amount = operation.Amount,
                Id = operation.Id
            };
        }

        private string GetAccountId(Account account)
        {
            if(account == null)
            {
                return string.Empty;
            }
            return account.Id;
        }
    }
}
