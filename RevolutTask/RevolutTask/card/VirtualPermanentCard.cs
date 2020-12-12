using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.card
{
    public class VirtualPermanentCard : Card
    {
        public const String VIRTUAL_PERMANENT_CARD = "Virtual Permanent Card";

        public VirtualPermanentCard(String number, int pin, DateTime expirationDate) : base(number, pin, expirationDate)
        { }

        public override string GetCardType()
        {
            return VIRTUAL_PERMANENT_CARD;
        }
    }
}
