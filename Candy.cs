using System;
using System.Collections.Generic;

namespace candy_market
{
    internal class Candy
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public string Flavor { get; set; }
        public DateTime DateRecieved { get; }

        public Candy(string name, string manufacturer,  string flavor, DateTime date)
        {
            Name = name;
            Manufacturer = manufacturer;
            Flavor = flavor;
            DateRecieved = date;
        }
    }
}