using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your name and pin");
            var nameAndPin = Console.ReadLine().Split(' ');
            var name = nameAndPin[0];
            var pin = nameAndPin[1];
            var path = "../../User/User.cs";
            var allUsers = new List<User>();
            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() > -1)
                {
                    var data = reader.ReadLine();
                    allUsers.Add(new User(data));
                }
            }

            var currentUser = allUsers.FirstOrDefault(f => f.Pin == pin && f.AccountName == name);

            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine($"Checkings: {currentUser.Checking.Balance} Savings: {currentUser.Savings.Balance}");

                Console.WriteLine("---------------------");
                Console.WriteLine("What do you want to do:");
                Console.WriteLine("1) deposit into savings");
                Console.WriteLine("0) exit");
                var action = Console.ReadLine();

                if (action == "1")
                {
                    Console.WriteLine("How much?");
                    var amount = Console.ReadLine();
                    currentUser.Savings.Deposit(Double.Parse(amount));
                }
                else if (action == "0")
                {
                    isRunning = false;
                }
            }

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(currentUser.ToCSVFormat());
            }
            Console.WriteLine("Bye!");

        }
    }
}
