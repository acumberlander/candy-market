using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    internal class CandyStorage
    {
        static List<Candy> _myCandy = new List<Candy>();

        internal IList<string> GetCandyTypes()
        {
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
            var flavor = _myCandy[0].FlavorType;

            Console.WriteLine($"Name: {name} Manufacturer: {mfc} Flavor: {flavor}");
            Console.ReadLine();
            return newCandy;
        }
    }
}
