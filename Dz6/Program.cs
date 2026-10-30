using System;

namespace Task7_1
{
    enum AccountType
    {
        Current,
        Savings
    }

    class BankAccount
    {
        private int _number;
        private decimal _balance;
        private AccountType _type;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

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

        public void Print()
        {
            Console.WriteLine("Счет #" + _number + ", тип: " + _type + ", баланс: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Упражнение 7.1: Класс \"Счет в банке\" ");
            Console.WriteLine("Описание: класс с закрытыми полями (номер, баланс, тип),");
            Console.WriteLine("свойства для чтения и записи, вывод информации об объекте.");
            Console.WriteLine();

            BankAccount acc = new BankAccount();
            acc.Number = 1001;
            acc.Balance = 1500;
            acc.Type = AccountType.Savings;
            acc.Print();

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}