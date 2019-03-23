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
    }
}
