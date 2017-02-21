using BouncyCastles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BouncyCastles.WebUI.Models
{
    public class BouncyCastlesModels
    {
        public Client Clients { get; set; }
        public Order Orders { get; set; }
        public IEnumerable<Castle> Castles { get; set; }

        public BouncyCastlesModels(Client Clients, Order Orders, IEnumerable<Castle> Castles)
        {
            this.Clients = Clients;
            this.Castles = Castles;
            this.Orders = Orders;
        }

    }
}