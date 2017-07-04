using System;
using System.Collections.Generic;

//namespace DefiningClasses
//{
class Program
{
        static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split();

                switch (command[0])
                {
                    case "Create": TestClient.Create(accounts, command); break;
                    case "Deposit": TestClient.Deposit(accounts, command); break;
                    case "Withdraw": TestClient.Withdaw(accounts, command); break;
                    case "Print": TestClient.Print(accounts, command);break;
                    default:break;
                }
            }

        var person = new Person("pesho",23);
        }
    }
//}
