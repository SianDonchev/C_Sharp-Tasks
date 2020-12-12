using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.account
{
    public class EURAccount : Account
    {
        public EURAccount(String IBAN) : base(IBAN)
        { }

        public EURAccount(String IBAN, double amount) : base(IBAN, amount)
        { }

        public override string GetCurrency()
        {
            return "EUR";
        }
    }
}
