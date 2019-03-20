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
            _myCandy.Add(new Candy("chicken", "bucket", "Sour"));
            _myCandy.Add(new Candy("man", "pail", "Sour"));
            _myCandy.Add(new Candy("chicken", "box", "meth"));

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
            var eatenCandy = _myCandy.Find(x => (x.Name == candyToEat)&&(x.DateRecieved == _myCandy.Min(y => y.DateRecieved)));
            _myCandy.Remove(eatenCandy);
            _eatenCandy.Add(eatenCandy);
        }
    }
}
