using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    class Program
    {
        public static List<Candy> SeeCandy()
        {
            List<Candy> candyList = new List<Candy>();
            candyList.Add(new Candy("Jelly Bean", "Jelly Inc.", "bitter", new DateTime(2018 / 12 / 12)));
            candyList.Add(new Candy("Snickers", "Mars Inc.", "sweet", new DateTime(2019 / 01 / 12)));
            candyList.Add(new Candy("Reese's", "Mars Inc.", "sweet", new DateTime(2017 / 02 / 12)));
            candyList.Add(new Candy("Lemon Heads", "Some Company Inc.", "sour", new DateTime(2019 / 01 / 01)));
            return candyList;
        }

		static void Main(string[] args)
		{
            List<Candy> candies = SeeCandy();

            var x = candies.FindAll(candy => candy.Flavor == "sweet");

            foreach(Candy candy in x)
            {
                Console.WriteLine(candy);
            }

            var db = SetupNewApp();
            var FlavorList = new List<string>();

            FlavorList.Add("sour");
            FlavorList.Add("sweet");
            FlavorList.Add("bitter");
            FlavorList.Add("savory");

            var exit = false;
			while (!exit)
			{
				var userInput = MainMenu();
				exit = TakeActions(db, userInput, FlavorList);
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

		private static bool TakeActions(CandyStorage db, ConsoleKeyInfo userInput, List<string> FlavorList)
		{
			Console.Write(Environment.NewLine);

			if (userInput.Key == ConsoleKey.Escape)
				return true;

			var selection = userInput.KeyChar.ToString();
			switch (selection)
			{
				case "1": AddNewCandy(db, FlavorList);
                    break;
                case "2": EatCandy(db);
					break;
				default: return true;
			}
			return true;
		}

		internal static void AddNewCandy(CandyStorage db, List<string> FlavorList)
		{


            Console.WriteLine("What is the name of your candy?");
            string Name = Console.ReadLine().ToLower();

            Console.WriteLine("Who is the manufacturer of your candy?");
            string Manufacturer = Console.ReadLine().ToLower();

            Console.WriteLine("Choose your candy flavor: ");
            foreach(string flavor in FlavorList)
            {
                Console.WriteLine(flavor);
            }

            string Flavor = Console.ReadLine().ToLower();

            Console.WriteLine("When did you buy this candy? [EX] 2010, 12, 23");
            Console.WriteLine("Enter Year");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month");
            var Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Day");
            int Day = Convert.ToInt32(Console.ReadLine());

            var DateReceived = new DateTime(Year, Month, Day);

            var newCandy = new Candy(Name, Manufacturer, Flavor, DateReceived);
			{
                Console.WriteLine($"Now you own the candy {newCandy.Name}");
            };
            db.SaveNewCandy(newCandy);
            Console.ReadKey();
        }

		private static void EatCandy(CandyStorage db)
		{
			throw new NotImplementedException();
		}
	}
}
