using System;

namespace Player
{
    public class Walet : IWalet
    {
        public int Moneay { get; private set; }

        public void Add(int money)
        {
            if (money <= 0)
                throw new ArgumentException();

            Moneay += money;
        }

        public void Take(int money)
        {
            if (money <= 0)
                throw new ArgumentException();

            Moneay -= money;
        }
    }
}
