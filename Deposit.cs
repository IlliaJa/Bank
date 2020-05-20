using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    [Serializable()]
    class Deposit : Offer
    {
        public Deposit(int amount, int percent, string currency, int id)
            : base(amount, percent, currency, id)
        { }
        public Deposit() { }
        List<Offer> deposits = new List<Offer>();

        public double CurrentSum(double sum)
        {
            sum = DoubleAmount() / 100 * Percent() + DoubleAmount();
            return sum;
        }

    }
}
