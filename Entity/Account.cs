using bank.Enums;

namespace bank.Entity
{
    public class Account
    {
        public string Id { get; set; }
        public AccountCurrency Currency { get; set; }
        public double Balance { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}
