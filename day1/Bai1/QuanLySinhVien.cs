using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai1 
{
    public class SinhVienService
    {
        private List<SinhVien> DanhSachSV;

        public SinhVienService()
        {
            DanhSachSV = new List<SinhVien>();
        }

        public void ThemSV(SinhVien sv)
        {
            if (DanhSachSV.Any(s => s.MaSV == sv.MaSV))
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return;
            }
            DanhSachSV.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        public void HienThiDanhSach()
        {
            if (DanhSachSV == null || DanhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sach sinh vien rong!");
                return;
            }

            foreach (var sv in DanhSachSV)
            {
                sv.HienThiThongTin();
                Console.WriteLine("------------------------");
            }
        }

        public SinhVien TimTheoMa(string maSV)
        {
            var sv = DanhSachSV.FirstOrDefault(s => s.MaSV == maSV);
            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien co ma nay!");
            }
            return sv;
        }

        public List<SinhVien> TimTheoTenGanDung(string ten)
        {
            return DanhSachSV
                .Where(s => s.HoTen.ToLower().Contains(ten.ToLower()))
                .ToList();
        }

        public void CapNhatSV(SinhVien svMoi)
        {
            var svCu = TimTheoMa(svMoi.MaSV);
            if (svCu != null)
            {
                svCu.HoTen = svMoi.HoTen;
                svCu.NgaySinh = svMoi.NgaySinh;
                svCu.GioiTinh = svMoi.GioiTinh;
                svCu.Email = svMoi.Email;
                svCu.SDT = svMoi.SDT;
                svCu.NganhHoc = svMoi.NganhHoc;
                svCu.DiemTB = svMoi.DiemTB;
                svCu.TrangThaiHT = svMoi.TrangThaiHT;
                Console.WriteLine("Cap nhat thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien de cap nhat!");
            }
        }

        public void XoaSV(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv != null)
            {
                DanhSachSV.Remove(sv);
                Console.WriteLine("Xoa thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien de xoa!");
            }
        }

        public void SapXepTheoHoTen()
        {
            DanhSachSV = DanhSachSV.OrderBy(s => s.HoTen).ToList();
        }

        public void SapXepTheoDiemTB()
        {
            DanhSachSV = DanhSachSV.OrderByDescending(s => s.DiemTB).ToList();
        }

        public void HienThiSVGioi()
        {
            var ds = DanhSachSV.Where(s => s.DiemTB >= 8).ToList();
            foreach (var sv in ds) sv.HienThiThongTin();
        }

        public void HienThiSVDiemCaoNhat()
        {
            var maxDiem = DanhSachSV.Max(s => s.DiemTB);
            var ds = DanhSachSV.Where(s => s.DiemTB == maxDiem).ToList();
            foreach (var sv in ds) sv.HienThiThongTin();
        }

        public float TinhDiemTBToanBo()
        {
            if (DanhSachSV.Count == 0) return 0;
            return DanhSachSV.Average(s => s.DiemTB);
        }

        public void ThongKeTheoNganh()
        {
            var thongKe = DanhSachSV.GroupBy(s => s.NganhHoc);
            foreach (var nhom in thongKe)
            {
                Console.WriteLine($"Nganh {nhom.Key}: {nhom.Count()} sinh vien");
            }
        }

        public void ThongKeTheoTrangThai()
        {
            var thongKe = DanhSachSV.GroupBy(s => s.TrangThaiHT);
            foreach (var nhom in thongKe)
            {
                Console.WriteLine($"Trang thai {nhom.Key}: {nhom.Count()} sinh vien");
            }
        }
    }
}
