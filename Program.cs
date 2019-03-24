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

            var FlavorList = new List<string>();

            FlavorList.Add("sour");
            FlavorList.Add("sweet");
            FlavorList.Add("bitter");
            FlavorList.Add("savory");

            var dylan = new CandyStorage("Dylan");
            dylan.SaveNewCandy(new Candy("Snickers", "Mars", "Chocolate", new DateTime(2019, 12, 23)));
            dylan.SaveNewCandy(new Candy("Butterfinger", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            dylan.SaveNewCandy(new Candy("Twix", "Mars", "Caramel", new DateTime(2019, 12, 23)));

            var austin = new CandyStorage("Austin");
            austin.SaveNewCandy(new Candy("Snickers", "Mars", "Chocolate", new DateTime(2019, 12, 23)));
            austin.SaveNewCandy(new Candy("Butterfinger", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            austin.SaveNewCandy(new Candy("Twix", "Mars", "Caramel", new DateTime(2019, 12, 23)));

            var jonathan = new CandyStorage("Jonathan");
            jonathan.SaveNewCandy(new Candy("Snickers", "Mars", "Chocolate", new DateTime(2019, 12, 23)));
            jonathan.SaveNewCandy(new Candy("Butterfinger", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            jonathan.SaveNewCandy(new Candy("Twix", "Mars", "Caramel", new DateTime(2019, 12, 23)));

            jonathan.ShowList();
            austin.ShowList();

            austin.tradeCandy("Snickers", "Butterfinger", jonathan);

            var users = new Users();

            users.AddOwner(dylan);
            users.AddOwner(austin);
            users.AddOwner(jonathan);

            Console.WriteLine("Enter User Name");
            var db = SetupNewApp(Console.ReadLine());
            users.AddOwner(db);
            db.SaveNewCandy(new Candy("Snickers", "Mars", "Chocolate", new DateTime(2019, 12, 23)));
            db.SaveNewCandy(new Candy("Butterfinger", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            db.SaveNewCandy(new Candy("Twix", "Mars", "Caramel", new DateTime(2019, 12, 23)));


            db.SaveNewCandy(new Candy("Snickers", "Mars", "Chocolate", new DateTime(2019, 12, 23)));
            db.SaveNewCandy(new Candy("Butterfinger", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            db.SaveNewCandy(new Candy("Twix", "Mars", "Caramel", new DateTime(2019, 12, 23)));
            var exit = false;
			while (!exit)
			{
				var userInput = MainMenu();
				exit = TakeActions(db, userInput, FlavorList, users);
			}
        }

        static List<Candy> filterCandy(string candyFlavor, CandyStorage db)
        {
            var candyList = db.ShowList();
            var filteredCandyList = candyList.FindAll(candy => candy.Flavor == candyFlavor);
            return filteredCandyList;
        }

        static void flavorLister(List<string> flavorList)
        {
            foreach(string flavor in flavorList)
                {
                    Console.WriteLine(flavor);
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
					.AddMenuOption("Choose candy by the flavor. Choose it here.")
                    .AddMenuOption("Would you like to trade some candy?")
					.AddMenuText("Press Esc to exit.");
			Console.Write(mainMenu.GetFullMenu());
			var userOption = Console.ReadKey();
			return userOption;
		}

		private static bool TakeActions(CandyStorage db, ConsoleKeyInfo userInput, List<string> FlavorList, Users users)
		{
			Console.Write(Environment.NewLine);

			if (userInput.Key == ConsoleKey.Escape)
				return true;

			var selection = userInput.KeyChar.ToString();
			switch (selection)
			{
				case "1": AddNewCandy(db, FlavorList);
                    return false;

                case "2": EatCandy(db);
                    return false;

                case "3": EatRandomCandy(db, FlavorList);
                    return false;

                case "4": TradeCandy(users);
                    return false;
                default: return false;
			}
		}

        static void EatRandomCandy(CandyStorage db, List<string> FlavorList)
        {
            flavorLister(FlavorList);
            var choosenFlavor = Console.ReadLine();
            var filteredCandy = filterCandy(choosenFlavor, db);
            if (filteredCandy.Count < 0)
            {
                throw new Exception("You don't have any candy of that type! Check yo list!");
            }
            var randNum = Rando(filteredCandy);

            Console.WriteLine(filteredCandy[randNum].Name);
            Console.ReadKey();
        }

		internal static void AddNewCandy(CandyStorage db, List<string> FlavorList)
		{


            Console.WriteLine("What is the name of your candy?");
            string Name = Console.ReadLine().ToString();

            Console.WriteLine("Who is the manufacturer of your candy?");
            string Manufacturer = Console.ReadLine().ToString();

            Console.WriteLine("Choose your candy flavor: ");
            foreach(string flavor in FlavorList)
            {
                Console.WriteLine(flavor);
            }

            string Flavor = Console.ReadLine().ToLower();

            Console.WriteLine("When did you buy this candy? [EX] 2010, 12, 23");
            Console.WriteLine("Enter Year:");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month:");
            int Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Day:");
            int Day = Convert.ToInt32(Console.ReadLine());

            var DateReceived = new DateTime(Year, Month, Day);

            var newCandy = new Candy(Name, Manufacturer, Flavor, DateReceived);
            db.SaveNewCandy(newCandy);
            Console.WriteLine($"Now you own the candy {newCandy.Name}");
            Console.ReadKey();
        }

        static int Rando(List<Candy> filteredList)
        {
            Random random = new Random();
            int rdmNum = random.Next(0, filteredList.Count - 1);
            return rdmNum;
        } 

		private static void EatCandy(CandyStorage db)
		{
            int increment = 0;
            var candiesInList = db.ShowList();
            Console.WriteLine("Enter number corresponding to the desired candy to eat:\n");
            foreach (var candy in candiesInList)
            {
                increment++;
                Console.Write($"{increment})\t {candy.Name}\n");
            }
            var selectedCandy = Convert.ToInt32(Console.ReadLine()) - 1;
            db.EatChosenCandy(candiesInList[selectedCandy].Name);
        }

        private static void TradeCandy(Users users)
        {
            var loggedInUser = users.candyOwners[3];
            Console.WriteLine("Select a User to trade with: \n");
            users.DisplayOtherUsers(users);
            var selectedUserIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            var selectedUser = users.candyOwners[selectedUserIndex];

            Console.Write($"\nChoose a candy from {selectedUser.Owner}'s inventory:\n");
            selectedUser.DisplayCandies();

            var selectedIndexCandyToTrade = Convert.ToInt32(Console.ReadLine()) - 1;
            var selectedUsersCandy = selectedUser.ShowList()[selectedIndexCandyToTrade];
            Console.WriteLine($"\n{selectedUser.Owner} is trading {selectedUsersCandy.Name}");

            Console.WriteLine($"\nChoose a candy from your inventory to give");
            loggedInUser.DisplayCandies();

            var loggedUserIndexCandyToTrade = Convert.ToInt32(Console.ReadLine()) - 1;
            var loggedUsersCandy = loggedInUser.ShowList()[loggedUserIndexCandyToTrade];
            Console.WriteLine($"\n{loggedInUser.Owner} is trading {loggedUsersCandy.Name}");

            Console.WriteLine($"\nDo you want to trade your {loggedUsersCandy.Name} for {selectedUser.Owner}'s {selectedUsersCandy.Name}? (y/n)\n");
            var decisionToTrade = Console.ReadLine();

            if (decisionToTrade == "y")
            {
                loggedInUser.tradeCandy(selectedUsersCandy.Name, loggedUsersCandy.Name, selectedUser);
                Console.WriteLine("The trade is complete");
            }
            else
            {
                Console.WriteLine("The trade has been cancelled.");
            }
            Console.WriteLine("\nPress any key to return to the menu");
            Console.ReadKey();
        }
    }
}
