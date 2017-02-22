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
        public List<Castle> Castles { get; set; }

        public BouncyCastlesModels()
        {
        }

        public BouncyCastlesModels(Client Clients, Order Orders, List<Castle> Castles)
        {
            this.Clients = Clients;
            this.Castles = Castles;
            this.Orders = Orders;
        }

    }
}