using System;
using System.Collections.Generic;

namespace Lab4_Classes_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №4: Классы (ООП)");
                Console.WriteLine("Выберите вариант для выполнения:");
                Console.WriteLine(" 1  - Телефон (звонки, СМС, номер)");
                Console.WriteLine(" 2  - Человек (движение, речь, добавление)");
                Console.WriteLine(" 3  - Матрица (сложение, умножение на скаляр)");
                Console.WriteLine(" 4  - Читатель библиотеки (взять/вернуть книгу)");
                Console.WriteLine(" 5  - Кафель (параметры плитки)");
                Console.WriteLine(" 6  - Дети (ввод и вывод данных)");
                Console.WriteLine(" 7  - Куб (свойства, объём, площадь грани)");
                Console.WriteLine(" 8  - Счётчик (инкремент, декремент, лимиты)");
                Console.WriteLine(" 9  - Время (установка, добавление, валидация)");
                Console.WriteLine(" 10 - Треугольник (периметр, площадь, медианы)");
                Console.WriteLine(" 11 - Студенты (фильтрация по группе)");
                Console.WriteLine(" 12 - Компьютерное железо (сборки, добавление)");
                Console.WriteLine(" 13 - Бегун (шаги, дистанция, калории)");
                Console.WriteLine(" 14 - Пирамида (объём, площадь поверхности)");
                Console.WriteLine(" 0  - Выход из программы");
                Console.Write("\nВаш выбор: ");

                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("\nОшибка: введите число от 0 до 14.");
                    WaitForKey();
                    continue;
                }

                if (choice == 0) { isRunning = false; continue; }
                if (choice < 1 || choice > 14)
                {
                    Console.WriteLine("\nОшибка: вариант должен быть от 1 до 14.");
                    WaitForKey();
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Выполнение варианта {choice}\n");

                try
                {
                    switch (choice)
                    {
                        case 1: RunTask1(); break;
                        case 2: RunTask2(); break;
                        case 3: RunTask3(); break;
                        case 4: RunTask4(); break;
                        case 5: RunTask5(); break;
                        case 6: RunTask6(); break;
                        case 7: RunTask7(); break;
                        case 8: RunTask8(); break;
                        case 9: RunTask9(); break;
                        case 10: RunTask10(); break;
                        case 11: RunTask11(); break;
                        case 12: RunTask12(); break;
                        case 13: RunTask13(); break;
                        case 14: RunTask14(); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }

                WaitForKey();
            }

            Console.WriteLine("\nПрограмма завершена");
        }

        static void RunTask1()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone("+79001112233", "iPhone 14", 172),
                new Phone("+79004445566", "Samsung S23", 168),
                new Phone("+79007778899", "Xiaomi 13", 180)
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ГЛАВНОЕ МЕНЮ");
                for (int i = 0; i < phones.Count; i++)
                    Console.WriteLine($"{i + 1}. {phones[i]}");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите телефон: ");
                string inp = Console.ReadLine();
                if (inp == "0") break;

                int idx;
                if (!int.TryParse(inp, out idx) || idx < 1 || idx > phones.Count)
                {
                    Console.WriteLine("Неверный выбор.");
                    Console.ReadLine();
                    continue;
                }

                Phone selected = phones[idx - 1];
                PhoneSubMenu(selected);
            }
        }

        static void PhoneSubMenu(Phone phone)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nВыбран: {phone}");
                Console.WriteLine("1. Принять звонок\n2. Узнать номер\n3. Отправить СМС\n0. Назад");
                Console.Write("Действие: ");
                string act = Console.ReadLine();

                switch (act)
                {
                    case "1":
                        Console.Write("Имя звонящего: ");
                        phone.receiveCall(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine($"Номер: {phone.getNumber()}");
                        break;
                    case "3":
                        Console.Write("Номера через пробел: ");
                        string line = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            phone.sendMessage(nums);
                        }
                        else
                        {
                            Console.WriteLine("Список пуст.");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
                Console.ReadLine();
            }
        }

        static void RunTask2()
        {
            List<Person> people = new List<Person> { new Person(), new Person("Иванов Иван", 25) };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("СПИСОК ЛЮДЕЙ");
                for (int i = 0; i < people.Count; i++) Console.WriteLine($"{i + 1}. {people[i]}");
                Console.WriteLine("3. Добавить\n0. Выход");
                Console.Write("Выберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "3")
                {
                    Console.Write("ФИО: "); string n = Console.ReadLine();
                    Console.Write("Возраст: "); int a; int.TryParse(Console.ReadLine(), out a);
                    people.Add(new Person(n, a));
                }
                else
                {
                    int idx;
                    if (int.TryParse(c, out idx) && idx >= 1 && idx <= people.Count)
                    {
                        Console.WriteLine("\n1. move()  2. talk()  0. Назад");
                        Console.Write("Действие: ");
                        string act = Console.ReadLine();
                        if (act == "1") people[idx - 1].move();
                        else if (act == "2") people[idx - 1].talk();
                    }
                }
                Console.ReadLine();
            }
        }

        static void RunTask3()
        {
            Matrix m1 = new Matrix(2, 2), m2 = new Matrix(2, 2);
            m1.FillRandom(new Random()); m2.FillRandom(new Random());
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Показать A  2. Показать B  3. A+B  4. A*число  0. Выход");
                Console.Write("Выберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "1") m1.Print("Матрица A");
                else if (c == "2") m2.Print("Матрица B");
                else if (c == "3") m1.Add(m2).Print("A+B");
                else if (c == "4")
                {
                    Console.Write("Множитель: "); double k; double.TryParse(Console.ReadLine(), out k);
                    m1.MulScalar(k).Print("A*" + k);
                }
                Console.ReadLine();
            }
        }

        static void RunTask4()
        {
            List<Reader> readers = new List<Reader>
            {
                new Reader { fullName="Петров В.В.", ticketNumber="Б-101", faculty="ИТ", birthDate="15.05.2000", phone="+79001112233" },
                new Reader { fullName="Сидорова А.А.", ticketNumber="Б-102", faculty="Эконом", birthDate="22.08.1999", phone="+79004445566" },
                new Reader { fullName="Козлов Д.С.", ticketNumber="Б-103", faculty="Юрид", birthDate="10.01.2001", phone="+79007778899" }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ЧИТАТЕЛИ БИБЛИОТЕКИ");
                for (int i = 0; i < readers.Count; i++) Console.WriteLine($"{i + 1}. {readers[i].fullName} (билет {readers[i].ticketNumber})");
                Console.WriteLine("\n0. Выход");
                Console.Write("Выберите читателя: ");
                string c = Console.ReadLine();
                if (c == "0") break;

                int idx;
                if (int.TryParse(c, out idx) && idx >= 1 && idx <= readers.Count)
                {
                    Reader r = readers[idx - 1];
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"{r.fullName}\nБилет: {r.ticketNumber}\nФакультет: {r.faculty}\nДата рождения: {r.birthDate}\nТелефон: {r.phone}");
                        Console.WriteLine("\n1. Взять книгу\n2. Вернуть книгу\n0. Назад");
                        Console.Write("Действие: ");
                        string act = Console.ReadLine();
                        if (act == "0") break;
                        if (act == "1" || act == "2")
                        {
                            Console.Write("Название книги: "); string book = Console.ReadLine();
                            if (act == "1") r.takeBook(book); else r.returnBook(book);
                        }
                        Console.ReadLine();
                    }
                }
                else { Console.WriteLine("Неверный выбор."); Console.ReadLine(); }
            }
        }

        static void RunTask5()
        {
            List<Tiles> tiles = new List<Tiles>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("КАФЕЛЬ");
                for (int i = 0; i < tiles.Count; i++) Console.WriteLine($"{i + 1}. {tiles[i].brand}");
                Console.WriteLine("3. Добавить  0. Выход");
                Console.Write("Выберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "3")
                {
                    Tiles t = new Tiles();
                    Console.Write("Бренд: "); t.brand = Console.ReadLine();
                    Console.Write("Высота(см): "); double.TryParse(Console.ReadLine(), out t.size_h);
                    Console.Write("Ширина(см): "); double.TryParse(Console.ReadLine(), out t.size_w);
                    Console.Write("Цена(руб): "); double.TryParse(Console.ReadLine(), out t.price);
                    tiles.Add(t);
                }
                else
                {
                    int i;
                    if (int.TryParse(c, out i) && i >= 1 && i <= tiles.Count) tiles[i - 1].getData();
                }
                Console.ReadLine();
            }
        }

        static void RunTask6()
        {
            List<Children> children = new List<Children>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ДЕТИ");
                for (int i = 0; i < children.Count; i++) Console.WriteLine($"{i + 1}. [Данные скрыты]");
                Console.WriteLine("3. Добавить  0. Выход");
                Console.Write("Выберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "3") { Children ch = new Children(); ch.InputData(); children.Add(ch); }
                else
                {
                    int i;
                    if (int.TryParse(c, out i) && i >= 1 && i <= children.Count) children[i - 1].DisplayData();
                }
                Console.ReadLine();
            }
        }

        static void RunTask7()
        {
            Cube cube = new Cube();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("КУБ");
                Console.WriteLine(cube.State);
                Console.WriteLine("1. Изменить сторону  0. Выход");
                Console.Write("Действие: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "1") { Console.Write("Новая сторона: "); double v; if (double.TryParse(Console.ReadLine(), out v)) cube.Side = v; }
                Console.ReadLine();
            }
        }

        static void RunTask8()
        {
            Console.Write("Минимум: "); int mn; int.TryParse(Console.ReadLine(), out mn);
            Console.Write("Максимум: "); int mx; int.TryParse(Console.ReadLine(), out mx);
            Console.Write("Начало: "); int st; int.TryParse(Console.ReadLine(), out st);
            Counter counter = new Counter(mn, mx, st);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Счётчик: {counter.Value} [{mn}...{mx}]");
                Console.WriteLine("1. +1  2. -1  3. Сброс  0. Выход");
                Console.Write("Действие: ");
                string act = Console.ReadLine();
                if (act == "0") break;
                if (act == "1") counter.Increment();
                else if (act == "2") counter.Decrement();
                else if (act == "3") counter = new Counter(mn, mx, mn);
                Console.ReadLine();
            }
        }

        static void RunTask9()
        {
            Time t = new Time(); try { t.Set(12, 0, 0); } catch { }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Текущее время: {t}");
                Console.WriteLine("1. Установить время  2. Добавить время  0. Выход");
                Console.Write("Действие: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                try
                {
                    if (c == "1")
                    {
                        Console.Write("Ч М С (через пробел): ");
                        string[] p = Console.ReadLine().Split(' ');
                        int hh, mm, ss;
                        int.TryParse(p[0], out hh); int.TryParse(p[1], out mm); int.TryParse(p[2], out ss);
                        t.Set(hh, mm, ss);
                    }
                    else if (c == "2")
                    {
                        Console.Write("Добавить Ч М С: ");
                        string[] p = Console.ReadLine().Split(' ');
                        int hh, mm, ss;
                        int.TryParse(p[0], out hh); int.TryParse(p[1], out mm); int.TryParse(p[2], out ss);
                        t.Add(hh, mm, ss);
                    }
                }
                catch { Console.WriteLine("️Ошибка ввода или недопустимое время."); }
                Console.ReadLine();
            }
        }

        static void RunTask10()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ТРЕУГОЛЬНИК\nВведите стороны a, b, c:");
                Console.Write("a = "); string ia = Console.ReadLine();
                Console.Write("b = "); string ib = Console.ReadLine();
                Console.Write("c = "); string ic = Console.ReadLine();
                try
                {
                    double da, db, dc;
                    double.TryParse(ia, out da); double.TryParse(ib, out db); double.TryParse(ic, out dc);
                    Triangle tri = new Triangle(da, db, dc);
                    Console.WriteLine($"\nПериметр: {tri.Perimeter():F2}");
                    Console.WriteLine($"Площадь: {tri.Area():F2}");
                    Console.WriteLine($"Медианы: ma={tri.MedianA():F2}, mb={tri.MedianB():F2}, mc={tri.MedianC():F2}");
                }
                catch (Exception ex) { Console.WriteLine($"\n{ex.Message}"); }
                Console.WriteLine("\n0 - Выход, 1 - Новый треугольник");
                Console.Write("Выбор: "); if (Console.ReadLine() == "0") break;
            }
        }

        static void RunTask11()
        {
            List<Student> students = new List<Student>
            {
                new Student { LastName="Иванов", FirstName="Иван", Group="ИВТ-21", Faculty="ИТ", Course=2, Phone="+79001112233" },
                new Student { LastName="Петров", FirstName="Пётр", Group="ЭК-22", Faculty="Эконом", Course=1, Phone="+79004445566" },
                new Student { LastName="Сидоров", FirstName="Сергей", Group="ИВТ-21", Faculty="ИТ", Course=2, Phone="+79007778899" }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("СТУДЕНТЫ");
                for (int i = 0; i < students.Count; i++) Console.WriteLine($"{i + 1}. {students[i]}");
                Console.WriteLine("3. Показать по группе  0. Выход");
                Console.Write("Выберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "3")
                {
                    Console.Write("Введите номер группы: "); string grp = Console.ReadLine();
                    bool found = false;
                    foreach (var s in students) if (s.Group == grp) { Console.WriteLine(s); found = true; }
                    if (!found) Console.WriteLine($"Студентов в группе {grp} не найдено.");
                }
                Console.ReadLine();
            }
        }

        static void RunTask12()
        {
            List<Hardware> parts = new List<Hardware>
    {
        // GPU
        new Hardware{ Type="GPU", Brand="NVIDIA", Model="RTX 4090", Power=100, Price=150000},
        new Hardware{ Type="GPU", Brand="AMD", Model="RX 7900 XTX", Power=90, Price=100000},
        new Hardware{ Type="GPU", Brand="NVIDIA", Model="RTX 1050 ti", Power=70, Price=10000},
        // CPU
        new Hardware{ Type="CPU", Brand="Intel", Model="Core i9-14900K", Power=95, Price=60000},
        new Hardware{ Type="CPU", Brand="AMD", Model="Ryzen 9 7950X", Power=93, Price=55000},
        new Hardware{ Type="CPU", Brand="Intel", Model="Core i3-12100", Power=60, Price=12000},
        // RAM
        new Hardware{ Type="RAM", Brand="Corsair", Model="DDR5 64GB", Power=85, Price=25000},
        new Hardware{ Type="RAM", Brand="Kingston", Model="DDR5 32GB", Power=70, Price=12000},
        new Hardware{ Type="RAM", Brand="GoodRAM", Model="DDR4 16GB", Power=50, Price=4000},
        // PSU
        new Hardware{ Type="PSU", Brand="Seasonic", Model="Prime TX-1000", Power=80, Price=20000},
        new Hardware{ Type="PSU", Brand="DeepCool", Model="PX1000G", Power=75, Price=12000},
        new Hardware{ Type="PSU", Brand="AeroCool", Model="KCAS-500W", Power=40, Price=3500},
        // Motherboard
        new Hardware{ Type="Motherboard", Brand="ASUS", Model="ROG Maximus Z790", Power=88, Price=45000},
        new Hardware{ Type="Motherboard", Brand="MSI", Model="PRO B650-P", Power=72, Price=15000},
        new Hardware{ Type="Motherboard", Brand="Gigabyte", Model="H610M", Power=50, Price=8000},
        // Cooling
        new Hardware{ Type="Cooling", Brand="Noctua", Model="NH-D15", Power=85, Price=11000},
        new Hardware{ Type="Cooling", Brand="DeepCool", Model="AK620", Power=78, Price=5000},
        new Hardware{ Type="Cooling", Brand="ID-Cooling", Model="SE-214-XT", Power=55, Price=1500}
    };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("КОМПЬЮТЕРНОЕ ЖЕЛЕЗО");
                Console.WriteLine("1. Дорогая сборка (макс. производительность)");
                Console.WriteLine("2. Дешёвая сборка (мин. цена)");
                Console.WriteLine("3. Добавить компонент");
                Console.WriteLine("4. Все компоненты");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "1") ShowPowerfulBuild(parts);
                else if (c == "2") ShowCheapestBuild(parts);
                else if (c == "3") AddComponent(parts);
                else if (c == "4") ShowAllComponents(parts);
                Console.ReadLine();
            }
        }

        static void ShowPowerfulBuild(List<Hardware> parts)
        {
            Console.WriteLine("\nСАМАЯ МОЩНАЯ СБОРКА");
            string[] types = { "GPU", "CPU", "RAM", "PSU", "Motherboard", "Cooling" };
            double totalPower = 0, totalPrice = 0;

            foreach (string type in types)
            {
                Hardware best = null;
                int maxPower = -1;

                foreach (var h in parts)
                {
                    if (h.Type == type && h.Power > maxPower)
                    {
                        maxPower = h.Power;
                        best = h;
                    }
                }

                if (best != null)
                {
                    Console.WriteLine($"{type}: {best.Brand} {best.Model}");
                    Console.WriteLine($"  Мощность: {best.Power}, Цена: {best.Price} руб.");
                    totalPower += best.Power;
                    totalPrice += best.Price;
                }
            }
            Console.WriteLine($"\nИТОГО: Мощность={totalPower}, Цена={totalPrice} руб.");
        }

        static void ShowCheapestBuild(List<Hardware> parts)
        {
            Console.WriteLine("\nСАМАЯ ДЁШЕВАЯ СБОРКА");
            string[] types = { "GPU", "CPU", "RAM", "PSU", "Motherboard", "Cooling" };
            double totalPrice = 0;

            foreach (string type in types)
            {
                Hardware cheapest = null;
                double minPrice = double.MaxValue;

                foreach (var h in parts)
                {
                    if (h.Type == type && h.Price < minPrice)
                    {
                        minPrice = h.Price;
                        cheapest = h;
                    }
                }

                if (cheapest != null)
                {
                    Console.WriteLine($"{type}: {cheapest.Brand} {cheapest.Model}");
                    Console.WriteLine($"  Мощность: {cheapest.Power}, Цена: {cheapest.Price} руб.");
                    totalPrice += cheapest.Price;
                }
            }
            Console.WriteLine($"\nИТОГО: Цена={totalPrice} руб.");
        }

        static void AddComponent(List<Hardware> parts)
        {
            Hardware h = new Hardware();
            Console.Write("Тип (GPU/CPU/RAM/PSU/Motherboard/Cooling): ");
            h.Type = Console.ReadLine();
            Console.Write("Бренд: ");
            h.Brand = Console.ReadLine();
            Console.Write("Модель: ");
            h.Model = Console.ReadLine();
            Console.Write("Мощность: ");
            int.TryParse(Console.ReadLine(), out h.Power);
            Console.Write("Цена: ");
            double.TryParse(Console.ReadLine(), out h.Price);
            parts.Add(h);
            Console.WriteLine("✓ Добавлен!");
        }

        static void ShowAllComponents(List<Hardware> parts)
        {
            Console.WriteLine("\nВСЕ КОМПОНЕНТЫ");
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. [{parts[i].Type}] {parts[i].Brand} {parts[i].Model} | P:{parts[i].Power} ₽:{parts[i].Price}");
            }
        }

        static void RunTask13()
        {
            Runner r = new Runner();
            Console.Write("Имя бегуна: "); r.Name = Console.ReadLine();
            Console.Write("Рост(см): "); double.TryParse(Console.ReadLine(), out r.Height);
            Console.Write("Вес(кг): "); double.TryParse(Console.ReadLine(), out r.Weight);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Бегун: {r.Name}");
                Console.WriteLine($"Шаги: {r.Steps}");
                Console.WriteLine($"Дистанция: {r.DistanceKm():F2} км");
                Console.WriteLine($"Калории: {r.Calories():F0}");
                Console.WriteLine("\n1. Добавить шаги  0. Выход");
                Console.Write("Действие: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "1") { Console.Write("Шаги: "); double s; double.TryParse(Console.ReadLine(), out s); r.Steps += s; }
            }
        }

        static void RunTask14()
        {
            Pyramid p = new Pyramid();
            Console.Write("Сторона основания: "); double.TryParse(Console.ReadLine(), out p.Base);
            Console.Write("Высота: "); double.TryParse(Console.ReadLine(), out p.Height);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ПИРАМИДА");
                Console.WriteLine($"Основание: {p.Base}x{p.Base} | Высота: {p.Height}");
                Console.WriteLine($"Объём: {p.Volume():F2}");
                Console.WriteLine($"Площадь пов-ти: {p.TotalArea():F2}");
                Console.WriteLine("\n1. Изменить размеры  0. Выход");
                Console.Write("Действие: ");
                string c = Console.ReadLine();
                if (c == "0") break;
                if (c == "1")
                {
                    Console.Write("Новая сторона: "); double.TryParse(Console.ReadLine(), out p.Base);
                    Console.Write("Новая высота: "); double.TryParse(Console.ReadLine(), out p.Height);
                }
            }
        }

        static void WaitForKey()
        {
            Console.WriteLine("\n\nНажмите Enter для возврата в главное меню...");
            Console.ReadLine();
        }
    }

    class Phone
    {
        public string number, model; public double weight;
        public Phone(string num, string mod, double w) { number = num; model = mod; weight = w; }
        public void receiveCall(string name) => Console.WriteLine($"Звонит {name}");
        public string getNumber() => number;
        public void sendMessage(params string[] phones)
        {
            Console.WriteLine("Отправка сообщения на номера:");
            foreach (var p in phones) Console.WriteLine($"  → {p}");
        }
        public override string ToString() => $"[{model}] {number}, {weight}г";
    }

    class Person
    {
        public string fullName; public int age;
        public Person() { fullName = "Не указано"; age = 0; }
        public Person(string name, int a) { fullName = name; age = a; }
        public void move() => Console.WriteLine($"{fullName} идёт");
        public void talk() => Console.WriteLine($"{fullName} говорит");
        public override string ToString() => $"{fullName}, {age} лет";
    }

    class Matrix
    {
        private double[,] data; private int rows, cols;
        public Matrix(int r, int c) { rows = r; cols = c; data = new double[r, c]; }
        public int Rows => rows; public int Cols => cols;
        public void FillRandom(Random rnd) { for (int i = 0; i < rows; i++) for (int j = 0; j < cols; j++) data[i, j] = rnd.Next(0, 10); }
        public void Print(string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) Console.Write(data[i, j].ToString("F1").PadLeft(6));
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public Matrix Add(Matrix other)
        {
            if (rows != other.rows || cols != other.cols) throw new Exception("Размеры не совпадают");
            Matrix res = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++) for (int j = 0; j < cols; j++) res.data[i, j] = data[i, j] + other.data[i, j];
            return res;
        }
        public Matrix MulScalar(double k)
        {
            Matrix res = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++) for (int j = 0; j < cols; j++) res.data[i, j] = data[i, j] * k;
            return res;
        }
    }

    class Reader
    {
        public string fullName = "", ticketNumber = "", faculty = "", birthDate = "", phone = "";
        public void takeBook(string book) => Console.WriteLine($"{fullName} взял книгу: {book}");
        public void returnBook(string book) => Console.WriteLine($"{fullName} вернул книгу: {book}");
    }

    class Tiles
    {
        public string brand; public double size_h, size_w, price;
        public void getData()
        {
            Console.WriteLine($"Бренд: {brand} | Размер: {size_h}x{size_w} см | Цена: {price} руб.");
            Console.WriteLine($"Площадь: {(size_h * size_w):F2} см²");
        }
    }

    class Children
    {
        private string name, surname; private int age;
        public void InputData()
        {
            Console.Write("Имя: "); name = Console.ReadLine();
            Console.Write("Фамилия: "); surname = Console.ReadLine();
            Console.Write("Возраст: "); int.TryParse(Console.ReadLine(), out age);
        }
        public void DisplayData() => Console.WriteLine($"{surname} {name}, {age} лет");
    }

    class Cube
    {
        private double side;
        public double Side { get => side; set => side = value > 0 ? value : 1; }
        public double FaceArea => side * side;
        public double Volume => side * side * side;
        public string State => $"Сторона: {side}, Грань: {FaceArea:F2}, Объём: {Volume:F2}";
    }

    class Counter
    {
        private int value, min, max;
        public int Value => value;
        public Counter(int min = 0, int max = 10, int start = 0)
        {
            this.min = min; this.max = max;
            value = (start >= min && start <= max) ? start : min;
        }
        public void Increment() { if (value < max) value++; else Console.WriteLine("Максимум достигнут"); }
        public void Decrement() { if (value > min) value--; else Console.WriteLine("Минимум достигнут"); }
    }

    class Time
    {
        private int h, m, s;
        public void Set(int hh, int mm, int ss)
        {
            if (hh < 0 || hh > 23 || mm < 0 || mm > 59 || ss < 0 || ss > 59) throw new Exception("Недопустимое время");
            h = hh; m = mm; s = ss;
        }
        public void Add(int hh, int mm, int ss)
        {
            int total = h * 3600 + m * 60 + s + hh * 3600 + mm * 60 + ss;
            total = total % 86400; if (total < 0) total += 86400;
            h = total / 3600; m = (total % 3600) / 60; s = total % 60;
        }
        public override string ToString() => $"{h:D2}:{m:D2}:{s:D2}";
    }

    class Triangle
    {
        public double A, B, C;
        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a) throw new Exception("Треугольник не существует с такими сторонами!");
            A = a; B = b; C = c;
        }
        public double Perimeter() => A + B + C;
        public double Area() { double p = Perimeter() / 2; return Math.Sqrt(p * (p - A) * (p - B) * (p - C)); }
        public double MedianA() => 0.5 * Math.Sqrt(2 * B * B + 2 * C * C - A * A);
        public double MedianB() => 0.5 * Math.Sqrt(2 * A * A + 2 * C * C - B * B);
        public double MedianC() => 0.5 * Math.Sqrt(2 * A * A + 2 * B * B - C * C);
    }

    class Student
    {
        public string LastName, FirstName, Group, Faculty, Phone;
        public int Course;
        public override string ToString() => $"{LastName} {FirstName}, {Group}, {Faculty}, {Course} курс, тел. {Phone}";
    }

    class Hardware
    {
        public string Type = "", Brand = "", Model = "";
        public int Power = 0; public double Price = 0;
    }

    class Runner
    {
        public string Name; public double Height, Weight, Steps;
        public double DistanceKm() => Steps * (0.415 * Height / 100) / 1000;
        public double Calories() => Steps * Weight * 0.0005;
    }

    class Pyramid
    {
        public double Base, Height;
        public double Volume() => (Base * Base * Height) / 3;
        public double SlantHeight() => Math.Sqrt(Height * Height + (Base / 2) * (Base / 2));
        public double LateralArea() => 2 * Base * SlantHeight();
        public double TotalArea() => Base * Base + LateralArea();
    }
}