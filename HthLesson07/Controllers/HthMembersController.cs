using HthLesson07.Models.DataModels;
using HthLesson07.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace HthLesson07.Controllers
{
    public class HthMembersController : Controller
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
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                HthMember m = new HthMember
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday,
                };

                members.Add(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}
