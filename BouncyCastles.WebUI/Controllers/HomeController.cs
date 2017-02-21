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

        public ActionResult Index()
        {
            BouncyCastlesModels BouncyCastlesModel = new BouncyCastlesModels(new Client(), new Order(), this.castleRepository.Castles);
            return View(BouncyCastlesModel);
        }

        [HttpPost]
        public ActionResult Index(BouncyCastlesModels BouncyCastlesModel)
        {

            return View(BouncyCastlesModel);
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