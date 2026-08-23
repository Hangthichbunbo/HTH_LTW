using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinhVienService service = new SinhVienService();
            int luaChon;

            do
            {
                Console.WriteLine("MENU QUAN LY SINH VIEN");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim gan dung theo ho ten");
                Console.WriteLine("5. Cap nhat sinh vien");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo ho ten");
                Console.WriteLine("8. Sap xep theo diem trung binh");
                Console.WriteLine("9. Hien thi sinh vien co diem >= 8");
                Console.WriteLine("10. Hien thi sinh vien diem cao nhat");
                Console.WriteLine("11. Tinh diem trung binh toan bo");
                Console.WriteLine("12. Thong ke theo nganh");
                Console.WriteLine("13. Thong ke theo trang thai");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                switch (luaChon)
                {
                    case 1:
                        Console.Write("Nhap ma SV: ");
                        string ma = Console.ReadLine();
                        Console.Write("Nhap ho ten: ");
                        string ten = Console.ReadLine();
                        Console.Write("Nhap ngay sinh (yyyy-MM-dd): ");
                        DateTime ns = DateTime.Parse(Console.ReadLine());
                        Console.Write("Nhap gioi tinh: ");
                        string gt = Console.ReadLine();
                        Console.Write("Nhap email: ");
                        string email = Console.ReadLine();
                        Console.Write("Nhap so dien thoai: ");
                        string sdt = Console.ReadLine();
                        Console.Write("Nhap nganh hoc: ");
                        string nganh = Console.ReadLine();
                        Console.Write("Nhap diem TB: ");
                        float diem = float.Parse(Console.ReadLine());
                        Console.Write("Nhap trang thai hoc tap: ");
                        string tt = Console.ReadLine();

                        SinhVien sv = new SinhVien(ma, ten, ns, gt, email, sdt, nganh, diem, tt);
                        service.ThemSV(sv);
                        break;

                    case 2:
                        service.HienThiDanhSach();
                        break;

                    case 3:
                        Console.Write("Nhap ma SV can tim: ");
                        string maTim = Console.ReadLine();
                        var svTim = service.TimTheoMa(maTim);
                        if (svTim != null) svTim.HienThiThongTin();
                        break;

                    case 4:
                        Console.Write("Nhap ten gan dung: ");
                        string tenTim = Console.ReadLine();
                        var dsTen = service.TimTheoTenGanDung(tenTim);
                        foreach (var s in dsTen) s.HienThiThongTin();
                        break;

                    case 5:
                        Console.Write("Nhap ma SV can cap nhat: ");
                        string maCapNhat = Console.ReadLine();
                        var svCu = service.TimTheoMa(maCapNhat);
                        if (svCu != null)
                        {
                            Console.Write("Nhap ho ten moi: ");
                            svCu.HoTen = Console.ReadLine();
                            Console.Write("Nhap diem TB moi: ");
                            svCu.DiemTB = float.Parse(Console.ReadLine());
                            service.CapNhatSV(svCu);
                        }
                        break;

                    case 6:
                        Console.Write("Nhap ma SV can xoa: ");
                        string maXoa = Console.ReadLine();
                        service.XoaSV(maXoa);
                        break;

                    case 7:
                        service.SapXepTheoHoTen();
                        Console.WriteLine("Da sap xep theo ho ten!");
                        break;

                    case 8:
                        service.SapXepTheoDiemTB();
                        Console.WriteLine("Da sap xep theo diem TB!");
                        break;

                    case 9:
                        service.HienThiSVGioi();
                        break;

                    case 10:
                        service.HienThiSVDiemCaoNhat();
                        break;

                    case 11:
                        Console.WriteLine($"Diem TB toan bo: {service.TinhDiemTBToanBo()}");
                        break;

                    case 12:
                        service.ThongKeTheoNganh();
                        break;

                    case 13:
                        service.ThongKeTheoTrangThai();
                        break;

                    case 0:
                        Console.WriteLine("Thoat chuong trinh...");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine();
            } while (luaChon != 0);
        }
    }
}
