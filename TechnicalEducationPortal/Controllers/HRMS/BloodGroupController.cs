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
    public class BloodGroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MstBloodGroup> _logger;
        public BloodGroupController(IUnitOfWork unitOfWork, ILogger<MstBloodGroup> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                BloodGroupBAL bloodGroupBAL = new(_unitOfWork);
                var result = await bloodGroupBAL.GetAllBloodGroupAsync();
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
                _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(MstBloodGroup mstBloodGroup)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    BloodGroupBAL bloodGroupBAL = new(_unitOfWork);
                    var result = await bloodGroupBAL.AddBloodGroupAsync(mstBloodGroup);
                    if (result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Blood Group: " + mstBloodGroup.BloodGroupName + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            if(id == 0)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                _logger.LogError(0, "Error {@Message} {@Params}", TempData["Message"], JsonConvert.SerializeObject(id));
                return RedirectToAction("Index");
            }
            else
            {
                BloodGroupBAL bloodGroupBAL = new(_unitOfWork);
                var result = await bloodGroupBAL.GetBloodGroupByIdAsync(id);
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
        public async Task<IActionResult> Edit(MstBloodGroup mstBloodGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BloodGroupBAL bloodGroupBAL = new(_unitOfWork);
                   var result = await bloodGroupBAL.UpdateBloodGroupAsync(mstBloodGroup);
                    if(result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Blood Group: " + mstBloodGroup.BloodGroupName + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return View();
                    }
                   
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstBloodGroup.BloodGroupId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstBloodGroup.BloodGroupId);
            }
        }

    }
}
