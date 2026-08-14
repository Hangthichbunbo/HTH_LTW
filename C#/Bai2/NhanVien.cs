using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    #region lop nhan vien
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string PhongBan { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public double LuongCB { get; set; }

        public NhanVien(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, double luongCB)
        {
            MaNV = maNV;
            HoTen = hoTen;
            PhongBan = phongBan;
            NgayVaoLam = ngayVaoLam;
            LuongCB = luongCB;
        }
        public void HienThiThongTin()
        {
            Console.WriteLine($"Ma nhan vien: {MaNV}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Phong ban: {PhongBan}");
            Console.WriteLine($"Ngay vao lam: {NgayVaoLam}");
            Console.WriteLine($"Luong co ban: {LuongCB}");
        }
    }
    #endregion

    #region lop nhan vien chinh thuc
    public class NVChinhThuc : NhanVien
    {
        private long phuCap = 1000000;
        public NVChinhThuc(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, long luongCB)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCB)
        {
        }

        public long TinhLuong(long luongCB)
        {
            return luongCB + phuCap;
        }
    }
    #endregion

    #region lop nhan vien thu viec
    public class NVThuViec : NhanVien
    {
        public NVThuViec(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, long luongCB)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCB)
        {
        }
        public long TinhLuong(long luongCB)
        {
            return (long)(luongCB * 0.85);
        }
    }

    public class NVThoiVu : NhanVien
    {
        private long soGioLam;
        private long donGiaGio;
        public NVThoiVu(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, long luongCB)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCB)
        {
        }
        public long TinhLuong(long luongCB)
        {
            return soGioLam * donGiaGio;
        }
    }
}
