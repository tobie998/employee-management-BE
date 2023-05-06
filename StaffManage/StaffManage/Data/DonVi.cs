using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class DonVi
    {
        [Key]
        public int Madonvi { get; set; }
        [Required]
        public string Tendonvi { get; set; }
        public string Diachi { get; set; }
        [MaxLength(13)]
        public string Fax { get; set; }
        public string Nguoidungdau { get; set;}
        [MaxLength(13)]
        public string Dienthoai { get; set; }
        public string Website { get; set; }
    }
}
