using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.card
{
    public class VirtualOneTimeCard : Card
    {
        public const String VIRTUAL_ONE_TIME_CARD = "Virtual One Time Card";

        public VirtualOneTimeCard(String number, int pin, DateTime expirationDate) : base(number, pin, expirationDate)
        {}

        public override bool CheckPin(int pin)
        {
            if (base.CheckPin(pin))
            {
                return true;
            }
            return false;
        }

        public override string GetCardType()
        {
            return VIRTUAL_ONE_TIME_CARD;
        }
    }
}
