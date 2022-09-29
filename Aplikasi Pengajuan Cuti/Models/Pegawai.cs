using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Pegawai
    {

        [Key]
        public int id { get; set; }
        public string nama_pegawai { get; set; }

        public Division Division { get; set; }

        [ForeignKey("Division")]
        public int id_division { get; set; }

        

    }
}
