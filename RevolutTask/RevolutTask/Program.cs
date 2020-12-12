using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutTask.card;
using RevolutTask.account;

namespace RevolutTask
{
    public class Program
    {
        static void Main(string[] args)
        {

            ICard card1 = new PhysicalCard("a1", 123, DateTime.Today.AddDays(1));
            ICard card2 = new VirtualOneTimeCard("a2", 123, DateTime.Today.AddDays(1));
            ICard card3 = new VirtualPermanentCard("a3", 123, DateTime.Today.AddDays(1));
            ICard card4 = new VirtualPermanentCard("a4", 123, DateTime.Now);
            ICard card5 = new PhysicalCard("a5", 123, DateTime.Today.AddDays(1));
            ICard card6 = new PhysicalCard("a6", 123, DateTime.Today.AddDays(-1));

            Account account1 = new BGNAccount("12311", 100);
            Account account2 = new BGNAccount("12322", 100);
            Account account3 = new BGNAccount("12333", 100);
            Account account4 = new BGNAccount("12344", 100);
            Account account5 = new BGNAccount("12355", 100);
            Account account6 = new BGNAccount("12366", 100);
            Account account7 = new EURAccount("12367", 100);

            Account[] accounts = new Account[7];
            accounts[0] = account1;
            accounts[1] = account2;
            accounts[2] = account3;
            accounts[3] = account4;
            accounts[4] = account5;
            accounts[5] = account6;
            accounts[6] = account7;

            ICard[] cards = new Card[6];
            cards[0] = card1;
            cards[1] = card2;
            cards[2] = card3;
            cards[3] = card4;
            cards[4] = card5;
            cards[5] = card6;

            IRevolutAPI revolut = new Revolut(accounts,cards);

            Console.WriteLine(revolut.PayOnline(card3, 123, 50, "BGN","site.biz"));
            Console.WriteLine(revolut.PayOnline(card3, 123, 100, "BGN", "site1.com"));
            Console.WriteLine(revolut.PayOnline(card2, 123, 50, "BGN", ".biz.site1.com"));
            Console.WriteLine(revolut.PayOnline(card2, 123, 1, "BGN", "site1.com"));
            Console.WriteLine(revolut.Pay(card1, 123, 50, "BGN"));

            Console.WriteLine(revolut.TransferMoney(account1, account2, 30));
            Console.WriteLine(revolut.GetTotalAmount());
            Console.WriteLine(revolut.AddMoney(account3,1000));
            Console.WriteLine(revolut.GetTotalAmount());
        }
    }
}
