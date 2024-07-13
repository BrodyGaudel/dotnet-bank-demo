using bank.Enums;

namespace bank.Entity
{
    public class Operation
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public OperationType Type { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}
