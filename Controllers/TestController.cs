using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name="sakshitha",
                DateOfBirth=new DateTime(2004,07,22)
            };
            return View(data);
        }
    }
}
