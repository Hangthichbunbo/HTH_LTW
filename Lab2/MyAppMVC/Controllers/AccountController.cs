using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;

namespace MyAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/02.jpg"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id = 1,Name="Trường Giang",
                    Email="giang@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/03.jpg"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id = 1,Name="Hoàng Thúy",
                    Email="thuy@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jpg"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
            };

            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("Ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            Account account = new Account()
            {
                Id = 1,
                Name = "Hoàng Anh",
                Email = "anh@gmail.com",
                Phone = "0986456789",
                Address = "Hà Nội",
                Avatar = Url.Content("~/Avatar/02.jfif"),
                Gender = 1,
                Bio = "My name is small",
                Birthday = new DateTime(1998, 7, 15)
            };
            // gửi đối tượng account qua view
            ViewBag.account = account;
            return View();
        }
    }
}