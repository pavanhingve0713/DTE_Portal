using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class BoardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MstBoard> _logger;
        public BoardController(IUnitOfWork unitOfWork, ILogger<MstBoard> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {

                BoardBAL boardBAL = new(_unitOfWork);
                var result = await boardBAL.GetAllBoardAsync();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MstBoard mstBoard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BoardBAL boardBAL = new(_unitOfWork);
                    var result = await boardBAL.AddBoardAsync(mstBoard);
                    if (result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstBoard.BoardCode + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return View();
                    }
                }
                else
                {
                    TempData["Message"] = "Please fill all required fields.";
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                    return View(mstBoard);
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
                BoardBAL boardBAL = new(_unitOfWork);
                var result = await boardBAL.GetBoardByIdAsync(id);  
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
        public async Task<IActionResult> Edit(MstBoard mstBoard)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BoardBAL boardBAL = new(_unitOfWork);
                    var existName = boardBAL.GetAllBoardAsync().Result.Where(i => i.BoardCode == mstBoard.BoardCode && i.BoardId != mstBoard.BoardId).FirstOrDefault();
                    if (existName == null) 
                    {
                        var result = await boardBAL.UpdateBoardAsync(mstBoard);
                        if(result == true)
                        {
                            ModelState.Clear();
                            TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                            TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            TempData["Message"] = "Code No. : " + mstBoard.BoardCode + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                            TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                            return View();
                        }
                        
                    }
                    else
                    {
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstBoard.BoardId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstBoard.BoardId);
            }

        }

    }
}
