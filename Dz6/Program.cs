using System;

namespace Task7_2
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

        public void Print()
        {
            Console.WriteLine("Счет #" + _number + ", тип: " + _type + ", баланс: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Упражнение 7.2: Автогенерация номера счета ");
            Console.WriteLine("Описание: номер счета уникален и генерируется автоматически");
            Console.WriteLine("через статическое поле и статический метод.");
            Console.WriteLine();

            BankAccount acc1 = new BankAccount();
            acc1.Balance = 1000;
            acc1.Type = AccountType.Savings;
            acc1.Print();

            BankAccount acc2 = new BankAccount(500, AccountType.Current);
            acc2.Print();

            BankAccount acc3 = new BankAccount(2000, AccountType.Savings);
            acc3.Print();

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}