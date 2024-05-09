using System;

namespace Task5._2
{
    /// <summary>
    /// Prototype for a deposit transaction
    /// </summary>
    internal class DepositeTransaction
    {
        Account _account;
        decimal _amount;
        bool _executed;
        public bool _success;
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

        public DepositeTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void Print()
        {
            Console.WriteLine("Amount: " + _amount);
            Console.WriteLine("Executed: " + _executed);
            Console.WriteLine("Success: " + _success);
            Console.WriteLine("Reversed: " + _reversed);

        }

        public void Execute()
        {
            if (!_executed)
            {
                _executed = true;
                _success = _account.Deposit(_amount);

            }
            else
            {
                Console.WriteLine(new ArgumentException("Deposit transaction already executed"));
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
                    Console.WriteLine(new ArgumentException("Transaction already been reversed"));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(new ArgumentException("Reverse was unsuccessful, deposite cannot be done"));
                Console.WriteLine();
            }
        }

    }
}
