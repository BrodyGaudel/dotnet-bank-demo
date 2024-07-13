using bank.Entity;

namespace bank.Repository.Implementation
{
    public class OperationRepository(AppDbContext context) : IOperationRepository
    {
        private readonly AppDbContext _context = context;

        public void Delete(Operation operation)
        {
            _context.Operations.Remove(operation);
            _context.SaveChanges();
        }

        public void DeleteAll(List<Operation> operations)
        {
            _context.Operations.RemoveRange(operations);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var allOperations = _context.Operations.ToList();
            _context.Operations.RemoveRange(allOperations);
            _context.SaveChanges();
        }

        public void DeleteByAccountId(string accountId)
        {
            var operations = _context.Operations.Where(o => o.AccountId == accountId).ToList();
            _context.Operations.RemoveRange(operations);
            _context.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var operation = _context.Operations.Find(id);
            if (operation != null)
            {
                _context.Operations.Remove(operation);
                _context.SaveChanges();
            }
        }

        public List<Operation> FindAll()
        {
            return [.. _context.Operations];
        }

        public List<Operation> FindByAccountId(string accountId)
        {
            return [.. _context.Operations.Where(o => o.AccountId == accountId)];
        }

        public Operation? FindById(string id)
        {
            return _context.Operations.Find(id);
        }

        public Operation Save(Operation operation)
        {
            var existingOperation = _context.Operations.Find(operation.Id);
            if(existingOperation != null)
            {
                _context.Entry(existingOperation).CurrentValues.SetValues(operation);
            }
            else
            {
                _context.Operations.Add(operation);
            }
            _context.SaveChanges();
            return operation;
        }

        public List<Operation> SaveAll(List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                var existingOperation = _context.Operations.Find(operation.Id);
                if (existingOperation != null)
                {
                    _context.Entry(existingOperation).CurrentValues.SetValues(operation);
                }
                else
                {
                    _context.Operations.Add(operation);
                }
            }
            _context.SaveChanges();
            return operations;
        }
    }
}
