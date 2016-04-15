using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace bankAccountAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //instatiate a client
            Client dummyClient = new Client("Kyle McMahon");

            //instatiate an account and add it to client's list
            dummyClient.Account = new Account(dummyClient.Name);

            int menuResponse = 0;

            Console.WriteLine("BANK ACCOUNT MANAGEMENT APPLICATION v1.0\n");

            while (menuResponse != 5)
            {
                Console.WriteLine("MENU\n\n1. View Client Information\n2. View Account Balance\n3. Deposit Funds\n4. Withdraw Funds\n5. Exit\n");
                Console.Write("Selection: ");
                menuResponse = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (menuResponse)
                {
                    case 1:
                        Console.WriteLine("CLIENT INFORMATION\nName: {0}\nAccount number: {1}\n",dummyClient.Name, dummyClient.Account.AccountNumber);
                        //Thread.Sleep(5000);
                        break;
                    case 2:
                        Console.WriteLine("ACCOUNT BALANCE\nAccount number: {0}\nAccount balance: ${1}\n", dummyClient.Account.AccountNumber, dummyClient.Account.Balance);
                        break;
                    case 3:
                        Console.Write("Deposit amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        dummyClient.Account.Deposit(depositAmount);
                        Console.WriteLine("Deposit of ${0} confirmed.\n", depositAmount);
                        break;
                    case 4:
                        Console.Write("Withdrawal amount: ");
                        decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                        dummyClient.Account.Withdraw(withdrawalAmount);
                        Console.WriteLine("Withdrawl of ${0} confirmed.\n", withdrawalAmount);
                        break;
                    case 5:
                        Console.WriteLine("Goodbye.\n");
                        break;
                    default:
                        Console.WriteLine("Error\n");
                        break;
                }

                if (menuResponse == 5)
                {
                    break;
                }    
            }
        }
    }
}
