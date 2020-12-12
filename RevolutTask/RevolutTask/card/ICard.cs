using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutTask.card
{
    public interface ICard
    {
        String GetCardType();

        DateTime GetExpirationDate();

        bool CheckPin(int pin);

        bool IsBlocked();

        void Block();

    }
}
