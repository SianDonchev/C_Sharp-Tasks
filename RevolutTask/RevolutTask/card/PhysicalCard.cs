using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.card
{
    public class PhysicalCard : Card
    {
        public const String PHYSICAL = "Physical Card";

        public PhysicalCard(String number, int pin, DateTime expirationDate) : base(number, pin, expirationDate)
        {}

        public override string GetCardType()
        {
            return PHYSICAL;
        }
    }
}
