using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalEducationPortal.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var userBAL = new UserBAL(_unitOfWork);
            var user = await userBAL.AuthenticateUser(email, password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid credentials";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDetail userDetail)
        {
            await _unitOfWork.userRepository.AddUserAsync(userDetail);
            ModelState.Clear();
            return RedirectToAction("Login");
        }
    }
}
