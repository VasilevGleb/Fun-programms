//TypeText("Hello World");

class Program
{
    public static void SelfDestructingProtocol()
    {
        TypeText("Invalid input. Self-destruction protocol activated!");
        Console.WriteLine("");
        TypeText("...3");
        Console.WriteLine("");
        TypeText("...2");
        Console.WriteLine("");
        TypeText("...1");
        Console.WriteLine("");
        Console.WriteLine("Boom!");
        System.Environment.Exit(0);
    }
    static void AddPallets(string[] pallets)
    {
        int count = int.Parse(Console.ReadLine());
        if (count < 0 || !int.TryParse(Console.ReadLine(), out count))
        {
            TypeText("Invalid input. Please enter a non-negative number.");
            return;
        }
        else
        {
            Array.Resize(ref pallets, pallets.Length + count);
            TypeText($"Added {count} pallets. Total pallets: {pallets.Length}");
            Console.WriteLine("");
            TypeText("Current pallets:");
            foreach (string pallet in pallets)
            {
                Console.WriteLine($"--{pallet}");
            }
        }
    }
    static void ClearPallets(string[] pallets)
    {
        TypeText("How many pallets do you want to clear? (0-" + pallets.Length + ")");
        int count = int.Parse(Console.ReadLine());

        if (count >= 0 && count <= pallets.Length)
        {
            Array.Clear(pallets, 0, count);
            foreach (string pallet in pallets)
            {
                Console.WriteLine($"--{pallet}");
            }
        }
        else if (count == 0)
        {
            Thread.Sleep(500);
            TypeText("No pallets cleared. Current pallets:");
            Console.WriteLine($"--{string.Join(", --", pallets)}");
        }
        else
        {
            TypeText("Invalid input. Please enter a number between 0 and " + pallets.Length + ".");
        }

    }
    static void ReversePallets(string[] pallets)
    {
        Thread.Sleep(2000);
        Array.Reverse(pallets);
        foreach (string pallet in pallets)
        {
            Console.WriteLine($"--{pallet}");
        }
        TypeText("Pallets reversed!");
    }

    public static void SortingPallets(string[] pallets)
    {
        Array.Sort(pallets);
        Thread.Sleep(2000);
        foreach (string pallet in pallets)
        {
            Console.WriteLine($"--{pallet}");
        }
        TypeText("Pallets sorted!");
    }
    static void TypeText(string text)
    {
        int delay = 100;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        // List<string> palletList = new List<string> { "B12", "A11", "C13", "8813", "D14", "A10", "B11", "C12", "D13", "A9" };
        string[] pallets = ["B12", "A11", "C13", "8813", "D14", "A10", "B11", "C12", "D13", "A9"];
        bool isRunning = true;
        bool isSorted = false;

        while (isRunning)
        {

            Console.WriteLine();
            TypeText("What should I do?");
            TypeText("  ");
            if (!isSorted)
            {
                Console.WriteLine("1. Sort the pallets");
            }
            else
            {
                Console.WriteLine("1. The pallets are already sorted!");
            }
            Console.WriteLine("2. Reverse the pallets");
            Console.WriteLine("3. Clear some pallets");
            Console.WriteLine("4. How much do you love pallets");
            Console.WriteLine("5. Add more pallets");
            Console.WriteLine("6. Make me a coffee");
            Console.WriteLine("7. Exit");


            switch (Console.ReadLine())
            {

                case "1":
                    if (!isSorted)
                    {
                        SortingPallets(pallets);
                        isSorted = true;
                        break;
                    }
                    else { Console.WriteLine("The pallets are already sorted!"); }
                    break;

                case "2":
                    ReversePallets(pallets);
                    isSorted = false;
                    break;

                case "3":
                    ClearPallets(pallets);
                    break;

                case "4":
                    TypeText("I love pallets so much! They are the best!");
                    TypeText("How about you? Do you love pallets? (y/n)");
                    string? loveAnswer = Console.ReadLine();
                    if (loveAnswer?.ToLower() == "y")
                    {
                        TypeText("That's great! I'm glad you love pallets too!");
                        break;
                    }
                    else if (loveAnswer?.ToLower() == "n")
                    {
                        SelfDestructingProtocol();
                    }
                    break;


                case "5":
                    TypeText("Okay, adding more pallets...");
                    TypeText("Please enter the number of pallets you want to add:");
                    Thread.Sleep(2000);
                    AddPallets(pallets);
                    break;

                case "6":
                    TypeText("Making coffee...");
                    Thread.Sleep(2000);
                    Console.WriteLine("");
                    TypeText("Hahaha, was a joke! I`m sorting program.");
                    break;

                case "7":
                    TypeText("Exiting...");
                    isRunning = false;
                    break;
            }

        }

    }
}