

namespace ConsoleApp4
{
    class User
    {
        public string AccountName { get; set; }
        public string Pin { get; set; }

        public Account Checking { get; set; }
        public Account Savings { get; set; }

        public User(string name, string pin, double checkingBalance, double savings)
        {
            this.AccountName = name;
            this.Pin = pin;
            this.Checking = new Account() { Balance = checkingBalance };
            this.Savings = new Account() { Balance = savings };
        }

        public User(string data)
        {

            var splitted = data.Split(',');
            AccountName = splitted[0].Trim();
            Pin = splitted[1].Trim();
            Checking = new Account() { Balance = double.Parse(splitted[2].Trim()) };
            Savings = new Account() { Balance = double.Parse(splitted[3].Trim()) };
        }

        public string ToCSVFormat()
        {
            return $"{AccountName}, {Pin}, {Checking.Balance}, {Savings.Balance}";
        }
    }
}



