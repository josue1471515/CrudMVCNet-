using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudNetMvc.Models;
using crudNetMvc.Models.ViewModels;

namespace crudNetMvc.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Index()
        {
            List<ListPersonViewModel> lst;
            using (crud1Entities1 db = new crud1Entities1()) {
                 lst = (from d in db.Persons
                           select new ListPersonViewModel
                           {
                               PersonID = d.PersonID,
                               LastName = d.LastName,
                               FirstName = d.FirstName,
                               Address = d.Address,
                               City = d.City
                           }).ToList();
                            
            }
                return View(lst);
        }

       

       
    

        public ActionResult UpdatePerson()
        {
            return View();
        }

        public ActionResult CreatePerson() {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonViewModel model) {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crud1Entities1 db = new crud1Entities1())
                    {
                        var oPerson = new Persons();
                        oPerson.LastName = model.LastName;
                        oPerson.FirstName = model.FirstName;
                        oPerson.Address = model.Address;
                        oPerson.City = model.City;
                        db.Persons.Add(oPerson);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Persons/Index");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditPerson( int PersonID)
        {
            PersonViewModel person = new PersonViewModel();
            using (crud1Entities1 db = new crud1Entities1()) {
                var oTable = db.Persons.Find(PersonID);
                person.FirstName = oTable.FirstName;
                person.LastName = oTable.LastName;
                person.Address = oTable.Address;
                person.City = oTable.City;
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult EditPerson(PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crud1Entities1 db = new crud1Entities1())
                    {
                        var oPerson = db.Persons.Find(model.PersonID);
                        oPerson.LastName = model.LastName;
                        oPerson.FirstName = model.FirstName;
                        oPerson.Address = model.Address;
                        oPerson.City = model.City;
                        db.Entry(oPerson).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Persons/Index");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public ActionResult DeletePerson(int PersonID)
        {
            PersonViewModel person = new PersonViewModel();
            using (crud1Entities1 db = new crud1Entities1())
            {
                var oTable = db.Persons.Find(PersonID);
                db.Persons.Remove(oTable);
                db.SaveChanges();
            }
            return Redirect("~/Persons/");
        }

    }
}