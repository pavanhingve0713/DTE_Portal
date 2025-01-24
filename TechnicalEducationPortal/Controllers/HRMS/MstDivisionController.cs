using HRMS.Entities.Models;
using HRMS.Business.Masters; // Assuming MstDivisionBAL is in this namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMS.Infrastructure.Contract;
using Newtonsoft.Json;
using TechnicalEducationPortal.Utilities;
using HRMS.Entities.ViewModels;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class MstDivisionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MstDivisionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                MstDivisionBAL divisionBL = new(_unitOfWork);
                var divisions = await divisionBL.GetAllDivisionAsync();
                return View(divisions);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                // _logger.LogError(ex, "Error {@Message} {@LogEvent}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return View();
            }
           
        }

        public async Task<IActionResult> Create()
        {
            MstDivisionBAL divisionBL = new(_unitOfWork);

            // Fetch all active states
            var states = await divisionBL.GetAllStatesAsync();

            // Check if there are no states
            if (states == null || !states.Any())
            {
                TempData["Error"] = "No states found.";  // Display error message if no states found
                return RedirectToAction(nameof(Index));  // Redirect to the Index page
            }

            // Bind the active states to the dropdown in ViewBag
            ViewBag.mstStateList = new SelectList(
                states.Where(s => s.IsActive)  // Filter active states
                      .OrderBy(s => s.StateCode)  // Order by StateCode
                      .Select(s => new
                      {
                          StateId = s.StateId,
                          StateName = s.StateCode + " - " + s.StateNameEng  // Combine StateCode and StateName
                      }),
                "StateId",  // Value field (StateId)
                "StateName" // Text field (StateName)
            );

            return View();
        }

        // POST: Create Division
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MstDivision division)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MstDivisionBAL divisionBL = new(_unitOfWork);
                    await divisionBL.InsertDivisionAsync(division);
                    ModelState.Clear();
                    TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                    return RedirectToAction("Index");
                }

                // If validation fails, retry with the states list
                MstDivisionBAL divisionBLRetry = new(_unitOfWork);
                var states = await divisionBLRetry.GetAllStatesAsync();
                ViewBag.mstStateList = states; // Bind states again on failure
                return View(division);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                // _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return RedirectToAction("Index");
            }
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            MstDivisionBAL divisionBL = new(_unitOfWork);

            // Fetch the division using the given id
            var divisionResult = await divisionBL.GetDivisionByIdAsync(id);

            // Check if division is found
            if (divisionResult.Item1 == null)
            {
                TempData["Error"] = divisionResult.Item2;  // Display error message if division not found
                return RedirectToAction(nameof(Index));    // Redirect to the Index page
            }

            var division = divisionResult.Item1;  // Get the division object
            var states = await divisionBL.GetAllStatesAsync();  // Fetch all active states

            // Check if there are no states
            if (states == null || !states.Any())
            {
                TempData["Error"] = "No states found.";  // Display error message if no states found
                return RedirectToAction(nameof(Index));  // Redirect to the Index page
            }

            // Bind the states list to the dropdown
            ViewBag.mstStateList = new SelectList(
                states.Where(s => s.IsActive)   // Filter active states
                      .OrderBy(s => s.StateCode)  // Order states by StateCode
                      .Select(s => new
                      {
                          StateId = s.StateId,
                          StateName = s.StateCode + " - " + s.StateNameEng // Combine StateCode and StateName
                      }),
                "StateId",   // Value field (StateId)
                "StateName", // Text field (StateName)
                division.StateId // Set the selected state based on division's StateId
            );

            return View(division);  // Return the view with the division data
        }



        // POST: Edit Division
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MstDivision division)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MstDivisionBAL divisionBL = new(_unitOfWork);
                    var updateResult = await divisionBL.UpdateDivisionAsync(division);

                    // If update is successful
                    if (updateResult.Item2)
                    {

                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
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
                    //  _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Index");
                }



            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", division.DivisionId);
            }

            //MstDivisionBAL divisionBLRetry = new(_unitOfWork);
            //var states = await divisionBLRetry.GetAllStatesAsync();
            //ViewBag.mstStateList = new SelectList(states, "StateId", "StateName", division.StateId); // Set selected state
            //return View(division);
        }
    }
}
