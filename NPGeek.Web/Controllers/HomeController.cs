using NPGeek.Web.DAL;
using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        IParkDAL parkDAL;
        IWeatherDAL weatherDAL;

        public HomeController(IParkDAL parkDAL, IWeatherDAL weatherDAL)
        {
            this.parkDAL = parkDAL;
            this.weatherDAL = weatherDAL;
        }
        
        public ActionResult Index()
        {
            List<NationalPark> parks = parkDAL.GetAllParks();
            
            return View("Index", parks);
        }

        public ActionResult ParkDetail(string id)
        {
            NationalPark park = parkDAL.GetParkByParkCode(id);
            
            return View("ParkDetail", park);
        }

        public ActionResult Weather(string id)
        {
            List<Weather> fiveDayWeather = weatherDAL.GetFiveDayWeatherByParkCode(id);
            
            string units = GetUnitsFromSession();
            fiveDayWeather[0].Units = units;

            return PartialView("Weather", fiveDayWeather);
        }

        [HttpPost]
        public ActionResult Weather(string id, string units)
        {
            Session["units"] = units;
            return RedirectToAction("ParkDetail", new { id = id, units = units });
        }

        private string GetUnitsFromSession()
        {
            if(string.IsNullOrEmpty(Session["units"] as string))
            {
                Session["units"] = "Fahrenheit";
            }

            return Session["units"] as string;
        }

    }
}