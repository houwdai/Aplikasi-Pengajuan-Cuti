using Aplikasi_Pengajuan_Cuti.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aplikasi_Pengajuan_Cuti.Controllers
{
    public class AtasanController : Controller
    {
        myContext myContext;

        public AtasanController(myContext myContext)
        {
            this.myContext = myContext;
        }
        // GET: AtasanController
        public ActionResult Index()
        {
            var data = myContext.cuti.ToList();
            return View(data);
        }

        public ActionResult Tolak(int id)
        {

            return View();
        }        
        public ActionResult Terima(int id)
        {

            return View();
        }


        // GET: AtasanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AtasanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtasanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtasanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtasanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtasanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtasanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
