using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using FirstProject.Models;
using FirstProject.Repository;
using Newtonsoft.Json;

namespace FirstProject.Controllers
{
    public class UserController : Controller
    {
        protected UserRepository database;
        public UserController()
        {
            database = new UserRepository();
        }
        // GET: User
        /// <summary>
        /// Welcome Page for select dropdown
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ActionResult UserWelcome()
        {
            try
            {
                
                ViewBag.data = new SelectList( database.getTableNames(),"data","data");
                ViewBag.branch = new SelectList(database.GetBranchDatas(), "Branch_id", "Branchname"); 
                var data = database.GetBranchDatas().ToList();
                TempData["user"] = "name";
                return View();
                
            }
          
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult UserWelcome(UserModel userDetails)
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public ActionResult Listdatas()
        {
           var datas = database.GetSelecteddetail().ToList();
            return View(datas);
        }
        [HttpGet]
        public ActionResult Listdetails(int id)
        {
            try
            {
                var datas = database.GetSelecteddetails(id).ToList();
                return PartialView("Listdetails", datas);
            }catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
     
        public ActionResult selectGender()
        {
            try
            {
                return PartialView();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult SelectBasedGender(string id, string name)
        {
            try
            {
                var details = database.SelectGender(id, name).ToList();
                return View(details);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult GetdetailsFromBranch()
        {
            try
            {              
                List<UserModel> list = database.GetSelecteddetail().ToList<UserModel>();
                return Json(new { Data = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult GetTablesColumns(string id,string name)
        {
            try
            {
                DataTable dt = new DataTable();
                var data = database.getColumns(id,name);
                data.Fill(dt);
                return View(dt);
            }
           
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    
        [HttpGet]
        public ActionResult DataTablesValues(string id)
        {
            try
            {
                var data = database.getColumnsNames(id);
                DataTable dt = new DataTable();
                data.Fill(dt);
                ViewData["user"] = id;
                Session["user"] = id;
                return PartialView(dt);
            }     
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
       
        public ActionResult SelectDropdownColumn(string id,string name)
        {
            var customers = database.GetColumnDetails(id, name).Select(m => new
            {
                Value = m.data,
                Text = m.data
            }).Distinct().ToList();
            //var customers = database.GetColumnDetails(id,name).Distinct().ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomers()
        {
            var customers = database.GetSelecteddetailscolumn().Distinct().ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}

