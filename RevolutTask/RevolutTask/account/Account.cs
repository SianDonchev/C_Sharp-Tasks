using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.account
{
    public abstract class Account
    {
        private double amount;
        private String IBAN;

        public Account(String IBAN) : this(IBAN, 0)
        {}

        public Account(String IBAN, double amount)
        {
            this.IBAN = IBAN;
            this.amount = amount;
        }

        public abstract String GetCurrency();

        public double GetAmount()
        {
            return amount;
        }

        public void AddMoney(double amount)
        {
            this.amount += amount;
        }

        public void WithdrawMoney(double amount)
        {
            this.amount -= amount;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj.GetType().IsAssignableFrom(this.GetType()) && obj != null)
            {
                return this.IBAN.Equals((obj as Account).IBAN);
            }
            return false;
        }

        // complete the implementation

        public override int GetHashCode()
        {
            return IBAN.GetHashCode();
        }
    }
}
