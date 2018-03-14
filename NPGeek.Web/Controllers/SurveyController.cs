using NPGeek.Web.DAL;
using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class SurveyController : Controller
    {
        IParkDAL parkDAL;

        public SurveyController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }


        public ActionResult Index()
        {
            List<NationalPark> parks = parkDAL.GetAllParks();

            Survey survey = new Survey(parks);

            return View("Index", survey);
        }

        [HttpPost]
        public ActionResult Index(Survey survey)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SurveyResult");
            }
            List<NationalPark> parks = parkDAL.GetAllParks();
            Survey newSurvey = new Survey(parks)
            {
                ParkCode = survey.ParkCode,
                EmailAddress = survey.EmailAddress,
                State = survey.State,
                ActivityLevel = survey.ActivityLevel
            };
            return View("Index", newSurvey);
            
        }

        public ActionResult SurveyResult()
        {
            return View();
        }
    }
}