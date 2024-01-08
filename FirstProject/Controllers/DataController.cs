using FirstProject.Models;
using FirstProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.Controllers
{
    public class DataController : Controller
    {
        UserRepository database=new UserRepository();
        // GET: Data
        public ActionResult tablesdata()
        {

            return View();
        }
        public ActionResult listsdata() 
        {
            List<UserModel> datass=new List<UserModel> ();
            datass=database.GetSelecteddetail().ToList<UserModel>();
            return Json(new {data=datass},JsonRequestBehavior.AllowGet);
        }
        public ActionResult logoutss()
        {
            return View();
        }
    }
}