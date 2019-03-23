using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    public class CandyStorage
    {
        static List<Candy> _myCandy = new List<Candy>();
        static List<Candy> _eatenCandy = new List<Candy>();

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
            var flavor = _myCandy[0].Flavor;

            for (int i = 0; i < _myCandy.Count; i++)
            {
                var candyName = _myCandy[i].Name;
                var candyMfc = _myCandy[i].Manufacturer;
                var candyFlavor = _myCandy[i].Flavor;

                Console.WriteLine($"Name: {candyName}, MFC: {candyMfc}, Flavor: {candyFlavor}");
            }

            Console.ReadLine();

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

        internal List<Candy> CandyFlavor(string flavor)
        {
            var flavorCandy = _myCandy.FindAll(candy => (candy.Flavor == flavor));
            return flavorCandy;
        }
    }
}
