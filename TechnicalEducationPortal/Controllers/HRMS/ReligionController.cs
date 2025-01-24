using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class ReligionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReligionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ReligionBAL religionBAL = new(_unitOfWork);
                var religions = await religionBAL.GetAllReligionsAsync();
                if (religions == null)
                {
                    religions = new List<MstReligionVM>();
                }
                return View(religions);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                // _logger.LogError(ex, "Error {@Message} {@LogEvent}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return View();
            }

        }
       
        [HttpGet]
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
                // _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(MstReligion mstReligion)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    ReligionBAL religionBAL = new(_unitOfWork);
                    await religionBAL.AddReligionAsync(mstReligion);
                    ModelState.Clear();
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    //  _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Index");
                }


            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return View();
            }

        }
       
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                // _logger.LogError(0, "Error {@Message} {@Params}", TempData["Message"], JsonConvert.SerializeObject(id));
                return RedirectToAction("Index");
            }
            else
            {
                var result = await new ReligionBAL(_unitOfWork).GetReligionByIdAsync(id);
                try
                {
                    if (result != null)
                    {
                        return View(result);
                    }
                    else
                    {
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    // _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Index");
                }

            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MstReligion mstReligion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await new ReligionBAL(_unitOfWork).UpdateReligionAsync(mstReligion);
                    ModelState.Clear();
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    // _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstReligion.ReligionId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstReligion.ReligionId);
            }
        }



    }
}
