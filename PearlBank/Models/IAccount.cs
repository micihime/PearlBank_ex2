namespace PearlBank.Models
{
    public interface IAccount
    {
        AccountState State { get; set; }

        //bool AccountAllowed(decimal income, int age); //static
        string GetName();

        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
        
        string RudeLetterString();
    }
}
