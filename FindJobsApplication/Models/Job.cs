using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Salary { get; set; }

        public decimal? Amount { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public JobType JobType { get; set; }

        public string? WorkingHours { get; set; }

        public string? Requirements { get; set; }

        public string? Benefits { get; set; }

        public SalaryUnit SalaryUnit { get; set; } = SalaryUnit.PerMonth;

        public int EmployerId { get; set; }

        public int JobCategoryId { get; set; }

        public JobLocation? Location { get; set; }

        public bool? IsClosed { get; set; } = false;

        [ForeignKey("JobCategoryId")]
        public JobCategory JobCategory { get; set; }

        [ForeignKey("EmployerId")]
        public Employer Employer { get; set; }
    }

    public enum SalaryUnit
    {
        PerHour,
        PerDay,
        PerMonth,
        PerYear,
        PerProject
    }

    public enum JobType
    {
        FullTime,
        PartTime,
        Contract,
        Internship
    }

    public enum JobLocation
    {
        HaNoi,
        HoChiMinh,
        DaNang,
        HaiPhong,
        CanTho,
        Hue,
        QuangNinh,
        KhanhHoa,
        DongNai,
        BinhDuong,
        BacGiang,
        BacKan,
        BacLieu,
        BacNinh,
        BenTre,
        BinhDinh,
        BinhPhuoc,
        CaMau,
        CaoBang,
        DakLak,
        DakNong,
        DienBien,
        DongThap,
        GiaLai,
        HaGiang,
        HaNam,
        HaTinh,
        HaiDuong,
        HauGiang,
        HoaBinh,
        HungYen,
        KonTum,
        LaiChau,
        LamDong,
        LangSon,
        LaoCai,
        LongAn,
        NamDinh,
        NgheAn,
        NinhBinh,
        NinhThuan,
        PhuTho,
        PhuYen,
        QuangBinh,
        QuangNam,
        QuangNgai,
        QuangTri,
        SocTrang,
        SonLa,
        TayNinh,
        ThaiBinh,
        ThaiNguyen,
        ThanhHoa,
        ThuaThienHue,
        TienGiang,
        TraVinh,
        TuyenQuang,
        VinhLong,
        VinhPhuc,
        YenBai,

        Quan1_HoChiMinh,
        Quan3_HoChiMinh,
        QuanBinhThanh_HoChiMinh,
        QuanGoVap_HoChiMinh,
        Quan7_HoChiMinh,
        QuanThuDuc_HoChiMinh,

        PhuongDongDa_HaNoi,
        PhuongBaDinh_HaNoi,
        PhuongHoanKiem_HaNoi,
        QuanCauGiay_HaNoi,
        QuanThanhXuan_HaNoi,
        QuanHaDong_HaNoi,

        QuanHaiChau_DaNang,
        QuanThanhKhe_DaNang,
        QuanSonTra_DaNang,
        QuanNguHanhSon_DaNang
    }

    public static class JobLocationDictionary
    {
        public static readonly Dictionary<JobLocation, string> Locations = new Dictionary<JobLocation, string>()
        {
            { JobLocation.HaNoi, "Thành phố Hà Nội" },
            { JobLocation.HoChiMinh, "Thành phố Hồ Chí Minh" },
            { JobLocation.DaNang, "Thành phố Đà Nẵng" },
            { JobLocation.HaiPhong, "Thành phố Hải Phòng" },
            { JobLocation.CanTho, "Thành phố Cần Thơ" },
            { JobLocation.Hue, "Thừa Thiên Huế" },
            { JobLocation.QuangNinh, "Tỉnh Quảng Ninh" },
            { JobLocation.KhanhHoa, "Tỉnh Khánh Hòa" },
            { JobLocation.DongNai, "Tỉnh Đồng Nai" },
            { JobLocation.BinhDuong, "Tỉnh Bình Dương" },
            { JobLocation.BacGiang, "Tỉnh Bắc Giang" },
            { JobLocation.BacKan, "Tỉnh Bắc Kạn" },
            { JobLocation.BacLieu, "Tỉnh Bạc Liêu" },
            { JobLocation.BacNinh, "Tỉnh Bắc Ninh" },
            { JobLocation.BenTre, "Tỉnh Bến Tre" },
            { JobLocation.BinhDinh, "Tỉnh Bình Định" },
            { JobLocation.BinhPhuoc, "Tỉnh Bình Phước" },
            { JobLocation.CaMau, "Tỉnh Cà Mau" },
            { JobLocation.CaoBang, "Tỉnh Cao Bằng" },
            { JobLocation.DakLak, "Tỉnh Đắk Lắk" },
            { JobLocation.DakNong, "Tỉnh Đắk Nông" },
            { JobLocation.DienBien, "Tỉnh Điện Biên" },
            { JobLocation.DongThap, "Tỉnh Đồng Tháp" },
            { JobLocation.GiaLai, "Tỉnh Gia Lai" },
            { JobLocation.HaGiang, "Tỉnh Hà Giang" },
            { JobLocation.HaNam, "Tỉnh Hà Nam" },
            { JobLocation.HaTinh, "Tỉnh Hà Tĩnh" },
            { JobLocation.HaiDuong, "Tỉnh Hải Dương" },
            { JobLocation.HauGiang, "Tỉnh Hậu Giang" },
            { JobLocation.HoaBinh, "Tỉnh Hòa Bình" },
            { JobLocation.HungYen, "Tỉnh Hưng Yên" },
            { JobLocation.KonTum, "Tỉnh Kon Tum" },
            { JobLocation.LaiChau, "Tỉnh Lai Châu" },
            { JobLocation.LamDong, "Tỉnh Lâm Đồng" },
            { JobLocation.LangSon, "Tỉnh Lạng Sơn" },
            { JobLocation.LaoCai, "Tỉnh Lào Cai" },
            { JobLocation.LongAn, "Tỉnh Long An" },
            { JobLocation.NamDinh, "Tỉnh Nam Định" },
            { JobLocation.NgheAn, "Tỉnh Nghệ An" },
            { JobLocation.NinhBinh, "Tỉnh Ninh Bình" },
            { JobLocation.NinhThuan, "Tỉnh Ninh Thuận" },
            { JobLocation.PhuTho, "Tỉnh Phú Thọ" },
            { JobLocation.PhuYen, "Tỉnh Phú Yên" },
            { JobLocation.QuangBinh, "Tỉnh Quảng Bình" },
            { JobLocation.QuangNam, "Tỉnh Quảng Nam" },
            { JobLocation.QuangNgai, "Tỉnh Quảng Ngãi" },
            { JobLocation.QuangTri, "Tỉnh Quảng Trị" },
            { JobLocation.SocTrang, "Tỉnh Sóc Trăng" },
            { JobLocation.SonLa, "Tỉnh Sơn La" },
            { JobLocation.TayNinh, "Tỉnh Tây Ninh" },
            { JobLocation.ThaiBinh, "Tỉnh Thái Bình" },
            { JobLocation.ThaiNguyen, "Tỉnh Thái Nguyên" },
            { JobLocation.ThanhHoa, "Tỉnh Thanh Hóa" },
            { JobLocation.ThuaThienHue, "Tỉnh Thừa Thiên Huế" },
            { JobLocation.TienGiang, "Tỉnh Tiền Giang" },
            { JobLocation.TraVinh, "Tỉnh Trà Vinh" },
            { JobLocation.TuyenQuang, "Tỉnh Tuyên Quang" },
            { JobLocation.VinhLong, "Tỉnh Vĩnh Long" },
            { JobLocation.VinhPhuc, "Tỉnh Vĩnh Phúc" },
            { JobLocation.YenBai, "Tỉnh Yên Bái" },

            { JobLocation.Quan1_HoChiMinh, "Quận 1, Thành phố Hồ Chí Minh" },
            { JobLocation.Quan3_HoChiMinh, "Quận 3, Thành phố Hồ Chí Minh" },
            { JobLocation.QuanBinhThanh_HoChiMinh, "Quận Bình Thạnh, Thành phố Hồ Chí Minh" },
            { JobLocation.QuanGoVap_HoChiMinh, "Quận Gò Vấp, Thành phố Hồ Chí Minh" },
            { JobLocation.Quan7_HoChiMinh, "Quận 7, Thành phố Hồ Chí Minh" },
            { JobLocation.QuanThuDuc_HoChiMinh, "Quận Thủ Đức, Thành phố Hồ Chí Minh" },

            { JobLocation.PhuongDongDa_HaNoi, "Phường Đống Đa, Hà Nội" },
            { JobLocation.PhuongBaDinh_HaNoi, "Phường Ba Đình, Hà Nội" },
            { JobLocation.PhuongHoanKiem_HaNoi, "Phường Hoàn Kiếm, Hà Nội" },
            { JobLocation.QuanCauGiay_HaNoi, "Quận Cầu Giấy, Hà Nội" },
            { JobLocation.QuanThanhXuan_HaNoi, "Quận Thanh Xuân, Hà Nội" },
            { JobLocation.QuanHaDong_HaNoi, "Quận Hà Đông, Hà Nội" },

            { JobLocation.QuanHaiChau_DaNang, "Quận Hải Châu, Thành phố Đà Nẵng" },
            { JobLocation.QuanThanhKhe_DaNang, "Quận Thanh Khê, Thành phố Đà Nẵng" },
            { JobLocation.QuanSonTra_DaNang, "Quận Sơn Trà, Thành phố Đà Nẵng" },
            { JobLocation.QuanNguHanhSon_DaNang, "Quận Ngũ Hành Sơn, Thành phố Đà Nẵng" },
        };
    }
}
