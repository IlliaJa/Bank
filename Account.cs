using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account : IComparable<Account>
    {
        public List<Offer> deposits = new List<Offer>();
        public List<Offer> kredits = new List<Offer>();
        public List<Account> accounts = new List<Account>();
        public Account account;
        string name { get; set; }
        int id { get; set; }
        string surname { get; set; }
        string password { get; set; }
        int managerId { get; set; }


        public Account(string name, string surname, string password)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
        }
        internal void AddDeposit(Deposit dep)
        {
            deposits.Add(dep);
        }
        internal void AddKredit(Kredit kred)
        {
            kredits.Add(kred);
        }
        internal List<Offer> GetDeposits()
        {
            return deposits;
        }
        internal List<Offer> GetKredits()
        {
            return kredits;
        }
        internal void AddAccount(Account account)
        {
            accounts.Add(account);
        }
        public int CompareTo(Account account)
        {
            if (this.password == account.password)
            {
                return this.name.CompareTo(account.name);
            }
            return account.password.CompareTo(this.password);
        }
        internal bool DoesExist()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts.Contains(account))
                    return true;
            }
            return false;
        }

        public List<Offer> DeleteDeposit(int id)
        {
            foreach (Offer deposit in this.deposits.ToList())
            {
                if (deposit.id == id)
                {
                    this.deposits.Remove(deposit);
                }
            }
            return this.deposits;
        }

        public List<Offer> DeleteKredit(int id)
        {
            foreach (Offer kredit in this.kredits.ToList())
            {
                if (kredit.id == id)
                {
                    this.kredits.Remove(kredit);
                }
            }
            return this.kredits;
        }
    }
}
