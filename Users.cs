using System;
using System.Collections.Generic;
using System.Text;

namespace candy_market
{
    public class Users
    {
        internal List<CandyStorage> candyOwners = new List<CandyStorage>();


        internal void AddOwner(CandyStorage owner)
        {
            candyOwners.Add(owner);
        }

        internal void DisplayOtherUsers(Users users)
        {
            for (int i = 0; i < candyOwners.Count - 1; i++)
            {
                Console.WriteLine($"{i + 1})\t {candyOwners[i].Owner}");
            }
        }
    }
}
