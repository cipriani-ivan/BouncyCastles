using System.Collections.Generic;
using BouncyCastles.Domain.Entities;
using System;

namespace BouncyCastles.Domain.Abstract
{
    public interface IEFBouncyCastlesRepository
    {
        IEnumerable<Castle> Castles { get; }
        IEnumerable<Client> Clients { get; }
        IEnumerable<Order> Orders { get; }

        Castle getCastle(int CastleID);

        bool getAvailability(int CastleID, DateTime start, DateTime end);

        void setOrder(Order order, Client client, int castleID);
    }
}
