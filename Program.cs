using System;
using System.Collections.Generic;

namespace candy_market
{
	class Program
	{
		static void Main(string[] args)
		{

            //var candyOwners = new List<CandyStorage>();

            var dylan = new CandyStorage("Dylan");
            var austin = new CandyStorage("Austin");
            var jonathan = new CandyStorage("Jonathan");

            var users = new Users();

            users.AddOwner(dylan);
            users.AddOwner(austin);
            users.AddOwner(jonathan);

            Console.WriteLine("Enter User Name");
            var db = SetupNewApp(Console.ReadLine());
            users.AddOwner(db);

			var exit = false;
			while (!exit)
			{
				var userInput = MainMenu();
				exit = TakeActions(db, userInput);
			}
		}

		internal static CandyStorage SetupNewApp(string ownerName)
		{
			Console.Title = "Cross Confectioneries Incorporated";
			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.ForegroundColor = ConsoleColor.Cyan;

			var db = new CandyStorage(ownerName);

            return db;
		}

		internal static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
					.AddMenuText("Press Esc to exit.");
			Console.Write(mainMenu.GetFullMenu());
			var userOption = Console.ReadKey();
			return userOption;
		}

		private static bool TakeActions(CandyStorage db, ConsoleKeyInfo userInput)
		{
			Console.Write(Environment.NewLine);

			if (userInput.Key == ConsoleKey.Escape)
				return true;

			var selection = userInput.KeyChar.ToString();
			switch (selection)
			{
				case "1": AddNewCandy(db);
                    break;
                case "2": EatCandy(db);
					break;
				default: return true;
			}
			return true;
		}

		internal static void AddNewCandy(CandyStorage db)
		{
            Console.WriteLine("What is the name of your candy?");
            string Name = Console.ReadLine().ToString();

            Console.WriteLine("Who is the manufacturer of your candy?");
            string Manufacturer = Console.ReadLine().ToString();

            Console.WriteLine("What is the flavor of your candy?");
            string FlavorCategory = Console.ReadLine().ToString();

            Console.WriteLine("When did you buy this candy? [EX] 2010, 12, 23");
            Console.WriteLine("Enter Year:");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month:");
            int Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Day:");
            int Day = Convert.ToInt32(Console.ReadLine());

            var DateReceived = new DateTime(Year, Month, Day);

            var newCandy = new Candy(Name, Manufacturer, FlavorCategory, DateReceived);
			
                db.SaveNewCandy(newCandy);
                Console.WriteLine($"Now you own the candy {newCandy.Name}");
                Console.ReadKey();
            var exit = false;
            while (!exit)
            {
                var userInput = MainMenu();
                exit = TakeActions(db, userInput);
            }
        }


		private static void EatCandy(CandyStorage db)
		{
                var candyShop = db.CandyFlavor("");
                Random random = new Random();
                int rdmNum = random.Next(0, candyShop.Count -1);
                var candyChoice = candyShop[rdmNum];
                candyShop.RemoveAt(rdmNum);
                Console.WriteLine(candyShop.Count);
                Console.ReadKey();
            }
        }
    }
