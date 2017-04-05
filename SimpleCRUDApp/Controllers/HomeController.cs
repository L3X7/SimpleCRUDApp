using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Models.ViewModels;

namespace SimpleCRUDApp.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult OptionOne()
        {
            using (SimpleCRUDEntities db = new SimpleCRUDEntities())
            {
                List<Users> usr = db.Users.ToList();
                return View(usr);
            }

        }
        public PartialViewResult Form()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SimpleCRUDEntities db = new SimpleCRUDEntities())
                    {
                        Users mdl = FormatToUser(model);
                        db.Users.Add(mdl);
                        db.SaveChanges();
                        ViewData["message"] = "Save record";
                        return PartialView("_AlertSuccess");
                    }
                }
                catch (Exception)
                {
                    ViewData["message"] = "Error in save the record";
                    return PartialView("_AlertError");
                }

            }
            return PartialView("Form", model);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (SimpleCRUDEntities db = new SimpleCRUDEntities())
            {
                Users usr = db.Users.Find(id);
                if (usr == null)
                {
                    return Json(1);
                }
                db.Users.Remove(usr);
                db.SaveChanges();
                return Json(2);
            }
        }

        public Users FormatToUser(UsersViewModel model)
        {
            Users mdl = new Users();
            mdl.Name = model.Name;
            mdl.LastName = model.LastName;
            mdl.Email = model.Email;
            mdl.Phone = model.Phone;
            mdl.Address = model.Address;
            return mdl;
        }

        public ActionResult ListUsers()
        {
            using (SimpleCRUDEntities db = new SimpleCRUDEntities())
            {
                List<Users> usr = db.Users.ToList();
                return PartialView("List", usr);
            }
        }

        public ActionResult Detail(int id)
        {
            using (SimpleCRUDEntities db = new SimpleCRUDEntities())
            {
                Users usr = db.Users.Find(id);
                if (usr == null)
                {
                    ViewData["message"] = "The element not exist";
                    return PartialView("_AlertNotification");
                }

                return PartialView("Detail", usr);
            }
        }
        public ActionResult GetUser(int id)
        {
            using (SimpleCRUDEntities db = new SimpleCRUDEntities())
            {
                Users usr = db.Users.Find(id);
                if (usr == null)
                {
                    ViewData["message"] = "The element not exist";
                    return PartialView("_AlertNotification");
                }

                UsersViewModel uVModel = FormatToUserViewModel(usr);
                return PartialView("Update", uVModel);
            }
        }
        [HttpPost]
        public ActionResult Update(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (SimpleCRUDEntities db = new SimpleCRUDEntities())
                {
                    try
                    {
                        Users usr = db.Users.Find(model.IdUser);
                        if (usr == null)
                        {
                            ViewData["message"] = "The record no exist";
                            return PartialView("_AlertNotification");
                        }

                        usr.Name = model.Name;
                        usr.LastName = model.LastName;
                        usr.Address = model.Address;
                        usr.Email = model.Email;
                        db.Entry(usr).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        ViewData["message"] = "Update record";
                        return PartialView("_AlertSuccess");

                    }
                    catch (Exception)
                    {
                        ViewData["message"] = "Error in update the record";
                        return PartialView("_AlertError");
                    }
                }
            }
            return PartialView(model);
        }

        public UsersViewModel FormatToUserViewModel(Users model)
        {
            UsersViewModel mdl = new UsersViewModel();
            mdl.IdUser = model.IdUser;
            mdl.Name = model.Name;
            mdl.LastName = model.LastName;
            mdl.Email = model.Email;
            mdl.Phone = model.Phone;
            mdl.Address = model.Address;
            return mdl;
        }
    }
}