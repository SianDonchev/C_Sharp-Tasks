using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutTask.card;

namespace RevolutTask.card
{
    public abstract class Card : ICard
    {
        String number;
        int pin;
        DateTime expirationDate;
        bool isBlocked;
        short counterForMissedPin;
        private const int BLOCK_MARKER = 3;

        public Card(String number, int pin, DateTime expirationDate)
        {
            this.pin = pin;
            this.number = number;
            this.expirationDate = expirationDate;
            this.isBlocked = false;
            counterForMissedPin = 0;
        }

        public void Block()
        {
            this.isBlocked = true;
        }

        public virtual bool CheckPin(int pin)
        {
            if (this.pin == pin)
            {
                resetCounterForMissedPins();
                return true;
            }

            increaseCounterForMissedPins();
            if (mustBeBlocked())
            {
                Block();
            }

            return false;
        }

        public DateTime GetExpirationDate()
        {
            return this.expirationDate;
        }

        public abstract string GetCardType();

        public bool IsBlocked()
        {
            return isBlocked;
        }

        private void increaseCounterForMissedPins()
        {
            ++counterForMissedPin;
        }

        private bool mustBeBlocked()
        {
            return this.counterForMissedPin == BLOCK_MARKER;
        }

        private void resetCounterForMissedPins()
        {
            counterForMissedPin = 0;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj.GetType().IsAssignableFrom(this.GetType()) && obj != null)
            {
                return this.number == (obj as Card).number;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return number.GetHashCode();
        }
    }
}
