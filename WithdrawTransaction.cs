using System;

namespace Task5._2
{

    internal class WithdrawTransaction
    {
        Account _account;
        decimal _amount;
        bool _executed;
        bool _success;
        bool _reversed;

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
            
        }

        public void Print()
        {
            Console.WriteLine("Executed: " + _executed);
            Console.WriteLine("Success: " + _success);
            Console.WriteLine("Reversed: " + _reversed);

        }

        public void Execute()
        {
            if (_executed == false)
            {
                _executed = true;
                _success = _account.Withdrawal(_amount);
            }
            else
            {
                Console.WriteLine(new ArgumentException("Withdrawal already executed"));
                Console.WriteLine();
            }
        }

        public void RollBack()
        {
            if (_success)
            {
                if (!_reversed)
                {
                    _reversed = _account.Withdrawal(_amount);
                }
                else
                {
                    Console.WriteLine(new ArgumentException("Transaction already reversed"));
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine(new ArgumentException("Reverse transaction failed, withdraw was unsuccesfull"));
                Console.WriteLine();
            }
        }
    }
}
   
