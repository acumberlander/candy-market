using System;

namespace candy_market
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = SetupNewApp();

			var exit = false;
			while (!exit)
			{
				var userInput = MainMenu();
				exit = TakeActions(db, userInput);
			}
		}

		internal static CandyStorage SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";
			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.ForegroundColor = ConsoleColor.Cyan;

			var db = new CandyStorage();

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
                    Console.WriteLine("What is the name of your candy?");
                    string Name = Console.ReadLine().ToLower();

                    Console.WriteLine("Who is the manufacturer of your candy?");
                    string Manufacturer = Console.ReadLine().ToLower();

                    Console.WriteLine("What is the flavor of your candy?");
                    string FlavorCategory = Console.ReadLine().ToLower();

                    Console.WriteLine("When did you purchase this candy? [ex] 01/01/19");
                    int DateRecieved = Convert.ToInt32(Console.ReadLine());

                    break;
                case "2": EatCandy(db);
					break;
				default: return true;
			}
			return true;
		}

		internal static void AddNewCandy(CandyStorage db)
		{
			//var newCandy = new Candy
			{
			//	Name = "Whatchamacallit"
			};

			//var savedCandy = db.SaveNewCandy(newCandy);
			//Console.WriteLine($"Now you own the candy {savedCandy.Name}");
		}

		private static void EatCandy(CandyStorage db)
		{
			throw new NotImplementedException();
		}
	}
}
