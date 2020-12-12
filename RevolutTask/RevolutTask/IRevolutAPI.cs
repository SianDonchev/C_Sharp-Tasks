using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutTask.card;
using RevolutTask.account;

namespace RevolutTask
{
    public interface IRevolutAPI
    { 
        bool Pay(ICard card, int pin, double amount, String currency);

        bool PayOnline(ICard card, int pin, double amount, String currency, String shopURL);
     
        bool AddMoney(Account account, double amount);

        bool TransferMoney(Account from, Account to, double amount);
        
        double GetTotalAmount();
    }
}
