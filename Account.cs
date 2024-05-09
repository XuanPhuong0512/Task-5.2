using System;
using System.ComponentModel.Design;

namespace Task5._2
{
    
    class Account
    {
        private decimal _balance;
        private String _name;

        public Account(String name, decimal balance)
        {
            _balance = balance;
            _name = name;
        }

        bool successful = true;
        bool unsuccessful = false;
        internal decimal Balance;

        public bool Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                _balance += amount;
                Console.WriteLine("You have deposited: " + amount + " New balance is now: " + _balance);
                return successful;
            }
            else
            {
                Console.WriteLine("You cannot deposit a negative amount");
                return successful;
            }
            
        }


        public bool Withdrawal(decimal amount)
        {
            if (amount > 0)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    Console.WriteLine("You have withdrawn: " + amount + " New balance is: " + _balance);
                    return successful;
                }
                else
                {
                    Console.WriteLine("Inadequate funds in your account to withdraw: " + amount);
                    return unsuccessful;

                }
            }
            else
            {
                Console.WriteLine("You cannot withdraw a negative amount!");
                return unsuccessful;
            }
        }

        public void DoPrint()
        {
            Console.WriteLine("Account Name: " + _name);
            Console.WriteLine("Account Balance: " + _balance);
           
        }

        public String name() 
        { 
            return _name; 
        }  


    }
}
