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
        private List<string> transactions = new List<string>();

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
        public List<string> Transactions
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
            this.AccountNumber = new Random().Next(10000000, 99999999);
            this.Balance = 0;
            WriteStatement();
        }

        //methods

        public void Deposit(decimal deposit)
        {
            this.Balance += deposit;
            this.Transactions.Add("+\t\t\t$" + deposit + "\t\t" + DateTime.Now + "\t\t$" + this.Balance);
            WriteStatement();
        }

        public void Withdraw(decimal withdrawal)
        {
            this.Balance -= withdrawal;
            this.Transactions.Add("-\t\t\t$" + withdrawal + "\t\t" + DateTime.Now + "\t\t$" + this.Balance);
            WriteStatement();
        }

        private void WriteStatement()
        {
            using (StreamWriter statementWriter = new StreamWriter("AccountSummary.txt"))
            {
                statementWriter.WriteLine("Account holder: {0}\r\nAccount number: {1}\r\nBalance: ${2}\r\n", this.Owner, this.AccountNumber, this.Balance);
                statementWriter.WriteLine("Transaction (+/-)\tAmount\t\tDate and time\t\t\tCurrent balance\r\n");
                foreach (string transaction in this.Transactions)
                {
                    statementWriter.WriteLine(transaction);
                }

            }
                
        }

    }
}
