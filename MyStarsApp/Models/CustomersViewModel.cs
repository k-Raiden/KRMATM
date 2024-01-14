namespace MyStarsApp.Models
{
    public class CustomersViewModel
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int AccountNumber { get; set; }

        public int PinNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal NewBalance { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal WithdrawAmount { get; set;}
    }
}
