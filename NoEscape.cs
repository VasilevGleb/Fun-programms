using System;
using System.Text;
using System.Threading.Tasks;

static public class Txt
{
    static public void TT(string txt, int delay)
    {
        foreach (char c in txt)
        {
            Console.Write(c);
            Thread.Sleep(delay);

        }
        Console.WriteLine();
    }
    static public void Mssg()
    {
        Console.Clear();
        string mssg = "Вы уверены что хотите выйти?(Y/N)";
        TT(mssg, 50);
        string answ = Console.ReadLine().ToLower();
        if (answ == "123a")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            TT("Thank you :)\n", 50);
            Thread.Sleep(200);
            Console.ResetColor();
            TT("Press any button to Escape.", 50);
            Console.ReadKey();
            Environment.Exit(0);
        }
        do
        {
            switch (answ)
            {
                case "y":
                    Console.Clear();
                    Mssg();
                    break;

                case "n":
                    Console.Clear();
                    Mssg();
                    break;

                default:
                    Console.Clear();
                    Mssg();
                    break;
            }

        } while (answ != "123a");

    }
}

static public class Prog
{
    static public void Main(string[] args)
    {
        Txt.Mssg();
    }
}
