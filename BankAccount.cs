using System;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Threading;

static class UI
{
    public static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }
}

static class MD5Hasher
{
    public static string Hash(string password)
    {
        using MD5 md5 = MD5.Create();
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
        byte[] hash = md5.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}

class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public decimal SavingsGoal { get; set; }
    //public decimal CreditDebt { get; set; }
    public bool HasAccount = false;
    public bool IsLogged = false;

    const string FILE = "save.txt";

    public void Save()
    {
        File.WriteAllText(FILE,
            Name + "|" +
            Password + "|" +
            Balance.ToString(CultureInfo.InvariantCulture) + "|" +
            SavingsGoal.ToString(CultureInfo.InvariantCulture) + "|");
    }

    public void Load()
    {
        if (!File.Exists(FILE)) return;
        string[] data = File.ReadAllText(FILE).Split('|');
        if (data.Length < 5) { File.Delete(FILE); return; }
        Name = data[0];
        Password = data[1];
        Balance = decimal.Parse(data[2], CultureInfo.InvariantCulture);
        SavingsGoal = decimal.Parse(data[3], CultureInfo.InvariantCulture);
        //CreditDebt = decimal.Parse(data[4], CultureInfo.InvariantCulture);
        HasAccount = true;
    }

    public void Create()
    {
        UI.TypeText("Enter your name:");
        Name = Console.ReadLine();

        UI.TypeText("Enter your password:");
        Password = MD5Hasher.Hash(Console.ReadLine());

        UI.TypeText("Enter your current balance (€):");
        Balance = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        HasAccount = true;
        IsLogged = true;
        Save();
        UI.TypeText("Account created! Welcome, " + Name + "!");
    }

    public void LogIn()
    {
        while (true)
        {
            UI.TypeText("Enter your password:");
            string input = Console.ReadLine();
            if (MD5Hasher.Hash(input) == Password)
            {
                IsLogged = true;
                UI.TypeText("Welcome back, " + Name + "!");
                return;
            }
            UI.TypeText("Incorrect password. Try again.");
        }
    }

    public void ChangePassword()
    {
        UI.TypeText("Enter your current password:");
        if (MD5Hasher.Hash(Console.ReadLine()) != Password)
        {
            UI.TypeText("Incorrect password.");
            return;
        }
        UI.TypeText("Enter new password:");
        Password = MD5Hasher.Hash(Console.ReadLine());
        Save();
        UI.TypeText("Password changed successfully!");
    }
}

class BankProgram
{
    User user = new User();

    public void Run()
    {
        user.Load();
        if (!user.HasAccount) user.Create();
        else user.LogIn();

        while (user.IsLogged) ShowMenu();

        UI.TypeText("Thank you for using the Bank. Goodbye!");
    }

    void ShowMenu()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  MENU");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("[1] Check Balance");
        Console.WriteLine("[2] Deposit");
        Console.WriteLine("[3] Withdraw");
        Console.WriteLine("[4] " + (user.SavingsGoal > 0 ? "Check Savings Goal" : "Set Savings Goal"));
        Console.WriteLine("[5] Exchange (calculate % of amount)");
        Console.WriteLine("[6] Settings");
        Console.WriteLine("[7] Log Out");
        Console.WriteLine();

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            UI.TypeText("Invalid input.");
            return;
        }

        Console.WriteLine();

        switch (choice)
        {
            case 1:
                UI.TypeText($"Balance: {user.Balance:F2}€");

                break;

            case 2:
                UI.TypeText("Amount to deposit:");
                decimal dep = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                user.Balance += dep;
                user.Save();
                UI.TypeText($"New balance: {user.Balance:F2}€");
                break;

            case 3:
                UI.TypeText("Amount to withdraw:");
                decimal wit = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                user.Balance -= wit;
                UI.TypeText($"New balance: {user.Balance:F2}€");

                user.Save();
                break;

            case 4:
                if (user.SavingsGoal > 0)
                {
                    decimal remaining = user.SavingsGoal - user.Balance;
                    decimal pct = (user.Balance / user.SavingsGoal) * 100;
                    UI.TypeText($"Goal: {user.SavingsGoal:F2}€");
                    UI.TypeText($"Progress: {pct:F1}%");
                    UI.TypeText($"Remaining: {(remaining > 0 ? remaining.ToString("F2") : "0.00")}€");
                    if (user.Balance >= user.SavingsGoal)
                        UI.TypeText("Congratulations! Goal reached!");
                    Console.WriteLine();
                    UI.TypeText("Change goal? (y/n)");
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        UI.TypeText("New goal (€):");
                        user.SavingsGoal = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        user.Save();
                    }
                }
                else
                {
                    UI.TypeText("Savings goal (€):");
                    user.SavingsGoal = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    user.Save();
                    UI.TypeText($"Goal set: {user.SavingsGoal:F2}€");
                }
                break;

            case 5:
                UI.TypeText("Amount:");
                decimal amt = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                UI.TypeText("Percentage to receive (e.g. 90 = you get 90%):");
                decimal pctEx = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                decimal minus = amt * (pctEx / 100);
                decimal result = amt - minus;
                UI.TypeText($"You will receive: {result:F2}€");
                break;

            case 6:
                Console.WriteLine("[1] Change password");
                Console.WriteLine("[2] Back");
                if (Console.ReadLine() == "1") user.ChangePassword();
                break;

            case 7:
                user.IsLogged = false;
                break;

            default:
                UI.TypeText("Invalid choice.");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        new BankProgram().Run();
    }
}
