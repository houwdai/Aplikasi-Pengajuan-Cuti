using Aplikasi_Pengajuan_Cuti.Context;
using Aplikasi_Pengajuan_Cuti.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.Linq;
using Aplikasi_Pengajuan_Cuti.ViewModels;

namespace Aplikasi_Pengajuan_Cuti.Controllers
{
    [Authorize (Role = "Adminhr")]
    public class HrController : Controller
    {
        myContext myContext;
        public HrController(myContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            var data = myContext.pegawai.Include(x=>x.Division).ToList();
            return View(data);
        }

        [HttpGet("Details/{id:int}")]
        public IActionResult Details (int id)
        {
            var data = myContext.pegawai.Where(x => x.id == id).Include(x => x.Division).FirstOrDefault();
            return View(data);
        }

        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            ViewModel vm = new ViewModel();
            List<SelectListItem> division = myContext.division
                .OrderBy(n => n.nama_division)
                .Select(n => new SelectListItem
                {
                    Value = n.id.ToString(),
                    Text = n.nama_division.ToString()
                }).ToList();
            vm.Division = division;
            //var divisi = myContext.division.ToList();
            var reader = myContext.pegawai.Where(x => x.id == id).Include(x => x.Division).FirstOrDefault();
            ViewData["idPegawai"] = reader.id;
            ViewData["namaPegawai"] = reader.nama_pegawai;
            //ViewData["divisi"] = reader.id_division;
            ViewData["divisi"] = reader.Division.nama_division;

            return View(vm);
        }

        // POST: Student/Edit/5
        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(Pegawai pegawai)
        {
            
            if (ModelState.IsValid)
            {
                myContext.pegawai.Update(pegawai);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pegawai);
        
        }

        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var pegawai = myContext.pegawai.Where(a => a.id == id).FirstOrDefault();
            myContext.pegawai.Remove(pegawai);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            ViewModel vm = new ViewModel();
            List<SelectListItem> division = myContext.division
                .OrderBy(n => n.nama_division)
                .Select(n => new SelectListItem
                {
                    Value = n.id.ToString(),
                    Text = n.nama_division.ToString()
                }).ToList();
            vm.Division = division;
            return View(vm);
        }
        [HttpPost]
        //// POST : /Create/Pegawai
        public IActionResult Create(Pegawai pegawai)
        {

            if (ModelState.IsValid)
            {
                myContext.pegawai.Add(pegawai);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
    }
}
