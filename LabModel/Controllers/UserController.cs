using Microsoft.AspNetCore.Mvc;
using LabModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabModel.Controllers
{
    public class UserController : Controller
    {
        // Dữ liệu giả lập (Mock Data)
        private static List<User> users = new List<User>
        {
            new User { Id = 1, name = "Mark Smith", address = "Park Street", email = "Mark@mvcexample.com" },
            new User { Id = 2, name = "John Parker", address = "New Park", email = "John@mvcexample.com" },
            new User { Id = 3, name = "Steave Edward", address = "Melbourne Street", email = "steave@mvcexample.com" }
        };

        // 1. Template LIST: Hiển thị danh sách
        public ActionResult Index()
        {
            return View(users);
        }

        // 2. Template CREATE: Thêm người dùng mới
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);
            return RedirectToAction("Index");
        }

        // 3. Template EDIT: Chỉnh sửa thông tin
        public ActionResult Edit(long id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.address = user.address;
                existingUser.email = user.email;
            }
            return RedirectToAction("Index");
        }

        // 4. Template DETAILS: Xem chi tiết
        public ActionResult Details(long id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // 5. Template DELETE: Xóa dữ liệu
        public ActionResult Delete(long id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction("Index");
        }
    }
}