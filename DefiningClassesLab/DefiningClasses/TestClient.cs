using System;
using System.Collections.Generic;

//namespace DefiningClasses
//{
public static class TestClient
    {
        public static void Create(Dictionary<int, BankAccount> accounts, string[] command)
        {
            int id = int.Parse(command[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.ID = id;
                accounts.Add(id, acc);
            }
        }

        public static void Withdaw(Dictionary<int, BankAccount> accounts, string[] command)
        {
            int id = int.Parse(command[1]);
            double amount = double.Parse(command[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if(accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(amount);
            }
        }

        public static void Print(Dictionary<int, BankAccount> accounts, string[] command)
        {
            int id = int.Parse(command[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id].ToString());
            }
    }

        public static void Deposit(Dictionary<int, BankAccount> accounts, string[] command)
        {
            int id = int.Parse(command[1]);
            double amount = double.Parse(command[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else 
            {
                accounts[id].Deposit(amount);
            }
        }
    }
//}
