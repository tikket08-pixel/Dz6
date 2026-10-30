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

        public int GetNumber() { return _number; }
        public void SetNumber(int number) { _number = number; }

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
            Console.WriteLine(" Упражнение 7.1: Класс \"Счет в банке\" ");
            Console.WriteLine("Описание: класс с закрытыми полями (номер, баланс, тип),");
            Console.WriteLine("методы заполнения (Set...) и чтения (Get...) полей,");
            Console.WriteLine("вывод информации об объекте на печать.");
            Console.WriteLine("Действий не требуется — программа работает сама.");
            Console.WriteLine();

            BankAccount acc = new BankAccount();

            acc.SetNumber(1001);
            acc.SetBalance(1500);
            acc.SetType(AccountType.Savings);
            acc.Print();

            Console.WriteLine();
            Console.WriteLine("Проверка защиты: попробуем задать отрицательный баланс.");
            acc.SetBalance(-100);
            acc.Print();

            Console.WriteLine();
            Console.WriteLine("Чтение полей через Get-методы:");
            Console.WriteLine("Номер: " + acc.GetNumber());
            Console.WriteLine("Баланс: " + acc.GetBalance());
            Console.WriteLine("Тип: " + acc.GetType());

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}    