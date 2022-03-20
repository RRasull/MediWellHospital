using Microsoft.AspNetCore.Mvc;

namespace MediWellHospital.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
