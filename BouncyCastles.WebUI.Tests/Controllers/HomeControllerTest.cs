using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BouncyCastles.WebUI;
using BouncyCastles.WebUI.Controllers;
using Moq;
using BouncyCastles.Domain.Entities;
using BouncyCastles.Domain.Abstract;
using BouncyCastles.Domain.Concrete;
using BouncyCastles.WebUI.Models;

namespace BouncyCastles.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IEFBouncyCastlesRepository castleRepository;

        public HomeControllerTest()
        {

        }
        public HomeControllerTest(IEFBouncyCastlesRepository castleRepository)
        {
            this.castleRepository = castleRepository;
        }


        //[TestMethod]
        //public void CheckOrder()
        //{
        //    // Arrange
        //    Client client = new Client()
        //    {
        //        Name = "TestName",
        //        Surname = "TestSurname",
        //        PhoneNumber = 25335
        //    };
        //    int castleID = 1;

        //    Order order = new Order()
        //    {
        //        AdrStreet = "TestStreet",
        //        AdrZipCode = "TestZipCode",
        //        AdrCity = "TestCity",
        //        AdrRegion = "TestRegion",
        //        StartDay = DateTime.Now,
        //        EndDay = DateTime.Now,
        //    };

        //    // Act
        //    EFBouncyCastlesRepository repository = new EFBouncyCastlesRepository();        
        //    bool insertClient = repository.setOrder(order, client, castleID);

        //    // Assert
        //    Assert.IsTrue(insertClient);
        //}

         [TestMethod]
        public void checkgetAvailability()
        {
            // Arrange
            int castleID = 1;

            Order order = new Order()
            {
                StartDay = DateTime.Now,
                EndDay = DateTime.Now,
            };

            // Act         
            EFBouncyCastlesRepository repository = new EFBouncyCastlesRepository();
            bool availability = repository.getAvailability(castleID, order.StartDay, order.EndDay);

            // Assert
            Assert.IsTrue(availability);
        }

        [TestMethod]
        public void checkCastle()
        {
            // Arrange
            int castleID = 1;


            // Act         
            EFBouncyCastlesRepository repository = new EFBouncyCastlesRepository();
            Domain.Entities.Castle castle = repository.getCastle(castleID);

            // Assert
            Assert.AreEqual("Petit", castle.Type);
        }


    }
}
