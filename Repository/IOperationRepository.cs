using bank.Entity;

namespace bank.Repository
{
    public interface IOperationRepository
    {
        Operation Save(Operation operation);
        List<Operation> SaveAll(List<Operation> operations);
        void Delete(Operation operation);
        void DeleteById(string id);
        void DeleteByAccountId(string accountId);
        void DeleteAll(List<Operation> operations);
        void DeleteAll();
        Operation? FindById(string id);
        List<Operation> FindAll();
        List<Operation> FindByAccountId(string accountId);

    }
}
