//TypeText("Hello World");



class Program
{
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

        bool isRunning = true;
        bool isSorted = false;

        while (isRunning)
        {
            string[] pallets = ["B12", "A11", "C13", "c@!"];


            Console.WriteLine();
            TypeText("What should I do with the pallets?");
            TypeText("  ");
            Console.WriteLine("1. Sort the pallets");
            Console.WriteLine("2. Say how do you much love pallets");
            Console.WriteLine("3. Do nothing");
            Console.WriteLine("4. Exit");

            switch (Console.ReadLine())
            {

                case "1":

                    TypeText("Should I sort the pallets? (y/n)");
                    if (!isSorted)
                    {
                        string? answer = Console.ReadLine();

                        if (answer?.ToLower() == "y")
                        {
                            if (!isSorted)
                            {
                                TypeText("Sorted...");
                                Console.WriteLine("");
                                Array.Sort(pallets);
                                foreach (string sortedPallet in pallets)
                                {
                                    TypeText(sortedPallet);
                                }
                                isSorted = true;
                                TypeText("Done!");
                            }
                            else
                            {
                                TypeText("The pallets are already sorted!");
                            }
                        }
                        else if (answer?.ToLower() == "n")
                        {
                            TypeText("Not sorted...");
                            Console.WriteLine("");
                            if (!isSorted)
                            {

                                foreach (string pallet in pallets)
                                {

                                    TypeText(pallet);
                                }
                            }
                            else
                            {
                                TypeText("The pallets are already sorted!");
                            }
                        }
                        else
                        {
                            TypeText("Invalid input. Not sorting...");
                        }
                        break;
                    }
                    else
                    {
                        TypeText("The pallets are already sorted!");
                    }
                    break;

                case "2":
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


                case "3":
                    TypeText("Okay, doing nothing...");
                    break;

                case "4":
                    TypeText("Exiting...");
                    isRunning = false;
                    break;
            }

        }

    }
}



