namespace PearlBank.Models
{
    interface IBank
    {
        IAccount FindAccount(string name);
        bool StoreAccount(IAccount account);
    }
}
