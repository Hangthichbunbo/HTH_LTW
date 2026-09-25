using Microsoft.AspNetCore.Mvc;
using Hthlesson06Models.Models;

namespace Hthlesson06Models.Controllers
{
    public class HthMemberController : Controller
    {
        private static readonly List<HthMember> _hthMembers = new List<HthMember>()
        {
            new HthMember
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "hoanghang",
                HthMemberPassword = "password123",
                HthMemberEmail = "hoanghang@gmail.com",
                HthMemberFullName = "Hoàng Thu Hằng"
            },
            new HthMember
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "nguyenvana",
                HthMemberPassword = "securepass456",
                HthMemberEmail = "nva@gmail.com",
                HthMemberFullName = "Nguyễn Văn An"
            },
            new HthMember
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "tranvanb",
                HthMemberPassword = "mypassword789",
                HthMemberEmail = "tvb@gmail.com",
                HthMemberFullName = "Trần Văn Bình"
            },
            new HthMember
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "lethic",
                HthMemberPassword = "passlethic123",
                HthMemberEmail = "lethic@gmail.com",
                HthMemberFullName = "Lê Thị Cúc"
            },
            new HthMember
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "phamvand",
                HthMemberPassword = "phamvandpass",
                HthMemberEmail = "phamvand@gmail.com",
                HthMemberFullName = "Phạm Văn Dũng"
            }
        };

        public IActionResult HthIndex()
        {
            return View(_hthMembers);
        }

        public IActionResult HthCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HthCreate(HthMember hthMember)
        {
            hthMember.HthMemberId = Guid.NewGuid().ToString();
            _hthMembers.Add(hthMember);
            return RedirectToAction("HthIndex");
        }

        
        // 1. HTTP GET: Hiển thị form Edit dựa theo id được truyền vào
        public IActionResult HthEdit(string id)
        {
            var hthMember = _hthMembers.FirstOrDefault(m => m.HthMemberId == id);
            if (hthMember == null)
            {
                return NotFound();
            }
            return View(hthMember);
        }

        // 2. HTTP POST: Nhận dữ liệu cập nhật từ Form và lưu lại vào danh sách
        [HttpPost]
        public IActionResult HthEdit(HthMember hthMember)
        {
            var existingMember = _hthMembers.FirstOrDefault(m => m.HthMemberId == hthMember.HthMemberId);
            if (existingMember != null)
            {
                existingMember.HthMemberUserName = hthMember.HthMemberUserName;
                existingMember.HthMemberPassword = hthMember.HthMemberPassword;
                existingMember.HthMemberEmail = hthMember.HthMemberEmail;
                existingMember.HthMemberFullName = hthMember.HthMemberFullName;
            }
            return RedirectToAction("HthIndex");
        }

        public IActionResult HthGetDetails()
        {
            var hthMember = new HthMember()
            {
                HthMemberId = Guid.NewGuid().ToString(),
                HthMemberUserName = "HoangHang",
                HthMemberPassword = "password123",
                HthMemberEmail = "hoang.hang@example.com",
                HthMemberFullName = "Hoang Thu Hang"
            };
            return View(hthMember);
        }
    }
}