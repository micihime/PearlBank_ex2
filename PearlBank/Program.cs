using PearlBank.Models;
using System;

namespace PearlBank
{
    public class Program
    {
        public static void Main()
        {
            Bank ourBank = new Bank();
            Account account = new Account("Sipkova Ruzenka", "Za 7 horami", 1000000);
            if (ourBank.StoreAccount(account))
                Console.WriteLine("Account added to bank");
            Account account2 = new Account("Snehulienka", "Za 7 dolami", 100);
            if (ourBank.StoreAccount(account2))
                Console.WriteLine("Account added to bank");
            ourBank.Save("Test.txt");

            Bank loadBank = Bank.Load("Test.txt");
            IAccount storedAccount = loadBank.FindAccount("Rob");
            if (storedAccount != null)
                Console.WriteLine("CustomerAccount found in bank");
            storedAccount = loadBank.FindAccount("David");
            if (storedAccount != null)
                Console.WriteLine("BabyAccount found in bank");
        }
    }
}