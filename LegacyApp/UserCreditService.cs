using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable, ICreditLimitService
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000}
            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }

        public int GetCredit(string lastName, DateTime dateOfBirth, ClientType type)
        {
            int limit = GetCreditLimit(lastName, dateOfBirth);
            switch (type)
            {
                case ClientType.IMPORTANT:
                    return limit * 2;
                case ClientType.VIP:
                    return limit;
                default:
                    return 0;
            }
        }

        public bool HasLimit(ClientType type)
        {
            switch (type)
            {
                case ClientType.VIP:
                    return false;
                case ClientType.NORMAL:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        internal int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
                return _database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }
    }
}