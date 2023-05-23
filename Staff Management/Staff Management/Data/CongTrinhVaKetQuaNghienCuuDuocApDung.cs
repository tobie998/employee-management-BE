namespace StaffManage.Data
{
    public class CongTrinhVaKetQuaNghienCuuDuocApDung
    {
        public string Macongtrinhnghiencuu { get; set; }
        public string Macanbo { get; set; }
        public string Tencongtrinhnghiencuu { get; set; }
        public string Hinhthuc { get; set; }
        public string Quymo { get; set; }
        public string Diachiapdung { get; set; }
        public string Thoigian { get; set; }
        public int isDelete { get; set; } = 0;

        public CanBo CanBo { get; set; }




    }
}
