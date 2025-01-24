using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalEducationPortal.Utilities
{
    public class AlertMessageEnum
    {
        public enum AlertMsg
        {
            [Display(Name = "Record saved successfully.")] insertMsg = 1,
            [Display(Name = "Record updated successfully.")] updatetMsg = 2,
            [Display(Name = "Details deleted successfully.")] deleteMsg = 3,
            [Display(Name = "Already exists.")] alreadyMsg = 4,
            [Display(Name = "All fields are mandatory.")] mandatoryMsg = 5,
            [Display(Name = "Record not found.")] notFoundMsg = 6,
            [Display(Name = "Please,try after sometime.")] userMsg = 7,
            [Display(Name = "Record is not deleted,please try after sometime.")] notDeleteMsg = 8,
            [Display(Name = "State is already used in Division Master.")] StateAlreadyUsedDivisionMsg = 9,
            [Display(Name = "Division is already used in District Master.")] DivisionAlreadyUsedDistrictMsg = 10,
            [Display(Name = "Management Group is already used in School Management Group Detail.")] SmgAlreadyUsedSmgdMsg = 11,
            [Display(Name = "School Medium is already used in School Registration.")] SchoolMediumAlreadyUsedSchoolRegMsg = 12,
            [Display(Name = "School Management Group Detail is already used in School Registration.")] SmgdAlreadyUsedSchoolRegMsg = 13,
            [Display(Name = "Habitation is already used in School Registration.")] HabitationAlreadyUsedSchoolRegMsg = 14,
            [Display(Name = "Record is approved successfully.")] RecordApproved = 15,
            [Display(Name = "Record is rejected successfully.")] RecordRejected = 16,
            [Display(Name = "Request Generated successfully.")] RequestGenerated = 17,
            [Display(Name = "Invalid UDISE Code.")] InvalidUDISECode = 18,
            [Display(Name = "Invalid OTP")] InvalidOTP = 19,
            [Display(Name = "Invalid Remark")] InvalidRemark = 20,
            [Display(Name = " is already used in School Registration.")] AlreadyUsedRecord = 21,
            [Display(Name = " ToDate must be greater than or equal to the FromDate and Month must be same(ex : 01/01/2021 - 31/01/2021)")] DateValidation = 22,
            [Display(Name = " is already used in User Role Master.")] AlreadyUsedRole = 23,
            [Display(Name = " Upload PDF File Only.")] UploadPDFFileOnly = 24,
        }
        public enum AlertCode
        {
            [Display(Name = "success")] sucessCode = 1,
            [Display(Name = "warning")] WarningCode = 2,
            [Display(Name = "error")] errorCode = 3,
        }

        public static string GetEnumDisplayName(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DisplayAttribute displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
