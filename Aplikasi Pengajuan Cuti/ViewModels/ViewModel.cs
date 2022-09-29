using Aplikasi_Pengajuan_Cuti.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Aplikasi_Pengajuan_Cuti.ViewModels
{
    public class ViewModel
    {
        public Pegawai pegawai { get; set; }

        public Cuti cuti { set; get; }
        public IEnumerable<SelectListItem> Division { get; set; }
        public IEnumerable<SelectListItem> Pegawai { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
    }
}
