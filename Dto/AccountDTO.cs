using bank.Enums;

namespace bank.Dto
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public AccountCurrency Currency { get; set; }
        public double Balance { get; set; }
        public string CustomerId { get; set; }
    }
}
