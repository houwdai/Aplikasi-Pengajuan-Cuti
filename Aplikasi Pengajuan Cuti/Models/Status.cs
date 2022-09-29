using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Status
    {

        [Key]
        public int id { get; set; }
        public string status_cuti { get; set; }


    }
}
