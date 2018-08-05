namespace PearlBank.Models
{
    public class Account : IAccount, ISave
    {
        #region Private Frields

        private static decimal minIncome = 1;
        private static int minAge = 10;
        private static int maxAge = 100;

        // private member data 
        private string name;
        private string address;
        private int age;
        private decimal balance;
        private AccountState state;
        #endregion

        #region Properties

        public AccountState State { get; set; }
        #endregion

        #region Constructors

        public Account(string inName, string inAddress, decimal inBalance)
        {
            name = inName;
            address = inAddress;
            balance = inBalance;
            state = AccountState.New;
        }

        public Account(string inName, decimal inBalance) : this(inName, "Not Supplied", inBalance) { }

        public Account(System.IO.TextReader textIn)
        {
            name = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            balance = decimal.Parse(balanceText);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Sets the age.
        /// </summary>
        /// <param name="inAge">The in age.</param>
        /// <returns></returns>
        public bool SetAge(int inAge)
        {
            if ((inAge > minAge) && (inAge < maxAge))
            {
                this.age = inAge;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Accounts the allowed.
        /// </summary>
        /// <param name="income">The income.</param>
        /// <param name="age">The age.</param>
        /// <returns></returns>
        public static bool AccountAllowed(decimal income, int age)
        {
            if ((income >= minIncome) && (age >= minAge))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region implementing IAccount

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public string GetName() { return name; }

        /// <summary>
        /// Pays the in funds.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        /// <summary>
        /// Withdraws the funds.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <returns></returns>
        public decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Rudes the letter string.
        /// </summary>
        /// <returns></returns>
        public virtual string RudeLetterString()
        {
            return "You are overdrawn";
        }
        #endregion        

        #region implementing ISave

        public virtual void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(name);
            textOut.WriteLine(balance);
        }

        public bool Save(string filename)
        {
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch { return false; }
            finally
            {
                if (textOut != null)
                {
                    textOut.Close();
                }
            }
            return true;
        }

        public static Account Load(System.IO.TextReader textIn)
        {
            Account result = null;
            try
            {
                string name = textIn.ReadLine();
                string balanceText = textIn.ReadLine();
                decimal balance = decimal.Parse(balanceText);
                result = new Account(name, balance);
            }
            catch { return null; }
            return result;
        }
        #endregion

        #region overriden from object

        public override string ToString()
        {
            return "Name: " + name + ", balance: " + balance;
        }
        #endregion

        #endregion
    }
}