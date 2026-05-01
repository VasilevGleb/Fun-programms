using System;

static class Program
{
    static Random rndm = new Random();
    static List<string> shopList = new List<string>();
    static List<string> bascet = new List<string>();

    static int rest = Player.money - sumTotal;
    static int sumTotal = 0;
    static bool gameOver = false;
    static bool isRunning = false;

    static bool isHome = true;
    static bool isShop = false;

    // start game

    static void GameStart()
    {
        isRunning = true;
    }

    //Product dictionary with product names and their prices
    static Dictionary<string, int> products = new Dictionary<string, int>()
    {
        {"Bread", 10},
        {"Milk", 20},
        {"Eggs", 30},
        {"Chicken", 40},
        {"Rice", 50}
    };

    // Method to generate a random shopping list
    public static List<string> GenerateRandomShoppingList()
    {
        TypeText("Generating random shopping list...");
        var shopList = products.Keys

            .OrderBy(x => rndm.Next())
            .Take(3)
            .ToList();
        TypeText($"Your shopping list:");
        Thread.Sleep(1000);
        Console.WriteLine("");
        foreach (string item in shopList)
        {
            TypeText($"- {item}");
        }
        return shopList;
    }

    // TypeText method to simulate typing effect
    public static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }

    public class Player
    {
        public static int money = 1000;
    }

    public static Player CreatePlayer()
    {
        Player player = new Player();
        Console.WriteLine("");
        TypeText("Player created with " + Player.money + " money.");
        return player;
    }

    // GameOver()
    public static void GameOver()
    {
        if (gameOver)
        {
            TypeText("Sorry, but now you must die!");
        }
        else
        {
            TypeText("See you next time!");
        }
        isRunning = false;
    }

    //Congratulation()
    public static void Congratulation()
    {
        Thread.Sleep(1000);
        TypeText("Nice Work! Thanks for your help!");
        GameOver();
    }

    //PissingOff()
    public static void PissingOff()
    {
        Thread.Sleep(1000);
        TypeText("No way! Not there is not all I needed! Be next time more carfull please!");
        gameOver = true;
        GameOver();
    }
    // goHome method to handle returning home logic
    public static void goHome()
    {
        isHome = true;
        isShop = false;

        TypeText("You are going back home...");
        Thread.Sleep(1000);
        TypeText("Welcome back home!");
        Thread.Sleep(500);
        TypeText("Your shopping list is:");
        foreach (string item in shopList)
        {
            TypeText($"- {item}");
        }
        Thread.Sleep(500);
        TypeText("Your bascet contains:");
        foreach (string item in bascet)
        {
            TypeText($"- {item}");
        }
        bool allExist = shopList.All(x => bascet.Contains(x));
        if (allExist)
        {
            Congratulation();
        }
        else
        {
            PissingOff();
        }
    }
    // ShopScript method to handle shopping logic
    public static void ShopScript()
    {
        Thread.Sleep(200);

        TypeText("Welcome to the shop!");
        TypeText("Here you can buy products to fill your shopping list.");

        foreach (var stuff in products)
        {
            TypeText($"{stuff.Key} costs: {stuff.Value}");
        }
        TypeText("What would you like to buy? (Type the product name or 'exit' to leave)");

        while (isRunning)
        {


            string choise = Console.ReadLine();
            Thread.Sleep(500);
            var product = products.FirstOrDefault(p => p.Key.Equals(choise, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrEmpty(product.Key))
            {
                TypeText($"You bought {product.Key} for {product.Value} money.");
                sumTotal += product.Value;
                bascet.Add(product.Key);
                continue;
            }
            else if (choise.ToLower() == "exit")
            {
                TypeText("Thank you for shopping! Let's see what you bought.");
                foreach (string item in bascet)
                {
                    TypeText($"- {item}");
                }
                TypeText($"Your total is: {sumTotal} money.");
                TypeText($"Your rest is: {rest} money");

                goHome();

            }
            else
            {
                TypeText("Product not found. Please try again.");
            }
        }

    }
    // Main
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World!");
        GameStart();

        CreatePlayer();
        Thread.Sleep(1000);
        shopList = GenerateRandomShoppingList();
        Console.WriteLine("");
        TypeText("Go to shop? (y/n)");
        string action = Console.ReadLine();
        while (isRunning)
        {
            switch (action.ToLower())
            {
                case "y":
                    isHome = false;
                    isShop = true;
                    Thread.Sleep(2000);
                    ShopScript();
                    break;

                case "n":
                    TypeText("You decided to stay home.");
                    Thread.Sleep(500);
                    TypeText("Maybe it's better so");
                    isRunning = false;
                    break;
            }
        }

    }
}