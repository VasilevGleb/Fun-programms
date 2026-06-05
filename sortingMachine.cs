using System;
using System.Threading;
using System.Text;


public class Program
{
    static Dictionary<string, List<string>> list = new Dictionary<string, List<string>>()
    {
        {"Хлеб", new List<string>() {"[G526]", "[L464]", "[B334]"}}

        ,{"Молоко", new List<string>() {"[M999]", "[L725]", "[N464]"}}

        ,{"Сыр", new List<string>() {"[S112]", "[C972]", "[P196]"}}

        ,{"Чипсы", new List<string>() {"[H373]"}}

        ,{"Яйца", new List<string>() {"[R553]", "[F228]"}}

        ,{"Колбаса", new List<string>() {"[D014]", "[E666]", "[U088]"}}

    };

    public static void AddPallets()
    {
        Console.Write("Введите имя продукта:\n");
        string productName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(productName)) return;
        productName = productName.Trim();
        productName = char.ToUpper(productName[0]) + productName.Substring(1).ToLower();

        if (!list.ContainsKey(productName))
        {
            Console.WriteLine("Продукт не найден.");
            return;
        }

        Console.Write("Введите номер паллеты для добавления:\n");
        string palletNumber = Console.ReadLine();

        // 1. Проверка длины — если больше 5, вывести сообщение и return
        if (palletNumber.Length < 5)
        {
            Console.WriteLine("Номер паллеты должен быть ровно 5 символов.");
            return;
        }

        // 2. foreach по list.Keys — проверить дубли во всех продуктах
        //    если нашёл — вывести сообщение и return
        foreach (string product in list.Keys)
        {
            if (list[product].Contains(palletNumber))
            {
                Console.WriteLine("Паллета с таким номером уже существует.");
                return;
            }
        }

        // 3. Если дошли сюда — всё чисто
        list[productName].Add(palletNumber);
        //    Вывести сообщение об успехе
        Console.WriteLine($"\nПаллета {palletNumber} добавлена.");
    }
    public static void RemovePallets()
    {
        bool found = false;
        foreach (string product in list.Keys)
        {
            Console.WriteLine($"Продукт: {product}");
            foreach (string pallet in list[product])
            {
                Console.WriteLine($"--{pallet}");
            }
        }

        Console.WriteLine("Введите номер паллеты для удаления:\n");
        string palletNumber = Console.ReadLine().ToLower();
        foreach (string pallet in list.Keys)
        {
            if (list[pallet].Contains(palletNumber))
            {
                found = true;
                list[pallet].Remove(palletNumber);
                Console.WriteLine("Паллета удалена.");
                return;
            }
        }
        if (!found)
        {
            Console.WriteLine("Паллета не найдена.");
        }
    }

    static void ShowPallets()
    {
        foreach (string product in list.Keys)
        {
            Console.WriteLine($"Продукт: {product}");
            foreach (string pallet in list[product])
            {
                Console.WriteLine($"--{pallet}");
            }
        }
    }

    static void HowMuchDoYouLovePallets()
    {
        Console.WriteLine("Паллеты - это основа нашего склада. Они поддерживают порядок и эффективность в нашей работе.");
        Console.WriteLine("Так что я, робот-сортировщик, их просто обожаю!!!\n");

        Console.WriteLine("А на сколько сильно любите паллеты вы? (0-10)\n");
        int loveLevel = int.Parse(Console.ReadLine());
        if (loveLevel >= 4)
        {
            Console.WriteLine($"Вы любите паллеты на уровне {loveLevel} из 10.");
        }
        else if (loveLevel <= 3)
        {
            Console.WriteLine($"Вы любите паллеты на уровне {loveLevel} из 10. Это не так много, но я уважаю ваш выбор.");
        }
        else if (loveLevel == 0)
        {
            Console.WriteLine("Вы не любите паллеты вообще?! Это печально.");
            Thread.Sleep(1000);
            Console.WriteLine("Инициирую протокол самоуничтожения...");
            Thread.Sleep(1000);
            SelfDestruction();
        }
        else
        {
            Console.WriteLine("Пожалуйста, введите число от 0 до 10.");
        }
    }

    static void MakeMeACoffee()
    {
        int suggar = 0;
        int milk = 0;
        Console.WriteLine("Сколько сахара вы хотите в кофе?");
        Console.WriteLine("(0/10)");
        suggar = int.Parse(Console.ReadLine());
        if (suggar >= 5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ебать ты жирный!!!");
            Console.ResetColor();
        }
        Console.WriteLine("Cколько молока вы хотите в кофе?");
        Console.WriteLine("(0/5)");
        milk = int.Parse(Console.ReadLine());
        if (milk < 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Кончилось молоко!");
            Console.ResetColor();
        }
        int c = 0;
        while (c != 4)
        {
            Console.Write(".");
            Thread.Sleep(300);
            c++;
        }
        Console.WriteLine("\nТы издеваешься?!\n Я робот-сортировщик, а не кофеварка!!!");

    }
    static void SelfDestruction()
    {
        Thread.Sleep(300);
        Console.WriteLine("");
        Console.WriteLine("...3");
        Thread.Sleep(300);
        Console.WriteLine("");
        Console.WriteLine("...2");
        Thread.Sleep(300);
        Console.WriteLine("");
        Console.WriteLine("...1");
        Thread.Sleep(300);
        Console.WriteLine("");
        Console.WriteLine("Boom!");
        Console.WriteLine("");
        Thread.Sleep(300);
        System.Environment.Exit(0);
    }

    public static void Menu()
    {

        Console.WriteLine("1. Show pallets");
        Console.WriteLine("2. Add pallets");
        Console.WriteLine("3. Remove some pallets");
        Console.WriteLine("4. How much do you love pallets");

        Console.WriteLine("5. Make me a coffee");
        Console.WriteLine("6. Exit\n");

        Console.WriteLine("Пожалуйста, введите номер действия:\n");
        int choice = int.TryParse(Console.ReadLine(), out choice) ? choice : 0;
        switch (choice)
        {
            case 1:
                ShowPallets();
                break;
            case 2:
                AddPallets();
                break;
            case 3:
                RemovePallets();
                break;
            case 4:
                HowMuchDoYouLovePallets();
                break;
            case 5:
                MakeMeACoffee();
                break;
            case 6:
                Thread.Sleep(500);
                Console.WriteLine("До свидания!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Неверный номер действия.");
                break;
        }
    }


    public static void Main(string[] args)
    {
        while (true)
        {
            Menu();
        }
    }

}

