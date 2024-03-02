using System;

namespace My_WebAPI.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }

        public double DonGia { get; set; }
    }

    public class HangHoa : HangHoaVM
    {
        // Guid 
        public Guid MaHangHoa { get; set; }
    }
}
