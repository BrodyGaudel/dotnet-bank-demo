using bank.Dto;

namespace bank.Service
{
    public interface IOperationService
    {
        OperationResponseDTO? Credit(string accountId, double amount, string description);
        OperationResponseDTO? Debit(string accountId, double amount, string description);
        List<OperationResponseDTO> GetAllOperations();
        List<OperationResponseDTO> GetAllOperationsByAccountId(string accountId);
        OperationResponseDTO? GetOperationById(string id);

    }
}
