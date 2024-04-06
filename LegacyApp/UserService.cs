using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditService;
        private IDataAccess _dataAccess;

        [Obsolete]
        public UserService() : this(
            new ClientRepository(), 
            new UserCreditService(),
            new UserDataAccessAdapter())
        {
        }
        
        public UserService(
            IClientRepository clientRepository, 
            ICreditLimitService creditService, 
            IDataAccess dataAccess)
        {
            // Use ClientRepo as default
            _clientRepository = clientRepository;
            _creditService = creditService;
            _dataAccess = dataAccess;
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var user = new User(firstName, lastName, email, dateOfBirth);
            if (!user.validateCredentials() || !user.validateAge(DateTime.Now))
                return false;
            
            var client = _clientRepository.GetClient(clientId);
            client.CreditLimit = _creditService.GetCredit(user.LastName, user.DateOfBirth, client.Type);
            client.HasCreditLimit = _creditService.HasLimit(client.Type);
            
            if (!client.validateCreditCapabilities())
                return false;
            
            _dataAccess.AddUser(user);
            return true;
        }
    }
}
