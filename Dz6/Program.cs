using System;

namespace Task7_3
{
    enum AccountType
    {
        Current,
        Savings
    }

    class BankAccount
    {
        private static int _lastNumber = 1000;
        private int _number;
        private decimal _balance;
        private AccountType _type;

        public int Number { get { return _number; } }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0) throw new ArgumentException("Баланс < 0");
                _balance = value;
            }
        }

        public AccountType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public BankAccount()
        {
            _number = GenerateNumber();
            _balance = 0;
            _type = AccountType.Savings;
        }

        public BankAccount(decimal balance, AccountType type)
        {
            _number = GenerateNumber();
            _balance = balance;
            _type = type;
        }

        private static int GenerateNumber()
        {
            return ++_lastNumber;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) { Console.WriteLine("Сумма должна быть > 0"); return; }
            _balance += amount;
            Console.WriteLine("Положено " + amount + ". Баланс: " + _balance);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) { Console.WriteLine("Сумма должна быть > 0"); return; }
            if (amount > _balance) { Console.WriteLine("Недостаточно средств"); return; }
            _balance -= amount;
            Console.WriteLine("Снято " + amount + ". Баланс: " + _balance);
        }

        public void Print()
        {
            Console.WriteLine("Счет #" + _number + ", тип: " + _type + ", баланс: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Упражнение 7.3: Снятие и пополнение счета ===");
            Console.WriteLine("Описание: методы Deposit и Withdraw с проверками суммы.");
            Console.WriteLine();

            BankAccount acc = new BankAccount(1000, AccountType.Current);
            acc.Print();

            acc.Deposit(500);
            acc.Withdraw(300);
            acc.Withdraw(5000);

            acc.Print();

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}