using System.Collections.Generic;
using BouncyCastles.Domain.Entities;

namespace BouncyCastles.Domain.Abstract
{
    public interface IEFBouncyCastlesRepository
    {
        IEnumerable<Castle> Castles { get; }
        IEnumerable<Client> Clients { get; }
        IEnumerable<Order> Orders { get; }
    }
}
