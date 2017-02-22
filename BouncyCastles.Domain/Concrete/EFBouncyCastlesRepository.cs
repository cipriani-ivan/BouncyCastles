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

        public Castle getCastle(int CastleID)
        {
            Castle castle = (from g in context.Castles where g.CastlesID == CastleID select g).SingleOrDefault();
            return castle;
        }

        public bool getAvailability(int castleID, DateTime start, DateTime end)
        {
            bool checkAvailability = true;

            for (DateTime startFor = start; startFor <= end; startFor =startFor.AddDays(1))
            {
                int numStock = (from g in context.Castles where g.CastlesID == castleID select g.NumStock).SingleOrDefault();

                int castleOrderForType = (from g in context.Orders
                                          where (g.CastlesID == castleID && (startFor >= g.StartDay && startFor <= g.EndDay))
                                          select g).Count();
                if (castleOrderForType >= numStock)
                    checkAvailability = false;
            }

            return checkAvailability;
        }

        public void setOrder(Order order, Client client, int castleID)
        {
            //TO DO: implement this part in a storeprocedure 
            context.Clients.Add(client);
            context.SaveChanges();
            order.CastlesID = castleID;
            order.ClientsID = (from g in context.Clients where g.Name == client.Name && g.Surname == client.Surname && g.PhoneNumber == client.PhoneNumber select g.ClientsID).FirstOrDefault();
            context.Orders.Add(order);
            context.SaveChanges();
        }

    }
}