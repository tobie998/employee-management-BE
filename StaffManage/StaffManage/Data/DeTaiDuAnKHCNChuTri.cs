namespace StaffManage.Data
{
    public class DeTaiDuAnKHCNChuTri
    {
        public int Madetai { get; set; }
        public string Macanbo { get; set; }
        public string Tendetai { get; set; }
        public string Thoigianbatdau { get; set; }
        public string Thoigianketthuc { get; set; }
        public string Tinhtrang { get; set; }
        public CanBo CanBo { get; set; }
        public DeTaiDuAnKHCN deTaiDuAnKHCN { get; set; }
        public int isDelete { get; set; } = 0;

    }
}
