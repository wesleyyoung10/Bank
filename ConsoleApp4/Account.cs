

namespace ConsoleApp4
{
    class Account
    {
        public double Balance { get; set; }

        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }
        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }
    }
}


