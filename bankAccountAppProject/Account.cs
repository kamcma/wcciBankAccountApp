using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bankAccountAppProject
{
    class Account
    {
        //fields
        private string owner;
        private int accountNumber;
        private decimal balance;
        //transaction history for the Account object will be stored in a List
        private List<Array> transactions = new List<Array>();

        //properties
        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public List<Array> Transactions
        {
            get
            {
                return transactions;
            }
            set
            {
                transactions = value;
            }
        }

        //constructors
        public Account(string owner)
        {
            this.Owner = owner;
            //newly instantiated accounts are assigned a random eight-digit account number
            this.AccountNumber = new Random().Next(10000000, 99999999);
            this.Balance = 0;
            //write the statement file from the Account constructor in case no transactions are performed
            WriteStatement();
        }

        //methods
        public void Deposit(decimal deposit)
        {
            //update the balance with the deposit parameter
            this.Balance += deposit;
            //add the transaction, represented by an array of Objects, to the transaction history list
            this.Transactions.Add(new Object[] { DateTime.Now, "+", deposit, this.Balance });
            //write the statement history to a text file
            WriteStatement();
            //print to the console to confirm action to the user
            Console.WriteLine("Deposit of ${0} confirmed.\n", deposit);
        }

        public void Withdraw(decimal withdrawal)
        {
            //update the balance with the withdrawal parameter
            this.Balance -= withdrawal;
            //add the transaction, represented by an array of Objects, to the transaction history list
            this.Transactions.Add(new Object[] { DateTime.Now, "-", withdrawal, this.Balance });
            //write the statement history to a text file
            WriteStatement();
            //print to the console to confirm action to the user
            Console.WriteLine("Withdrawl of ${0} confirmed.\n", withdrawal);
        }

        //the WriteStatement method is called by the Deposit and Withdrawal methods, and upon Account instantiation in case no transactions are performed
        private void WriteStatement()
        {
            using (StreamWriter statementWriter = new StreamWriter("AccountSummary.txt"))
            {
                //print account information
                statementWriter.WriteLine("BANK STATEMENT\r\n\r\nAccount holder: {0}\r\nAccount number: {1}\r\nBalance: ${2}\r\n\r\nTRANSACTION HISTORY\r\n", this.Owner, this.AccountNumber, this.Balance);
                //print the header row of the transaction history table
                statementWriter.WriteLine("Transaction (+/-)\tAmount\t\tDate and time\t\t\tCurrent balance\r\n");
                //print each transaction in the transactions list
                foreach (Array transaction in this.Transactions)
                {
                    //print transaction elements from the Object array
                    statementWriter.WriteLine("{0}\t\t\t${1}\t\t{2}\t\t${3}", transaction.GetValue(1), transaction.GetValue(2), transaction.GetValue(0), transaction.GetValue(3));
                }
            } 
        }
    }
}
