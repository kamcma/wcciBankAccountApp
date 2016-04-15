using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankAccountAppProject
{
    class Client
    {
        //fields
        private string name;
        private Account account;

        //properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Account Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
            }
        }

        //constructors
        public Client()
        {
            //if the Client object is not instantiated with a name, give it a generic name
            this.Name = "John Q. Public";
        }
        public Client(string name)
        {
            this.Name = name;
        }
    }
}
