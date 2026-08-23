using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string NganhHoc { get; set; }
        public float DiemTB { get; set; }
        public string TrangThaiHT { get; set; }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh,
                        string email, string sDT, string nganhHoc, float diemTB, string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            SDT = sDT;
            NganhHoc = nganhHoc;
            DiemTB = diemTB;
            TrangThaiHT = trangThai;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"Ma SV: {MaSV}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Ngay sinh: {NgaySinh.ToShortDateString()}");
            Console.WriteLine($"Gioi tinh: {GioiTinh}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"SDT: {SDT}");
            Console.WriteLine($"Nganh hoc: {NganhHoc}");
            Console.WriteLine($"Diem TB: {DiemTB}");
            Console.WriteLine($"Trang thai: {TrangThaiHT}");
        }
    }
}
