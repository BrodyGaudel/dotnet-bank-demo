
namespace bank.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string customerId) : base($"Customer with ID '{customerId}' was not found.")
        {
        }
    }
}
