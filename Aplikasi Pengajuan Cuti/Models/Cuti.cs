using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Cuti
    {

        [Key]
        public int id { get; set; }
        public Pegawai Pegawai { get; set; }
        [ForeignKey("Pegawai")]
        public int id_pegawai { get; set; }

        public string alasan { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Status")]
        public int id_status { get; set; }

    }
}
