
namespace bank.Exceptions
{
    public class OperationNotFoundException : Exception
    {
        public OperationNotFoundException(string operationId) : base($"Operation with ID '{operationId}' was not found.")
        {
        }
    }
}
