//TypeText("Hello World");

void TypeText(string text)
{
    int dealy = 100; // milliseconds
    foreach (char c in text)
    {
        Console.Write(c);
        System.Threading.Thread.Sleep(dealy);
    }
    Console.WriteLine("");
}

string[] pallets = ["B12", "A11", "C13", "c@!"];
TypeText("Should I sort the pallets? (y/n)");

string? answer = Console.ReadLine();
if (answer == null)
{
    TypeText("No input provided. Exiting...");
    return;
}
if (answer?.ToLower() == "y")
{
    TypeText("Sorted...");
    Console.WriteLine("");
    Array.Sort(pallets);
    foreach (string pallet in pallets)
    {
        TypeText(pallet);
    }
    TypeText("Done!");
}
else if (answer?.ToLower() == "n")
{
    TypeText("Not sorted...");
    Console.WriteLine("");
    foreach (string pallet in pallets)
    {

        TypeText(pallet);
    }
}
else
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

