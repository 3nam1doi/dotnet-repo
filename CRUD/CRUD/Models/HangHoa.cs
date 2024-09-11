namespace CRUD.Models
{
    public class HangHoa
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }

    }

    public class HangHoaVM : HangHoa
    {
        public Guid MaHangHoa { get; set; }
    }
}
