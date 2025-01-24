using HRMS.Business.Masters;
using HRMS.Business.Masters.HRMS.Business.Masters;
using HRMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HRMS.Infrastructure.Contract;
using HRMS.Entities.Models;
using TechnicalEducationPortal.Utilities;
using Newtonsoft.Json;

namespace TechnicalEducationPortal.Controllers.HRMS
{
    public class StateMasterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StateMasterController> _logger;


        public StateMasterController(IUnitOfWork unitOfWork , ILogger<StateMasterController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                StateMasterBL stateMasterBL = new(_unitOfWork);
                var states = await stateMasterBL.GetAllStateAsync();

               
                var viewModel = states.Select(state => new MstStateViewModel
                {
                    StateId = state.StateId,
                    StateNameEng = state.StateNameEng,
                    StateNameHin = state.StateNameHin,
                    StateCode = state.StateCode,
                    IsActive = state.IsActive
                }).ToList();

                return View(viewModel);
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
                _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, System.Text.Json.JsonSerializer.Serialize(ex.Message));
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MstState mstState)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    StateMasterBL stateMasterBL = new(_unitOfWork);
                    await stateMasterBL.InsertStateAsync(mstState);
                    ModelState.Clear();
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                    return RedirectToAction("Index");

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
        public async Task<IActionResult> Edit(Int16 id = 0)
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
                StateMasterBL stateMasterBL = new(_unitOfWork);
                var result = await stateMasterBL.GetStateByIdAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MstState mstState)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StateMasterBL stateMasterBL = new(_unitOfWork);
                    await stateMasterBL.UpdateStateAsync(mstState);
                    ModelState.Clear();
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstState.StateId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstState.StateId);
            }
        }

    }
}
