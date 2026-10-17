using Microsoft.AspNetCore.Mvc;

namespace NetCoreLA7.Areas.Admins.ViewComponents
{
    public class NavLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}