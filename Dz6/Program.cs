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

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма пополнения должна быть больше нуля. Операция отменена.");
                return;
            }
            _balance = _balance + amount;
            Console.WriteLine("Положено " + amount + ". Новый баланс: " + _balance);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма снятия должна быть больше нуля. Операция отменена.");
                return;
            }
            if (amount > _balance)
            {
                Console.WriteLine("Недостаточно средств: запрошено " + amount +
                                  ", на счете " + _balance + ". Операция отменена.");
                return;
            }
            _balance = _balance - amount;
            Console.WriteLine("Снято " + amount + ". Новый баланс: " + _balance);
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
            Console.WriteLine("Задача 7.3. Класс \"Счет в банке\" с методами Deposit и Withdraw.");
            Console.WriteLine("Номер счета генерируется автоматически (из 7.2).");
            Console.WriteLine("Withdraw проверяет, хватает ли средств, и только тогда меняет баланс.");
            Console.WriteLine("Действий не требуется — программа работает сама.");
            Console.WriteLine();

            BankAccount acc = new BankAccount(1000, AccountType.Current);
            Console.WriteLine("Создан счет:");
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Пополнение на 500:");
            acc.Deposit(500);
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Снятие 300:");
            acc.Withdraw(300);
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Попытка снять 5000 (больше баланса):");
            acc.Withdraw(5000);
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Попытка снять -100 (некорректная сумма):");
            acc.Withdraw(-100);
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Попытка положить 0 (некорректная сумма):");
            acc.Deposit(0);
            acc.Print();
            Console.WriteLine();

            Console.WriteLine("Второй счет, чтобы показать что генерация номера работает:");
            BankAccount acc2 = new BankAccount(200, AccountType.Savings);
            acc2.Print();

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}