using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadLockSituation
{
    public class Account
    {
        public double _balance;
        public int _id;
        public Account(int id, double balance)
        {
            this._id = id;
            this._balance = balance;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }
    }

    public class AccountManager
    {
        Account _fromAccount;
        Account _toAccount;
        double _amountToTransfer;
        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            this._amountToTransfer = amountToTransfer;
        }

        public void Transfer()
        {
            object _lock1, _lock2;
            if(_fromAccount._id < _toAccount._id)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }

            Console.WriteLine(Thread.CurrentThread.Name+" trying to acquire lock on "+ (_lock1 as Account)._id);
            lock(_lock1)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " acquired lock on " + (_lock1 as Account)._id);
                Console.WriteLine(Thread.CurrentThread.Name + " suspended for 1 second");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + " is back in action and trying to acquire lock on " + (_lock2 as Account)._id);
                lock (_lock2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " acquired lock on " + (_lock2 as Account)._id);
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);
                    Console.WriteLine(Thread.CurrentThread.Name +" transferred "+_amountToTransfer+" from "+_fromAccount._id+" to "+_toAccount._id);
                }
                Console.WriteLine(Thread.CurrentThread.Name + " released lock on " + (_lock2 as Account)._id);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " released lock on " + (_lock1 as Account)._id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");
            Account _accountA = new Account(101, 5000);
            Account _accountB = new Account(102, 3000);

            AccountManager _accountManagerA = new AccountManager(_accountA, _accountB, 1000);
            AccountManager _accountManagerB = new AccountManager(_accountB, _accountA, 2000);

            Thread t1 = new Thread(_accountManagerA.Transfer);
            t1.Name = "T1";

            Thread t2 = new Thread(_accountManagerB.Transfer);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Main Completed");
            Console.ReadKey();
        }
    }
}
