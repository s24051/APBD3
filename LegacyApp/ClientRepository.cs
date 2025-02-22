﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository : IClientRepository
    {
        /// <summary>
        /// This collection is used to simulate remote database
        /// </summary>
        public static readonly Dictionary<int, Client> Database = new Dictionary<int, Client>()
        {
            {1, new Client{ClientId = 1, Name = "Kowalski", Address = "Warszawa, Złota 12", Email = "kowalski@wp.pl", Type = ClientType.NORMAL}},
            {2, new Client{ClientId = 2, Name = "Malewski", Address = "Warszawa, Koszykowa 86", Email = "malewski@gmail.pl", Type = ClientType.VIP}},
            {3, new Client{ClientId = 3, Name = "Smith", Address = "Warszawa, Kolorowa 22", Email = "smith@gmail.pl", Type = ClientType.IMPORTANT}},
            {4, new Client{ClientId = 4, Name = "Doe", Address = "Warszawa, Koszykowa 32", Email = "doe@gmail.pl", Type = ClientType.IMPORTANT}},
            {5, new Client{ClientId = 5, Name = "Kwiatkowski", Address = "Warszawa, Złota 52", Email = "kwiatkowski@wp.pl", Type = ClientType.NORMAL}},
            {6, new Client{ClientId = 6, Name = "Andrzejewicz", Address = "Warszawa, Koszykowa 52", Email = "andrzejewicz@wp.pl", Type = ClientType.NORMAL}}
        };
        
        public ClientRepository()
        {
        }

        public Client GetClient(int clientId)
        {
            return GetById(clientId);
        }

        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        internal Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (Database.ContainsKey(clientId))
                return Database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }
}