using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class Changer
    {
        public static double dollar = 81;
        public static double grivna = 3;
        public static double euro = 90;
        public static double rubl = 1.2;


        public static double change(double amount, double rate1, double rate2)
        {
            return amount * rate1 / rate2;
        }
        public static double choose(string text)
        {
            double amount = 1;
            switch (text)
            {
                case "dollar":
                    amount = dollar;
                    break;
                case "euro":
                    amount = euro;
                    break;
                case "grivna":
                    amount = grivna;
                    break;
                case "rubl":
                    amount = rubl;
                    break;
            }
            return amount;
        }
        public static double num(double rate)
        {
            Random random = new Random();
            return random.Next(Convert.ToInt32(-rate / 30), Convert.ToInt32(rate / 30));

        }
    }
}
