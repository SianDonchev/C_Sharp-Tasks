using RevolutTask.account;
using RevolutTask.card;
using System;
using System.Collections.Generic;

namespace RevolutTask
{
    public class Revolut : IRevolutAPI
    {
        const double EXCHANGE_RATE_EUR_TO_BGN = 1.95583;
        const string BANNED_SITE = ".biz";

        Account[] accounts;
        ICard[] cards;

        public Revolut(Account[] accounts, ICard[] cards)
        {
            this.accounts = accounts;
            this.cards = cards;
        }

        public bool AddMoney(Account account, double amount)
        {
            for (int i = 0; i < accounts.Length; ++i)
            {
                if (accounts[i].Equals(account))
                {
                    accounts[i].AddMoney(amount);
                    return true;
                }
            }

            return false;
        }

        public double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (Account account in accounts)
            {
                totalAmount += account.GetAmount();
            }
            return totalAmount;
        }

        public bool Pay(ICard card, int pin, double amount, string currency)
        {
            if (isAvailableCard(card) && card.GetCardType().Equals(PhysicalCard.PHYSICAL) && isValidCard(card))
            {
                if (!card.IsBlocked() && card.CheckPin(pin))
                {
                    return takeMoneyFromAccountIfExists(amount, currency);
                }
            }
            return false;
        }

        public bool PayOnline(ICard card, int pin, double amount, string currency, string shopURL)
        {
            if (!isShopURLBanned(shopURL))
            {
                if (isAvailableCard(card) && isValidCard(card))
                {
                    if (!card.IsBlocked() && card.CheckPin(pin))
                    {
                        if (card.GetCardType().Equals(VirtualOneTimeCard.VIRTUAL_ONE_TIME_CARD))
                        {
                            card.Block();
                        }
                        return takeMoneyFromAccountIfExists(amount, currency);
                    }
                }
            }
            return false;
        }

        public bool TransferMoney(Account from, Account to, double amount)
        {
            if (isAvailableAccount(from) && isAvailableAccount(to) && from != to && from.GetAmount() >= amount)
            {
                if (from.GetCurrency().Equals(to.GetCurrency()))
                {
                    from.WithdrawMoney(amount);
                    to.AddMoney(amount);
                }
                else if (to.GetCurrency().Equals("BGN"))
                {
                    from.WithdrawMoney(amount);
                    to.AddMoney(amount * EXCHANGE_RATE_EUR_TO_BGN);
                }
                else
                {
                    from.WithdrawMoney(amount);
                    to.AddMoney(amount / EXCHANGE_RATE_EUR_TO_BGN);
                }
                return true;
            }

            return false;
        }

        private bool isShopURLBanned(string shopURL)
        {
            int indexOfBiz = shopURL.IndexOf(BANNED_SITE);
            int lengthOfShopURL = shopURL.Length;
            int lengthOfBiz = BANNED_SITE.Length;

            return (indexOfBiz >= 0) && (indexOfBiz + lengthOfBiz == lengthOfShopURL);

        }

        private bool takeMoneyFromAccountIfExists(double amount, string currency)
        {
            foreach (Account account in accounts)
            {
                if (account.GetCurrency().Equals(currency) && account.GetAmount() >= amount)
                {
                    account.WithdrawMoney(amount);
                    return true;
                }
            }
            return false;
        }

        private bool isAvailableCard(ICard cardToFind)
        {
            foreach (Card card in cards)
            {
                if (card.Equals(cardToFind))
                {
                    return true;
                }
            }

            return false;
        }

        private bool isAvailableAccount(Account accountToFind)
        {
            foreach (Account account in accounts)
            {
                if (account.Equals(accountToFind))
                {
                    return true;
                }
            }

            return false;
        }

        private bool isValidCard(ICard card)
        {
            return DateTime.Now.CompareTo(card.GetExpirationDate()) == -1;
        }
    }
}
