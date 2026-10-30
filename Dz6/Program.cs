using System;
using System.Collections.Generic;

namespace Task7_Homework
{
    class Building
    {
        private static int _lastId = 0;
        private int _id;
        private double _height;
        private int _floors;
        private int _apartments;
        private int _entrances;

        public Building()
        {
            _id = GenerateId();
        }

        public Building(double height, int floors, int apartments, int entrances)
        {
            _id = GenerateId();
            SetHeight(height);
            SetFloors(floors);
            SetApartments(apartments);
            SetEntrances(entrances);
        }

        private static int GenerateId()
        {
            _lastId++;
            return _lastId;
        }

        public int GetId() { return _id; }

        public double GetHeight() { return _height; }
        public void SetHeight(double height)
        {
            if (height <= 0)
            {
                Console.WriteLine("Высота должна быть > 0, значение не изменено.");
                return;
            }
            _height = height;
        }

        public int GetFloors() { return _floors; }
        public void SetFloors(int floors)
        {
            if (floors <= 0)
            {
                Console.WriteLine("Этажность должна быть > 0, значение не изменено.");
                return;
            }
            _floors = floors;
        }

        public int GetApartments() { return _apartments; }
        public void SetApartments(int apartments)
        {
            if (apartments < 0)
            {
                Console.WriteLine("Количество квартир не может быть отрицательным, значение не изменено.");
                return;
            }
            _apartments = apartments;
        }

        public int GetEntrances() { return _entrances; }
        public void SetEntrances(int entrances)
        {
            if (entrances <= 0)
            {
                Console.WriteLine("Количество подъездов должно быть > 0, значение не изменено.");
                return;
            }
            _entrances = entrances;
        }

        public double FloorHeight()
        {
            if (_floors <= 0) return 0;
            return _height / _floors;
        }

        public double ApartmentsPerEntrance()
        {
            if (_entrances <= 0) return 0;
            return (double)_apartments / _entrances;
        }

        public double ApartmentsPerFloor()
        {
            if (_floors <= 0) return 0;
            return (double)_apartments / _floors;
        }

        public void Print()
        {
            Console.WriteLine("Здание #" + _id +
                ": высота " + _height +
                " м, этажей " + _floors +
                ", квартир " + _apartments +
                ", подъездов " + _entrances);
            Console.WriteLine("  высота этажа: " + FloorHeight().ToString("0.00") + " м");
            Console.WriteLine("  квартир в подъезде: " + ApartmentsPerEntrance());
            Console.WriteLine("  квартир на этаже: " + ApartmentsPerFloor());
        }
    }

    abstract class Transport
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public double ParkingHours { get; set; }
        public bool IsParked { get; private set; }

        protected Transport() { }

        protected Transport(string brand, string color, string number, double hours)
        {
            Brand = brand;
            Color = color;
            Number = number;
            ParkingHours = hours;
        }

        public void Park()
        {
            IsParked = true;
            Console.WriteLine(Brand + " (" + Number + ") припаркован.");
        }

        public void Leave()
        {
            IsParked = false;
            Console.WriteLine(Brand + " (" + Number + ") выехал с парковки.");
        }

        public abstract decimal CalculateFee();
        public abstract bool CheckDimensions();
        public abstract string GetTransportType();

        public virtual void ShowInfo()
        {
            Console.WriteLine("[" + GetTransportType() + "] марка: " + Brand +
                ", цвет: " + Color +
                ", номер: " + Number +
                ", часов: " + ParkingHours +
                ", на стоянке: " + (IsParked ? "да" : "нет"));
        }

        public static void ShowByType(List<Transport> list, string typeName)
        {
            Console.WriteLine("--- Список по типу: " + typeName + " ---");
            int found = 0;
            foreach (Transport t in list)
            {
                if (t.GetTransportType() == typeName)
                {
                    t.ShowInfo();
                    found++;
                }
            }
            if (found == 0) Console.WriteLine("  (таких нет)");
        }
    }

    class Car : Transport
    {
        public int Doors { get; set; }

        public Car() : base()
        {
            Doors = 4;
        }

        public Car(string brand, string color, string number, double hours, int doors)
            : base(brand, color, number, hours)
        {
            Doors = doors;
        }

        public override decimal CalculateFee() { return (decimal)ParkingHours * 100m; }
        public override bool CheckDimensions() { return true; }
        public override string GetTransportType() { return "Легковой авто"; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("    дверей: " + Doors);
        }

        public void Honk() { Console.WriteLine("  Бип-бип!"); }
        public void StartEngine() { Console.WriteLine("  Двигатель запущен."); }
    }

    class Motorcycle : Transport
    {
        public bool HasSidecar { get; set; }

        public Motorcycle() : base()
        {
            HasSidecar = false;
        }

        public Motorcycle(string brand, string color, string number, double hours, bool hasSidecar)
            : base(brand, color, number, hours)
        {
            HasSidecar = hasSidecar;
        }

        public override decimal CalculateFee() { return (decimal)ParkingHours * 50m; }
        public override bool CheckDimensions() { return true; }
        public override string GetTransportType() { return "Мотоцикл"; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("    коляска: " + (HasSidecar ? "есть" : "нет"));
        }

        public void RingBell() { Console.WriteLine("  Дзынь-дзынь!"); }
        public void Wheelie() { Console.WriteLine("  Мотоцикл на заднем колесе!"); }
    }

    class Truck : Transport
    {
        public double LoadCapacity { get; set; }
        public double LengthMeters { get; set; }

        public Truck() : base()
        {
            LoadCapacity = 0;
            LengthMeters = 0;
        }

        public Truck(string brand, string color, string number, double hours,
                     double capacity, double length)
            : base(brand, color, number, hours)
        {
            LoadCapacity = capacity;
            LengthMeters = length;
        }

        public override decimal CalculateFee() { return (decimal)ParkingHours * 200m; }
        public override bool CheckDimensions() { return LengthMeters <= 6.0; }
        public override string GetTransportType() { return "Грузовик"; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("    грузоподъёмность: " + LoadCapacity +
                              " т, длина: " + LengthMeters + " м");
        }

        public void LoadCargo(double tons)   { Console.WriteLine("  Загружено " + tons + " тонн."); }
        public void UnloadCargo(double tons) { Console.WriteLine("  Выгружено " + tons + " тонн."); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача ДЗ 7.1. Класс \"Здание\".");
            Console.WriteLine("Поля закрыты, доступ через методы Get/Set, номер здания генерируется");
            Console.WriteLine("автоматически, есть расчёты высоты этажа и квартир.");
            Console.WriteLine("Действий не требуется — данные прописаны в коде.");
            Console.WriteLine();

            Building b1 = new Building(30, 10, 100, 4);
            b1.Print();
            Console.WriteLine();

            Building b2 = new Building();
            b2.SetHeight(15);
            b2.SetFloors(5);
            b2.SetApartments(40);
            b2.SetEntrances(2);
            b2.Print();
            Console.WriteLine();

            Building b3 = new Building(50, 20, 200, 5);
            b3.Print();
            Console.WriteLine();

            Console.WriteLine("Проверка защиты (отрицательные значения):");
            Building b4 = new Building();
            b4.SetHeight(-10);
            b4.SetEntrances(0);
            b4.SetFloors(1);
            b4.SetHeight(10);
            b4.SetApartments(10);
            b4.SetEntrances(1);
            b4.Print();
            Console.WriteLine();

            Console.WriteLine("Задача. Транспорт на парковке.");
            Console.WriteLine("Абстрактный класс Transport, наследники Car, Motorcycle, Truck.");
            Console.WriteLine("Свойства: марка, цвет, номер. Методы: припарковать, выехать,");
            Console.WriteLine("рассчитать плату, проверить габариты, показать список по типу.");
            Console.WriteLine("Тарифы: Легковой 100/ч, Мотоцикл 50/ч, Грузовик 200/ч.");
            Console.WriteLine("Габариты грузовика: до 6 м.");
            Console.WriteLine("Действий не требуется — данные прописаны в коде.");
            Console.WriteLine();

            List<Transport> parking = new List<Transport>();

            Car car1 = new Car("Toyota", "Красный", "А123БВ", 3, 4);
            Car car2 = new Car("Lada", "Синий", "Е456ЖЗ", 1.5, 4);
            Motorcycle moto1 = new Motorcycle("Yamaha", "Чёрный", "М789НО", 2, false);
            Motorcycle moto2 = new Motorcycle("Ural", "Зелёный", "Н321РС", 4, true);
            Truck truck1 = new Truck("Volvo", "Белый", "Т012УФ", 5, 20, 8.5);
            Truck truck2 = new Truck("Kamaz", "Оранжевый", "Х345ЦЧ", 4, 15, 5.5);

            parking.Add(car1);
            parking.Add(car2);
            parking.Add(moto1);
            parking.Add(moto2);
            parking.Add(truck1);
            parking.Add(truck2);

            Console.WriteLine("--- Работа с каждым транспортом ---");
            foreach (Transport t in parking)
            {
                t.ShowInfo();
                t.Park();
                if (t.CheckDimensions())
                    Console.WriteLine("  Габариты в норме.");
                else
                    Console.WriteLine("  ВНИМАНИЕ: габариты превышают допустимые!");
                Console.WriteLine("  Плата за стоянку: " + t.CalculateFee() + " руб.");
                t.Leave();
                Console.WriteLine();
            }

            Console.WriteLine("--- Особые методы наследников ---");
            car1.Honk();
            car1.StartEngine();
            moto1.RingBell();
            moto1.Wheelie();
            truck1.LoadCargo(10);
            truck1.UnloadCargo(10);
            Console.WriteLine();

            Console.WriteLine("--- Списки по типу ---");
            Transport.ShowByType(parking, "Легковой авто");
            Console.WriteLine();
            Transport.ShowByType(parking, "Мотоцикл");
            Console.WriteLine();
            Transport.ShowByType(parking, "Грузовик");
            Console.WriteLine();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}