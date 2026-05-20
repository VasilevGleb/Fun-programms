using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; }
    public double toSaveUp { get; set; }
    public bool IsLogged = false;

    public bool SaveUp = false;

    public bool HasAccount = false;

    public void Save()
    {
        File.WriteAllText("save.txt", Name + "|" + Password + "|" + Balance + "|" + toSaveUp);
    }
    public void Load()
    {
        if (File.Exists("save.txt"))
        {
            string[] data = File.ReadAllText("save.txt").Split('|');
            Name = data[0];
            Password = data[1];
            Balance = double.Parse(data[2]);
            toSaveUp = double.Parse(data[3]);
            if (toSaveUp > 0) SaveUp = true;
            HasAccount = true;
        }
    }
    public void CreateAccount()
    {
        Console.WriteLine("Enter your name:");
        Name = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        Password = Console.ReadLine();
        Console.WriteLine("Enter your balance in €:");
        Balance = double.Parse(Console.ReadLine());
        HasAccount = true;
        IsLogged = true;
        Save();
    }

    public void LogIn()
    {
        while (true)
        {
            Console.WriteLine("Enter your password:");
            string inputPassword = Console.ReadLine();
            if (inputPassword == Password)
            {
                Console.WriteLine("Login successful!");
                IsLogged = true;
                return;
            }
            else
            {
                Console.WriteLine("Incorrect password. Please try again.");

            }

        }
    }
    public double Deposit(double amount)
    {
        Balance += amount;

        Console.WriteLine("Your new balance is: " + Balance + "€");
        return Balance;
    }
    public double Withdraw(double amount)
    {
        Balance -= amount;
        Console.WriteLine("Your new balance is: " + Balance + "€");
        return Balance;
    }

}

class BankProgram
{
    User User = new User();

    public void Run()
    {
        User.Load();
        Welcome();
        while (User.IsLogged)
        {
            ShowMenu();
        }
        Console.WriteLine("Thank you for using the Bank Program. Goodbye!");
    }
    public void MenuNav()
    {

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }
        switch (choice)
        {
            case 1:
                Console.WriteLine("");
                Thread.Sleep(500);
                Console.WriteLine("Your current balance is: " + User.Balance + "€");
                break;
            case 2:
                Console.WriteLine("");
                Console.WriteLine("Enter the amount you want to deposit:");
                double depositAmount = double.Parse(Console.ReadLine());
                User.Deposit(depositAmount);
                User.Save();
                break;
            case 3:
                Console.WriteLine("");
                Console.WriteLine("Enter the amount you want to withdraw:");
                double withdrawAmount = double.Parse(Console.ReadLine());
                User.Withdraw(withdrawAmount);
                User.Save();
                break;
            case 4:
                Console.WriteLine("");
                if (!User.SaveUp)
                {
                    User.SaveUp = true;
                    Console.WriteLine("How much do you want to save up?");
                    double saveUpAmount = double.Parse(Console.ReadLine());
                    User.toSaveUp = saveUpAmount;
                    User.Save();
                }
                else
                {
                    Console.WriteLine("You want to save up " + User.toSaveUp + "€.");
                    Console.WriteLine("Now you need to save up " + (User.toSaveUp - User.Balance) + "€ more.");
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to change your saving goal? (y/n)");

                    string input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        Console.WriteLine("How much do you want to save up?");
                        double saveUpAmount = double.Parse(Console.ReadLine());
                        User.toSaveUp = saveUpAmount;
                        User.Save();
                    }
                    else if (input.ToLower() == "n")
                    {
                        Console.WriteLine("Okay, keep saving up!");
                    }

                    if (User.Balance >= User.toSaveUp)
                    {
                        Console.WriteLine("Congratulations! You have saved up " + User.toSaveUp + "€.");
                        User.SaveUp = false;
                        User.toSaveUp = 0;
                        User.Save();
                    }
                }

                break;

            case 5:
                Console.WriteLine("");
                Console.WriteLine("Logging out...");
                User.IsLogged = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\tMenu:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[1] Check Balance");
        Console.WriteLine("[2] Deposit");
        Console.WriteLine("[3] Withdraw");
        Console.WriteLine("[4] Save Up");
        Console.WriteLine("[5] Log Out");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        MenuNav();
    }
    public void Welcome()
    {

        if (!User.IsLogged)
        {
            Console.WriteLine("Welcome to the Bank Program!");
            Console.WriteLine("Please log in or enter password to continue.");
            Thread.Sleep(1000);
            if (User.HasAccount) User.LogIn();
            else
            {
                Console.WriteLine("No account found. Please create an account.");
                User.CreateAccount();

            }
        }
        else
        {
            Console.WriteLine("Welcome back, " + User.Name + "!");
            ShowMenu();
        }
    }
}

class Program
{
    static void Main()
    {
        BankProgram bankProgram = new BankProgram();
        bankProgram.Run();
    }
}