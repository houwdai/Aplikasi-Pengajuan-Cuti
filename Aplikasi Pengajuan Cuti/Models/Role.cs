using System.ComponentModel.DataAnnotations;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name_role { get; set; }
    }
}
