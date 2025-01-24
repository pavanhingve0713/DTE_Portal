using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class CasteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CasteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                CasteBAL casteBAL = new(_unitOfWork);
                var casteList = await casteBAL.GetAllCasteAsync();
                return View(casteList);
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
        public async Task<IActionResult> Create(MstCaste mstCaste)
        {
            if (ModelState.IsValid)
            {      
                try
                {
                    mstCaste.CreatedOn = DateTime.UtcNow;
                    mstCaste.CreatedByIP = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

                    // Save the caste data
                    CasteBAL casteBAL = new(_unitOfWork);
                    await casteBAL.AddCasteAsync(mstCaste);
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
        [HttpGet]
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
                CasteBAL casteBAL = new(_unitOfWork);
                var result = await casteBAL.GetCasteByIdAsync(id);
                try
                {
                    if(result != null)
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
        public async Task<IActionResult> Edit(MstCaste mstCaste)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await new CasteBAL(_unitOfWork).UpdateCasteAsync(mstCaste);
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
                    return RedirectToAction("Edit", mstCaste.CasteId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstCaste.CasteId);
            }
        }
    }
}
