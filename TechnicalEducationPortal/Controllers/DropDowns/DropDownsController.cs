using HRMS.Business.CommonBAL;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalEducationPortal.Web.Controllers.DropDowns
{
    public class DropDownsController : Controller
    {
        private readonly IDropDowns _dropDowns;
        private readonly IUnitOfWork _unitOfWork;
        public DropDownsController(IDropDowns dropDowns, IUnitOfWork unitOfWork)
        {
            _dropDowns = dropDowns;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
       
       
    }
}
