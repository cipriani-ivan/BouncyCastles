using BouncyCastles.Domain.Abstract;
using BouncyCastles.Domain.Entities;
using BouncyCastles.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            //order.StartDay = DateTime.Now;
            //order.EndDay = DateTime.Now;
            BouncyCastlesModels BouncyCastlesModel = new BouncyCastlesModels(new Client(), order, this.castleRepository.Castles.ToList());
            return View(BouncyCastlesModel);
        }

        [HttpPost]
        public ActionResult Index(BouncyCastlesModels bouncyCastlesModel, int castleID)
        {
            bouncyCastlesModel.Castles = new List<Castle>();
            bouncyCastlesModel.Castles.Add(this.castleRepository.getCastle(castleID));

            if (ModelState.IsValid)
            {
                //Check if the castle seletected is available for all the days
                if (this.castleRepository.getAvailability(castleID, bouncyCastlesModel.Orders.StartDay, bouncyCastlesModel.Orders.EndDay))
                {
                    bool checkOrder = this.castleRepository.setOrder(bouncyCastlesModel.Orders, bouncyCastlesModel.Clients, castleID);
                    //Check if the order is stored in the db
                    if (!checkOrder)
                    {
                        bouncyCastlesModel.Castles = this.castleRepository.Castles.ToList();
                        ModelState.AddModelError("DB", ConfigurationManager.AppSettings.Get("DBError"));
                        return View(bouncyCastlesModel);
                    }
                    return RedirectToAction("Index", new { message = ConfigurationManager.AppSettings.Get("successMessage") });
                }
                else
                {
                    bouncyCastlesModel.Castles = this.castleRepository.Castles.ToList();
                    ModelState.AddModelError("NotAvailable", ConfigurationManager.AppSettings.Get("NotAvailableError"));
                    return View(bouncyCastlesModel);
                }
            }
            else
            {
                bouncyCastlesModel.Castles = this.castleRepository.Castles.ToList();
                return View(bouncyCastlesModel);
            }
        }
    }
}