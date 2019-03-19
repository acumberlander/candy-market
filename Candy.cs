using System;

namespace candy_market
{
    internal class Candy
    {
        public string Name { get; set; }
        public string Manufacturer { get; }
        public string FlavorCategory { get; }
        public DateTime DateRecieved { get; }

        public Candy(string name, string manufacturer, string falvorCategory)
        {
            Name = name;
            Manufacturer = manufacturer;
            FlavorCategory = FlavorCategory;
            DateRecieved = DateTime.Now;
        }
    }
}