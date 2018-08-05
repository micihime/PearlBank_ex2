namespace PearlBank.Models
{
    interface ISave
    {
        void Save(System.IO.TextWriter textOut);
        bool Save(string filename);
    }
}
