using bank.Enums;

namespace bank.Dto
{
    public class OperationRequestDTO
    {
        public OperationType Type { get; set; }
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set;}
    }
}
