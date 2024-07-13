using bank.Dto;
using bank.Repository;
using bank.Entity;
using bank.Util;
using bank.Enums;
using bank.Exceptions;

namespace bank.Service.Implementation
{
    public class OperationService(IAccountRepository iaccountRepository, IOperationRepository ioperationRepository, IMappers imappers) : IOperationService
    {

        private readonly IAccountRepository accountRepository = iaccountRepository;
        private readonly IOperationRepository operationRepository = ioperationRepository;
        private readonly IMappers mappers = imappers;

        public OperationResponseDTO? Credit(string accountId, double amount, string description)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("AccountId cannot be null or empty");
            }
            if(amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero");
            }
            return ProcessTransaction(accountId, amount, description, OperationType.CREDIT);
        }

        public OperationResponseDTO? Debit(string accountId, double amount, string description)
        {

            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("AccountId cannot be null or empty");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero");
            }
            return ProcessTransaction(accountId, amount, description, OperationType.DEBIT);
        }

        public List<OperationResponseDTO> GetAllOperations()
        {
            List<Operation> operations = operationRepository.FindAll();
            return mappers.FromListOfOperations(operations);
        }

        public List<OperationResponseDTO> GetAllOperationsByAccountId(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException("AccountId cannot be null or empty");
            }
            List<Operation> operations = operationRepository.FindByAccountId(accountId);
            return mappers.FromListOfOperations(operations);
        }

        public OperationResponseDTO? GetOperationById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Operation Id cannot be null or empty");
            }
            Operation? operation = operationRepository.FindById(id);
            return operation == null ? throw new OperationNotFoundException(id) : mappers.FromOperation(operation);
        }

        private OperationResponseDTO? ProcessTransaction(string accountId, double amount, string description, OperationType type)
        {
            Account? account = accountRepository.FindById(accountId) ?? throw new AccountNotFoundException(accountId);
            if (type == OperationType.DEBIT && account.Balance < amount)
            {
                throw new InsufficientBalanceException(accountId, amount);
            }
            Operation operation = new()
            {
                Type = type,
                AccountId = account.Id,
                Account = account,
                Amount = amount,
                Description = description,
                DateTime = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };
            Operation savedOperation = operationRepository.Save(operation);
            account.Balance += type == OperationType.CREDIT ? savedOperation.Amount : -savedOperation.Amount;
            accountRepository.Save(account);

            return mappers.FromOperation(savedOperation);
        }
    }
}
