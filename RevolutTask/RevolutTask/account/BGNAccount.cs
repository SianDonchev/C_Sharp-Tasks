using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.account
{
    public class BGNAccount : Account
    {
        public BGNAccount(String IBAN) : base(IBAN)
        { }

        public BGNAccount(String IBAN, double amount) : base(IBAN, amount)
        { }

        public override string GetCurrency()
        {
            return "BGN";
        }
    }
}
