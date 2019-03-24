using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    public class CandyStorage
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
            return newCandy;
        }

        internal void EatChosenCandy(string candyToEat)
        {

            var candiesSelected = _myCandy
                .FindAll(matchedCandy => (matchedCandy.Name == candyToEat));
            var oldestCandyToEat = GetOldestCandy(candiesSelected);
            RemoveCandyFromInventory(oldestCandyToEat);
            AddCandyToEatenList(oldestCandyToEat);
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

        internal void tradeCandy(string tradeCandy, string newCandy, CandyStorage ownerName)
        {
            var ownerCandy = _myCandy.Find(candy => candy.Name == tradeCandy);
            var traderCandy = ownerName._myCandy.Find(candy => candy.Name == newCandy);

            //Adds new candies to each owners' lists
            ownerName.SaveNewCandy(ownerCandy);
            _myCandy.Add(traderCandy);

            //Removes traded candies from owners' lists
            ownerName.RemoveCandyFromInventory(traderCandy);
            _myCandy.Remove(ownerCandy);
        }

        internal List<Candy> CandyFlavor(string flavor)
        {
            var flavorCandy = _myCandy.FindAll(candy => (candy.Flavor == flavor));
            return flavorCandy;
        }

        internal void DisplayCandies()
        {
            for (int i = 0; i < _myCandy.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_myCandy[i].Name}");
            }
        }
    }
}
