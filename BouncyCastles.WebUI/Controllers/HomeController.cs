using BouncyCastles.Domain.Abstract;
using BouncyCastles.Domain.Entities;
using BouncyCastles.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BouncyCastles.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IEFBouncyCastlesRepository castleRepository;

        public HomeController()
        {

        }
        public HomeController(IEFBouncyCastlesRepository castleRepository)
        {
            this.castleRepository = castleRepository;
        }

        public ActionResult Index(string message)
        {
            ViewBag.Message = String.IsNullOrEmpty(message) ? null : message;
            Order order = new Order();
            order.StartDay = DateTime.Now;
            order.EndDay = DateTime.Now;
            BouncyCastlesModels BouncyCastlesModel = new BouncyCastlesModels(new Client(), order, this.castleRepository.Castles.ToList());
            return View(BouncyCastlesModel);
        }

        [HttpPost]
        public ActionResult Index(BouncyCastlesModels bouncyCastlesModel, int castleID)
        {
            bouncyCastlesModel.Castles = new List<Castle>();
            bouncyCastlesModel.Castles.Add(this.castleRepository.getCastle(castleID));

            if (ModelState.IsValid && this.castleRepository.getAvailability(castleID, bouncyCastlesModel.Orders.StartDay, bouncyCastlesModel.Orders.EndDay))
            {
                this.castleRepository.setOrder(bouncyCastlesModel.Orders, bouncyCastlesModel.Clients, castleID);
                return RedirectToAction("Index", new { message = "The order is completed. You can started another order." });
            }
            else
            {
                bouncyCastlesModel.Castles = this.castleRepository.Castles.ToList();
                return View(bouncyCastlesModel);
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}