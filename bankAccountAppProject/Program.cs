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
            Client dummyClient = new Client();

            //instatiate an account and add it to client's list
            dummyClient.Account = new Account(dummyClient.Name);

            //declare a user response variable that will control menu flow
            int menuResponse = 0;

            Console.WriteLine("BANK ACCOUNT MANAGEMENT APPLICATION v1.0\n");

            //open a loop that will run until the user selects 'exit'
            while (menuResponse != 5)
            {
                //print out the menu options and request a user selection
                Console.WriteLine("MENU\n\n1. View Client Information\n2. View Account Balance\n3. Deposit Funds\n4. Withdraw Funds\n5. Exit\n");
                Console.Write("Selection: ");
                if (!int.TryParse(Console.ReadLine(), out menuResponse))
                {
                    //if user input fails to parse to an int, sets response variable to 0
                    menuResponse = 0;
                }
                Console.WriteLine();

                //switch statement to perform correct action based on user selection
                switch (menuResponse)
                {                    
                    case 1:
                        //print client informatoin from client object properties
                        Console.WriteLine("CLIENT INFORMATION\nName: {0}\nAccount number: {1}\n",dummyClient.Name, dummyClient.Account.AccountNumber);
                        break;
                    case 2:
                        //print account information from client account object property's properties
                        Console.WriteLine("ACCOUNT BALANCE\nAccount number: {0}\nAccount balance: ${1}\n", dummyClient.Account.AccountNumber, dummyClient.Account.Balance);
                        break;
                    case 3:
                        //request a deposit amount from the user
                        Console.Write("Deposit amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        //pass in deposit ammount to the Deposit method of the Account object
                        dummyClient.Account.Deposit(depositAmount);
                        break;
                    case 4:
                        //request a withdrawal amount from the user
                        Console.Write("Withdrawal amount: ");
                        decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                        //pass in withdrawal amount to the Withdraw method of the Account object
                        dummyClient.Account.Withdraw(withdrawalAmount);
                        break;
                    case 5:
                        //print goodbye
                        Console.WriteLine("Goodbye.\n");
                        break;
                    default:
                        //Catch erroneous menu selections
                        Console.WriteLine("Invalid menu selection\n");
                        break;
                }

                //if user selects 'exit' option, exit the menu loop
                if (menuResponse == 5)
                {
                    break;
                }    
            }
        }
    }
}
