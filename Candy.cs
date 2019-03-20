using System;

namespace candy_market
{
    internal class Candy
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public string FlavorCategory { get; }
        public DateTime DateRecieved { get; }

        public Candy(string name, string manufacturer, string flavorCategory, DateTime date)
        {
            Name = name;
            Manufacturer = manufacturer;
            FlavorCategory = flavorCategory;
            DateRecieved = date;
        }
    }
}