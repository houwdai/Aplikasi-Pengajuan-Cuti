using Aplikasi_Pengajuan_Cuti.Context;
using Aplikasi_Pengajuan_Cuti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikasi_Pengajuan_Cuti.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        myContext myContext;

        public HomeController(myContext myContext)
        {
            this.myContext = myContext;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var login = myContext.users.Find(username);
            if (login == null)
            {
                return Redirect("Index");
            }
            else
            {
                int id_role_1 = 1;
                int id_role_2 = 2;
            if (login.id_role == id_role_1  )
            {
                if (login.password == password)
                return RedirectToAction("Index", "Hr");
            }
            if (login.id_role == id_role_2 & login.password == password)
            {
                return RedirectToAction("Index", "Atasan");

            }
            else
            {
                return RedirectToAction("Index");
            }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
