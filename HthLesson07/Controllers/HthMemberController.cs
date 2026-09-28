using HthLesson07.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HthLesson07.Controllers
{
    public class HthMemberController : Controller
    {
        private static List<HthMember> members = new List<HthMember>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HthMember member)
        {
            bool validate = true;
            string msg = "";
            if (member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }
            string patternphone = @"^0\d{9,12}$";
            if (!Regex.IsMatch(member.Phone, patternphone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }
            if (validate)
            {
                member.MemberId = Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
                return View(member);
            }
        }
    }
}
