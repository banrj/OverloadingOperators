using System;
namespace _2
{
	class Bankomat
	{
		public int Cash { get; private set; } = 0;

		public int Id { get; private set; }

		public int Max { get; private set; }

        public int Min { get; private set; }

        public Bankomat(int cash, int id, int max, int min)
        {
            Cash = cash;
            Id = id;
            Max = max;
            Min = min;
        }

        public override string ToString()
        {
            return $"Банкомат под номер {Id}\nИмеет сумму {Cash}";
        }

        public static int operator +(Bankomat bankomat, int money)
        {
            var totalCash = bankomat.Cash + money;
            bankomat.Cash = totalCash;

            return totalCash;
        }

        public static int operator -(Bankomat bankomat, int money)
        {
            if (bankomat.Max >= money || money >= bankomat.Min)
            {
                var totalCash = bankomat.Cash - money;
                bankomat.Cash = totalCash;
                return totalCash;
            }
            else
            {
                var totalCash = bankomat.Cash;
                return totalCash;
            }

        }

    }
}

