namespace LegacyApp
{
    public class Client
    {
        public string Name { get; internal set; }
        public int ClientId { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public ClientType Type { get; set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        
        public bool validateCreditCapabilities()
        {
            if (HasCreditLimit && CreditLimit < 500)
            {
                return false;
            }
            return true;
        }
    }
}