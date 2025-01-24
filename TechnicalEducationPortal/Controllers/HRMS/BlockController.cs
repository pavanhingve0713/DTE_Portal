using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class BlockController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MstBlock> _logger;
        public BlockController(IUnitOfWork unitOfWork, ILogger<MstBlock> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                BlockBAL blockBAL = new(_unitOfWork);
                var result = await blockBAL.GetAllBlockAsync();
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                _logger.LogError(ex, "Error {@Message} {@LogEvent}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return View();
            }

        }
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return RedirectToAction("Index");
            }

        }
    }
}
