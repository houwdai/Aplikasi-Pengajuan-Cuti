using Aplikasi_Pengajuan_Cuti.Context;
using Aplikasi_Pengajuan_Cuti.Models;
using Aplikasi_Pengajuan_Cuti.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aplikasi_Pengajuan_Cuti.Controllers
{
    public class CutisController : Controller
    {
        myContext myContext;
        public CutisController(myContext myContext)
        {
            this.myContext = myContext;
        }
        // GET: CutisController
        public ActionResult Index()
        {
            var data = myContext.cuti.Include(x => x.Pegawai).Include(y=> y.Status).ToList();
            return View(data);
        }

        // GET: CutisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CutisController/Create
        public ActionResult Create()
        {
            ViewModel vm = new ViewModel();
            List<SelectListItem> pegawai = myContext.pegawai
                .OrderBy(n => n.nama_pegawai)
                .Select(n => new SelectListItem
                {
                    Value = n.id.ToString(),
                    Text = n.nama_pegawai.ToString()
                }).ToList();          
            //List<SelectListItem> status = myContext.status
            //    .OrderBy(n => n.status_cuti)
            //    .Select(n => new SelectListItem
            //    {
            //        Value = n.id.ToString(),
            //        Text = n.status_cuti.ToString()
            //    }).ToList();
            //vm.Status = status;
            vm.Pegawai = pegawai;
            return View(vm);
        }

        // POST: CutisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        //// POST : /Create/Pegawai
        public IActionResult Create(Cuti cuti)
        {

            if (ModelState.IsValid)
            {
                myContext.cuti.Add(cuti);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CutisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CutisController/Edit/5
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

        // GET: CutisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CutisController/Delete/5
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
