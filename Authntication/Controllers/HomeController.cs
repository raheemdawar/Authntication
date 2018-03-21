using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authntication.Models;
using Authntication.StaticData;
using Microsoft.AspNetCore.Http;

namespace Authntication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string value = HttpContext.Session.GetString("mySession");
            if(value==null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        public IActionResult login()
        {

            return View();
        }
         
        public IActionResult userCredentials(UserLoginModel model)
        {

            if(model.email.ToLower().Equals(StaticDataProvider.getUserEmail().ToLower()))
            {

                if (model.password.Equals(StaticDataProvider.getUserPassword()))
                {
                    HttpContext.Session.SetString("mySession", model.email);
                    return RedirectToAction("index");
                }
            }
            return RedirectToAction("login");
            


            
        }

        public IActionResult About()
        {

            string value = HttpContext.Session.GetString("mySession");
            if (value == null)
            {
                return RedirectToAction("login");
            }
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
           
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
