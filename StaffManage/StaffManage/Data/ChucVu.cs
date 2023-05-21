﻿using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChucVu
    {
        [Key]
        public int Machucvu { get; set; }
        [Required]
        public string Tenchucvu { get; set; }
        public int isDelete { get; set; } = 0;
        
    }
}
