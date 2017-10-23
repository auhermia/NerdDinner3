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
        DinnerRepository dinnerRepository = new DinnerRepository();

        // HTTP-GET: /Dinners/
                public ActionResult Index()
        {
            var dinners = dinnerRepository.FindUpcomingDinners().ToList();

            return View(dinners);
        }

        // HTTP-GET: /Dinners/Details/#

        public ActionResult Details(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
                return View("NotFound");
            else
                return View(dinner);
        }



        // GET: /Dinners/Edit/# --------------------

        
        // Retrieving Form Post Values

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            // Retrieve existing dinner
            Dinner dinner = dinnerRepository.GetDinner(id);

            try
            {
                UpdateModel(dinner);

                // Persist changes back to db
                dinnerRepository.Save();

                // Perform HTTP redirect to details page for the saved Dinner
                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            
            catch
            {
                ModelState.AddRuleViolations(dinner.GetRuleValidations());
                return View(dinner);
            }

        }
        // keep or nah? - where does this go?
        public static class ControllerHelpers
        {

            public static void AddRuleViolations(this ModelStateDictionary modelState, IEnumerable<RuleViolation> errors)
            {

                foreach (RuleViolation issue in errors)
                {
                    modelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
            {
                EventDate = DateTime.Now.AddDays(7)
            };

            return View(dinner);
        }


    }
}