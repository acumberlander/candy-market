using System;

namespace candy_market
{
    internal class Candy
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public Flavor FlavorType { get; }
        public DateTime DateRecieved { get; }

        public Candy(string name, string manufacturer,  Flavor flavor)
        {
            Name = name;
            Manufacturer = manufacturer;
            FlavorType = flavor;
            DateRecieved = DateTime.Now;
        }
    }
    enum Flavor
    {
        sour,
        sweet
    }
}