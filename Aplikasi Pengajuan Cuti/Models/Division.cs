using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Division
    {

        [Key]
        public int id { get; set; }
        public string nama_division { get; set; }



    }
}
