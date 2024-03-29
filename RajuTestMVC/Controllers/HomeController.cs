﻿using RajuTestMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RajuTestMVC.Controllers
{
    public class HomeController : Controller
    {
        AgriDBEntities db = new AgriDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult Details(string customerId)
        {
            
            return PartialView("Details", customerId);
        }

        [HttpGet]
        public ActionResult GetStates()
        {
            

            var states = db.MstStates.ToList();
            List<SelectListItem> stateList = new List<SelectListItem>();
            for (int i = 0; i < states.Count; i++)
            {
                stateList.Add(new SelectListItem
                {
                    Text = states[i].StateName,
                    Value = states[i].StateID.ToString()
                });
            }
            //foreach (State state in states)
            //{
            //    stateList.Add(new SelectListItem
            //    {
            //        Text = state.StateName,
            //        Value = state.StateId.ToString()
            //    });
            //}
            ViewBag.State = stateList;
            return View("GetStates");
        }
        [HttpGet]
        public ActionResult GetCities(int stateId)
        {
            
            var cities = db.MstDistricts.Where(s => s.StateID == stateId).ToList();
            List<SelectListItem> cityList = new List<SelectListItem>();
            for (int i = 0; i < cities.Count; i++)
            {
                cityList.Add(new SelectListItem
                {
                    Text = cities[i].DistrictName,
                    Value = cities[i].DistrictID.ToString()

                });

            }
            //foreach (City city in cities)
            //{

            //    cityList.Add(new SelectListItem
            //    {
            //        Text = city.CityName,
            //        Value = city.CityId.ToString()

            //    });
            //}
            ViewBag.City = cityList;
            return View("GetCities");
        }

        public PartialViewResult PartialView1()
        {
            // ViewBag.Message = "Contry list";

            var countryData = db.countries.ToList();
            List<SelectListItem> liContry = new List<SelectListItem>();
            liContry.Add(new SelectListItem { Text = "--Select Country--", Value = "0" });
            foreach (var x in countryData)
            {
                liContry.Add(new SelectListItem
                {
                    Text = x.countryName,
                    Value = x.countryID.ToString()
                });
            }
            ViewBag.GetCountry = liContry;
            return PartialView();
        }

        public PartialViewResult GetState(string CountryID)
        {
            var states = db.cities.Where(x => x.countryID == CountryID).ToList();

            // SelectList stList = new SelectList(states, "stateID", "stateName", "countryID");
            List<SelectListItem> liState = new List<SelectListItem>();
            liState.Add(new SelectListItem { Text = "--Select City--", Value = "0" });
            foreach (var x in states)
            {
                liState.Add(new SelectListItem
                {
                    Text = x.cityName,
                    Value = x.cityID.ToString()
                });
            }

            ViewBag.stList = liState;
            // pass the model to the view in the second parameter
            return PartialView("DisplayState");
        }
    }
}