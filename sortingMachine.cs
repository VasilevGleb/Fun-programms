//TypeText("Hello World");


class Program
{
    public static void ReversePallets(string[] pallets)
    {
        Array.Reverse(pallets);
        TypeText("Pallets reversed!");
        TypeText($" {string.Join(", ", pallets)}");
    }

    public static void SortingPallets(string[] pallets)
    {
        Array.Sort(pallets);
        TypeText("Pallets sorted!");
        TypeText($" {string.Join(", ", pallets)}");
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
            Console.WriteLine("3. Say how do you much love pallets");
            Console.WriteLine("4. Do nothing");
            Console.WriteLine("5. Make me a coffee");
            Console.WriteLine("6. Exit");


            switch (Console.ReadLine())
            {

                case "1":
                    if (!isSorted)
                    {
                        SortingPallets(pallets);
                        isSorted = true;
                        TypeText("Pallets sorted successfully!");
                        break;
                    }
                    else { Console.WriteLine("The pallets are already sorted!"); }
                    break;

                case "2":
                    ReversePallets(pallets);
                    isSorted = false;
                    break;

                case "3":
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
                        TypeText("Invalid input. Self-destructing...");
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
                    break;


                case "4":
                    TypeText("Okay, doing nothing...");
                    break;

                case "5":
                    TypeText("Making coffee...");
                    Thread.Sleep(2000);
                    TypeText("Hahaha, was a joke! I`m sorting program.");
                    break;

                case "6":
                    TypeText("Exiting...");
                    isRunning = false;
                    break;
            }

        }

    }
}



