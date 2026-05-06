using System;

 namespace BankAccountManagementSystem
{
    class BankAccount
    {
        private String _accNo;
        private double _balance; 


        public String AccountNumber
        {
            get { return _accNo; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public BankAccount(String accNo, double balance)
        {
            _accNo = accNo;
            _balance = balance;
        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Deposit Amount");
                return;
            }

            _balance += amount;
            Console.WriteLine($"Current Balance is : {_balance}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Withdraw Amount");
                return ;
            }
            if(amount > _balance)
            {
                Console.WriteLine("Insufficient Amount");
                return;
            }

            _balance -= amount;
            Console.WriteLine($"After Withdrawal the Balance is : {_balance}");
        }

        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("1233456",350);
            bankAccount.Deposit(100);
            bankAccount.Withdraw(300);
            Console.ReadLine();
        }
    }
}