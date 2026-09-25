using LabModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabModel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = new List<User>();

            var user1 = new User { name = "Mark Smith", address = "Park Street", email = "Mark@mvcexample.com" };
            var user2 = new User { name = "John Parker", address = "New Park", email = "John@mvcexample.com" };
            var user3 = new User { name = "Steave Edward", address = "Melbourne Street", email = "steave@mvcexample.com" };

            user.Add(user1);
            user.Add(user2);
            user.Add(user3);

            return View(user); // Truyền danh sách Model trực tiếp vào View
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // 2. Hiển thị Form Đăng nhập (HTTP GET)
        public ActionResult Login()
        {
            return View();
        }

        // 3. Xử lý Model Binding khi bấm Submit Form (HTTP POST)
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (login.userName == "Peter" && login.password == "pass@123")
            {
                string msg = "Welcome " + login.userName;
                return Content(msg); // Hiển thị dòng chữ Welcome Peter
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
