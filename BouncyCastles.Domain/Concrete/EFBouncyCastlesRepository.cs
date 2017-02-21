using BouncyCastles.Domain.Abstract;
using BouncyCastles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastles.Domain.Concrete
{
    public class EFBouncyCastlesRepository : IEFBouncyCastlesRepository
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<Castle> Castles
        {
            get { return context.Castles; }
        }
        public IEnumerable<Client> Clients
        {
            get { return context.Clients; }
        }
        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

    }
}