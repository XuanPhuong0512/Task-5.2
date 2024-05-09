using System;
using System.Collections.Generic;
using System.Diagnostics;
using Task5._2;

namespace bankSystem
{

        enum menuOption
        {
            Withdraw,
            Deposit,
            Transfer,
            Print,
            Quit
        };

    class program
    {
        static void DoDeposit(Account account)
        {
            decimal depositAmount;
            Console.WriteLine("Enter the deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out depositAmount)) 
            {
                DepositeTransaction depositeTransaction = new DepositeTransaction(account, depositAmount);
                depositeTransaction.Execute();
                depositeTransaction.Print();
            }
            else 
            {
                Console.WriteLine("Invalid input. Please enter a valid number: ");
            }
        }

        static void DoWithdraw(Account account)
        {
            decimal withdrawAmount;
            Console.WriteLine("Enter withdraw amount: ");
            if (decimal.TryParse (Console.ReadLine(), out withdrawAmount))
            {
                WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, withdrawAmount);
                withdrawTransaction.Execute();
                withdrawTransaction.Print();

            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number: ");
            }
        }

        static void DoTransfer(Account fromAccount, Account toAccount)
        {
            decimal transferAmount;
            Console.WriteLine("Enter transfer amount: ");
            if (decimal.TryParse(Console.ReadLine(), out transferAmount))
            {
                TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, transferAmount);
                transferTransaction.Execute();
                transferTransaction.Print();

            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number: ");

            }

            TransferTransaction transac = new TransferTransaction(fromAccount, toAccount, transferAmount);
            transac.Execute();
        }

        static void Print(Account account)
        {
            account.DoPrint();
        }

        static void Main(string[] args)
        {
            Account kevinSaving = new Account("Kevin's Saving", 1000);
            Account myAcc = new Account("are", 0);

            static menuOption ReadUserOption()
            {
                int option;
                bool validOption = false;
                do
                {
                    Console.WriteLine("Select an option: ");
                    Console.WriteLine("1. Withdraw");
                    Console.WriteLine("2. Deposite");
                    Console.WriteLine("3. Transfer");
                    Console.WriteLine("4. Print");
                    Console.WriteLine("5. Quit");

                    Console.WriteLine("Enter a number: ");

                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        if  (Enum.IsDefined(typeof(menuOption), option - 1)) 
                        {
                            return (menuOption)(option - 1);
                        
                        }
                    }

                    Console.WriteLine("Invalid choice. Please enter a valid option.");

                } while (!validOption);

                return menuOption.Quit;
            }

            bool continueMenu = true;

            while (continueMenu)
            {
                menuOption selectOption = ReadUserOption();

                switch (selectOption)
                {
                    case menuOption.Deposit:
                        Console.WriteLine("Selected Deposit");
                        DoDeposit(myAcc);
                        break;

                    case menuOption.Withdraw:
                        Console.WriteLine("Selected Withdraw");
                        DoWithdraw(myAcc);
                        break;
                    
                    case menuOption.Transfer:
                        Console.WriteLine("Selected Transfer");
                        DoTransfer(myAcc, kevinSaving);
                        break;

                    case menuOption.Print:
                        Console.WriteLine("Selected Print");
                        Print(myAcc);
                        break;

                    case menuOption.Quit:
                        Console.WriteLine("Quitting, Thank you");
                        continueMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please Try again.");
                        break;
                }
            }
        }

    }



}
