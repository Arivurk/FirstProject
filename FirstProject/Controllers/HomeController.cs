using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        protected UserDetails database=new UserDetails();
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        public ActionResult About()
        {
            try
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        public ActionResult Contact()
        {
            try
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Login(Login userlogin)
        {
            try
            {
                if (ModelState != null)
                {
                    bool username = database.UserLoginDetails().Any(model => model.Username == userlogin.Username);
                    bool user = database.UserLoginDetails().Any(model => model.Username == userlogin.Username && model.Password == userlogin.Password);
                    if (user)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("","Please enter valid password");
                    }
                }
                return View(userlogin);
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        public JsonResult CheckUsername(string username)
        {

            System.Threading.Thread.Sleep(200);
            var userdat=database.UserLoginDetails().Where(model=>model.Username == username).ToString();
            if (userdat!=null){
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        public ActionResult Register()
        {
            try
            {
                return View();
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        protected SqlConnection sqlConnect;

        protected void Connection()
        {
            string Connection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString.ToString();
            sqlConnect = new SqlConnection(Connection);
        }
        public ActionResult ShowTablesData() 
        {
            try
            {
                DataTable dt = new DataTable();
                Connection();
                sqlConnect.Open();
                string query = "select * from userAccountDatas";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter reader = new SqlDataAdapter(cmd);
                reader.Fill(dt);
                return View(dt);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}