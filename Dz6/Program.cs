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

        public BankAccount()
        {
            _number = GenerateNumber();
            _balance = 0;
            _type = AccountType.Savings;
        }

        public BankAccount(decimal balance, AccountType type)
        {
            _number = GenerateNumber();
            SetBalance(balance);
            _type = type;
        }

        private static int GenerateNumber()
        {
            _lastNumber++;
            return _lastNumber;
        }

        public int GetNumber() { return _number; }

        public decimal GetBalance() { return _balance; }
        public void SetBalance(decimal balance)
        {
            if (balance < 0)
            {
                Console.WriteLine("Баланс не может быть отрицательным, значение не изменено.");
                return;
            }
            _balance = balance;
        }

        public AccountType GetType() { return _type; }
        public void SetType(AccountType type) { _type = type; }

        public void Print()
        {
            Console.WriteLine("Счет #" + _number + ", тип: " + _type + ", баланс: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 7.2. Класс \"Счет в банке\" с автогенерацией номера.");
            Console.WriteLine("Номер счета создаётся автоматически статическим методом и уникален.");
            Console.WriteLine("Действий не требуется — программа работает сама.");
            Console.WriteLine();

            Console.WriteLine("Создаём 3 счета разными конструкторами:");
            BankAccount acc1 = new BankAccount();
            acc1.SetBalance(1000);
            acc1.SetType(AccountType.Savings);
            acc1.Print();

            BankAccount acc2 = new BankAccount(500, AccountType.Current);
            acc2.Print();

            BankAccount acc3 = new BankAccount(2000, AccountType.Savings);
            acc3.Print();

            Console.WriteLine();
            Console.WriteLine("Проверка уникальности — создаём ещё 3 счета:");
            BankAccount acc4 = new BankAccount();
            BankAccount acc5 = new BankAccount(100, AccountType.Current);
            BankAccount acc6 = new BankAccount(300, AccountType.Savings);
            acc4.Print();
            acc5.Print();
            acc6.Print();

            Console.WriteLine();
            Console.WriteLine("Чтение номера через GetNumber():");
            Console.WriteLine("acc1.Number = " + acc1.GetNumber());
            Console.WriteLine("acc4.Number = " + acc4.GetNumber());
            Console.WriteLine("acc6.Number = " + acc6.GetNumber());

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
} 