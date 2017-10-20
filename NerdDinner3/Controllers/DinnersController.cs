using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner3.Models;

// empty controller

namespace NerdDinner3.Controllers
{
    public class DinnersController : Controller
    {
        // HTTP-GET: /Dinners/
        public void Index()
        {
            var dinners = DinnerRepository.FindUpcomingDinners().ToList();
        }

        // HTTP-GET: /Dinners/Details/2

        public void Details(int id)
        {
            Dinner dinner = DinnerRepository.GetDinner(id);
        }
    }
}