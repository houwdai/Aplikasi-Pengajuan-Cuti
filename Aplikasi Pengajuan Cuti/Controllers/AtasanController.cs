using Aplikasi_Pengajuan_Cuti.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplikasi_Pengajuan_Cuti.Controllers
{
    [Authorize (Role = "Atasan")]
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
            int status_awaiting = 1;
            var data = myContext.cuti.Where(x=> x.id_status == status_awaiting).Include(x => x.Pegawai).Include(y => y.Status).
                Include(z => z.Pegawai.Division).ToList();
            return View(data);
        }

        [HttpGet("Terima/{id:int}")]

        public ActionResult Terima(int id)
        {

            var cuti = myContext.cuti.Where(a => a.id == id).FirstOrDefault();
            cuti.id_status = 2;
            myContext.cuti.Update(cuti);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Tolak/{id:int}")]
        public ActionResult Tolak(int id)
        {

            var cuti = myContext.cuti.Where(a => a.id == id).FirstOrDefault();
            cuti.id_status = 3;
            myContext.cuti.Update(cuti);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: AtasanController/Details/5
        public ActionResult Riwayat(int id)
        {
            int status_awaiting = 1;
            var data = myContext.cuti.Where(x => x.id_status != status_awaiting).Include(x => x.Pegawai).Include(y => y.Status).
               Include(z => z.Pegawai.Division).ToList();
            return View(data);
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
