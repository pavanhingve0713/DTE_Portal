using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class MstDistrictController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;     
        public MstDistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;          
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                MstDistrictBAL mstDistrictBAL = new MstDistrictBAL(_unitOfWork);
                var result = await mstDistrictBAL.GetAllDistrictAsync();
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                // _logger.LogError(ex, "Error {@Message} {@LogEvent}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                return View();
            }

        }
        public async Task FillStatesAsync()
        {
            var states = await _unitOfWork.districtRepository.FillStatesAsync();
            var statesList = states
                .Select(i => new SelectListItem
                {
                    Text = i.StateCode + " - " + i.StateNameEng,
                    Value = i.StateId.ToString(),
                })
                .ToList();
            ViewBag.StateId = statesList;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDivisions(int stateId)
        {
            var divisions = await _unitOfWork.districtRepository.GetDivisionsByStateIdAsync(stateId);

            if (divisions == null || !divisions.Any())
            {
                return Json(new { success = false, message = "No divisions found" });
            }
            var divisionList = divisions.Select(d => new
            {
                Text = d.DivisionNameEng,
                Value = d.DivisionId.ToString(),
                Diviscode = d.DivisionCode
            }).ToList();
            Console.WriteLine("Division List: " + JsonConvert.SerializeObject(divisionList));

            return Json(new { success = true, data = divisionList });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDivisionss(int stateId)
        {
            var divisions = await _unitOfWork.districtRepository.GetDivisionsByStateIdAsync(stateId);
            var divisionList = divisions.Select(d => new { Value = d.DivisionId, Text = d.DivisionNameEng }).ToList();

            return Json(new { success = true, data = divisionList });
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                await FillStatesAsync();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MstDistrict mstDistrict)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MstDistrictBAL mstDistrictBAL = new(_unitOfWork);
                    var result = await mstDistrictBAL.AddDistrictAsync(mstDistrict);

                    if (result == true)
                    {
                        ModelState.Clear();
                        TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstDistrict.DistrictCode + " " + AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                        TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                        return View();
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
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var district = await _unitOfWork.districtRepository.EditDistrictAsync(id);

            if (district == null)
            {
                return NotFound();
            }
            var states = await _unitOfWork.districtRepository.FillStatesAsync();
            var stateList = states.Select(s => new SelectListItem
            {
                Text = $"{s.StateCode} - {s.StateNameEng}",
                Value = s.StateId.ToString()
            }).ToList();
            ViewBag.StateId = new SelectList(stateList, "Value", "Text", district.StateId.ToString());
            var divisions = await _unitOfWork.districtRepository.GetDivisionsByStateIdAsync(district.StateId);
            var divisionList = divisions.Select(d => new SelectListItem
            {
                Text = $"{d.DivisionCode} - {d.DivisionNameEng}",
                Value = d.DivisionId.ToString(),
            }).ToList();
            ViewBag.DivisionId = new SelectList(divisionList, "Value", "Text", district.DivisionId.ToString());
            return View(district);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MstDistrict mstDistrict)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MstDistrictBAL mstDistrictBAL = new(_unitOfWork);
                    var result = await mstDistrictBAL.UpdateDistrictAsync(mstDistrict);
                    if (result == true)
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
                    // _logger.LogError(ex, "Error {@Message} {@Params}", ex.Message, JsonConvert.SerializeObject(ex.Message));
                    return RedirectToAction("Edit", mstDistrict.DistrictId);
                }

            }
            else
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                return RedirectToAction("Edit", mstDistrict.DistrictId);
            }

        }
    }
}
