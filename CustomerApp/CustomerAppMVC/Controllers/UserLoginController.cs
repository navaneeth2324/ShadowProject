using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerAppMVC.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace CustomerAppMVC.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginClass lc)
        {
            string conStr = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conStr);
            string sqlquery = "select UserName,Password from [dbo].[LoginDB] where UserName=@UserName and Password=@Password";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcom.Parameters.AddWithValue("@UserName", lc.username);
            sqlcom.Parameters.AddWithValue("@Password", lc.password);
            SqlDataReader sqdr = sqlcom.ExecuteReader();
            if(sqdr.Read())
            {
                Session["username"] = lc.username.ToString();
                return RedirectToAction("ViewProducts", "Product");
            }
            else
            {
                ViewData["Message"] = "Login Details Failed";
            }
            sqlcon.Close();

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "UserLogin");
        }
    }
}