using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnicalEducationPortal.Controllers.HRMS;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class ParliamentaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MstParliamentary> _logger;
        public ParliamentaryController(IUnitOfWork unitOfWork, ILogger<MstParliamentary> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;   
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ParliamentryBAL parliamentryBAL = new(_unitOfWork);
                var result = await parliamentryBAL.GetAllParliamentaryAsync();
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
        [HttpPost]
        public async Task<IActionResult> Create(MstParliamentary mstParliamentary)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ParliamentryBAL parliamentryBAL = new(_unitOfWork);
                   var result = await parliamentryBAL.AddParliamentaryAsync(mstParliamentary);
                    if(result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstParliamentary.ParliamentaryCode + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return View();
                    }
                   
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
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
                _logger.LogError(0, "Error {@Message} {@Params}", TempData["Message"], JsonConvert.SerializeObject(id));
                return RedirectToAction("Index");
            }
            else
            {
                ParliamentryBAL parliamentryBAL = new(_unitOfWork);
                var result = await parliamentryBAL.GetParliamentaryByIdAsync(id);
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
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Index");
                }
            }
           

        }
        [HttpPost]
        public async Task<IActionResult> Edit(MstParliamentary mstParliamentary)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ParliamentryBAL parliamentryBAL = new(_unitOfWork);
                    var result = await parliamentryBAL.UpdateParliamentaryAsync(mstParliamentary);
                    if (result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstParliamentary.ParliamentaryCode + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return View();
                    }
                  
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstParliamentary.ParliamentaryId);
                }
              
            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstParliamentary.ParliamentaryId);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            ParliamentryBAL parliamentryBAL = new(_unitOfWork);
            await parliamentryBAL.DeleteParliamentaryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
