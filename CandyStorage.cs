using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    internal class CandyStorage
    {
        List<Candy> _myCandy = new List<Candy>();
        List<Candy> _eatenCandy = new List<Candy>();

        public string Owner { get; set; }

        public CandyStorage(string name)
        {
            Owner = name.ToLower();
        }

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

            return newCandy;
        }

        internal void EatChosenCandy(string candyToEat)
        {

            var candiesSelected = _myCandy
                .FindAll(matchedCandy => (matchedCandy.Name == candyToEat));
            var oldestCandyToEat = GetOldestCandy(candiesSelected);
            RemoveCandyFromInventory(oldestCandyToEat);
            AddCandyToEatenList(oldestCandyToEat);
            Console.WriteLine($"You have eaten a {oldestCandyToEat.Name}. Press any key to continue");
            Console.ReadKey();
        }

        internal Candy GetOldestCandy(List<Candy> selectedCandies)
        {
            return selectedCandies.Find(x => x.DateRecieved == OldestCandy(selectedCandies));
        }

        internal DateTime OldestCandy(List<Candy> selectedCandies)
        {
            return selectedCandies.Min(candy => candy.DateRecieved);
        }

        internal void RemoveCandyFromInventory(Candy candyToRemove)
        {
            _myCandy.Remove(candyToRemove);
        }

        internal void AddCandyToEatenList(Candy candyToEat)
        {
            _eatenCandy.Add(candyToEat);
        }

        internal List<Candy> ShowList()
        {
            return _myCandy;
        }

        internal List<Candy> CandyFlavor(string flavor)
        {
            var flavorCandy = _myCandy.FindAll(candy => (candy.FlavorCategory == flavor));
            return flavorCandy;
        }
    }
}
