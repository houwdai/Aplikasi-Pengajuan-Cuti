using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Pengajuan_Cuti.Models
{
    public class Userr
    {

        [Key]
        public string username { get; set; }
        public string password { get; set; }

        public Role Role { get; set; }
        [ForeignKey ("Role")]
        public int id_role { get; set; }

    }
}
