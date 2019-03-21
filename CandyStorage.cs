using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    internal class CandyStorage
    {
        static List<Candy> _myCandy = new List<Candy>();
        static List<Candy> _eatenCandy = new List<Candy>();

        internal IList<string> GetCandyTypes()
        {
            return _myCandy.Select(x=> x.Name).ToList();
            throw new NotImplementedException();
        }

        internal Candy SaveNewCandy(Candy newCandy)
        {

            _myCandy.Add(newCandy);
            if (newCandy == null)
            {
            throw new NotImplementedException();
            }

            var name = _myCandy[0].Name;
            var mfc = _myCandy[0].Manufacturer;
            var flavor = _myCandy[0].FlavorCategory;

            Console.WriteLine($"Name: {name} Manufacturer: {mfc} Flavor: {flavor}");
            Console.ReadLine();
            return newCandy;
        }

        internal void EatChosenCandy(string candyToEat)
        {
            var candiesSelected = _myCandy
                .FindAll(matchedCandy => (matchedCandy.Name == candyToEat));
            var oldestCandyToEat = GetOldestCandy(candiesSelected);
            _myCandy.Remove(oldestCandyToEat);
            _eatenCandy.Add(oldestCandyToEat);
        }

        internal Candy GetOldestCandy(List<Candy> selectedCandies)
        {
            return selectedCandies.Find(x => x.DateRecieved == OldestCandy(selectedCandies));
        }

        internal DateTime OldestCandy(List<Candy> selectedCandies)
        {
            return selectedCandies.Min(candy => candy.DateRecieved);
        }
    }
}
