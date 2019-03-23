using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    public class CandyStorage
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
            var flavor = _myCandy[0].Flavor;

            //foreach (object candy in _myCandy)
            //{
            //    Console.WriteLine(cand);
            //}

            for (int i = 0; i < _myCandy.Count; i++)
            {
                var candyName = _myCandy[i].Name;
                var candyMfc = _myCandy[i].Manufacturer;
                var candyFlavor = _myCandy[i].Flavor;

                Console.WriteLine($"Name: {candyName}, MFC: {candyMfc}, Flavor: {candyFlavor}");
            }

            //Console.WriteLine($"Name: {name} Manufacturer: {mfc} Flavor: {flavor}");

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
