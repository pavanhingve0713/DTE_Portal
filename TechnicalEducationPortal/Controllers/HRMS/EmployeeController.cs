using HRMS.Business.Masters;
using HRMS.Entities.Models;
using HRMS.Entities.ViewModels;
using HRMS.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TechnicalEducationPortal.Utilities;

namespace TechnicalEducationPortal.Web.Controllers.HRMS
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                EmployeeBAL employeeBAL = new(_unitOfWork);
                var result = await employeeBAL.GetAllEmployeeAsync();
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.notFoundMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                return View();
            }


        }
        [HttpGet]
        public IActionResult Create()
        {
			try
			{
				var model = new EmployeeInfoVM();
				return View(model);
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
        public async Task<IActionResult> Create(string employeeDataJson)
        {
            if (string.IsNullOrEmpty(employeeDataJson))
            {
                TempData["Message"] = "No employee data provided.";
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                return RedirectToAction("Index");
            }

            try
            {

                var employeeData = JsonConvert.DeserializeObject<List<EmployeeInfo>>(employeeDataJson);

                if (employeeData == null || !employeeData.Any())
                {
                    TempData["Message"] = "No valid employee data found.";
                    TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                    return RedirectToAction("Index");
                }

                foreach (var employee in employeeData)
                {

                    EmployeeBAL employeeBAL = new(_unitOfWork);
                    await employeeBAL.AddEmployeeAsync(employee);
                }

                ModelState.Clear();
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.userMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.errorCode;
                return RedirectToAction("Index");
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
                EmployeeBAL employeeBAL = new(_unitOfWork);
                var result = await employeeBAL.GetEmployeeByIdAsync(id);
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
        public async Task<IActionResult> Edit(EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
					await new EmployeeBAL(_unitOfWork).UpdateEmployeeAsync(employeeInfo);
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
					return RedirectToAction("Edit", employeeInfo.EmpId);
				}

			}
			else
			{
				TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.mandatoryMsg);
				TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
				return RedirectToAction("Edit", employeeInfo.EmpId);
			}
		}
    }
}
    
