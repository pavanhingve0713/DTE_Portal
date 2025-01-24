using HRMS.Entities.Models;
using SchoolEducationPortal.Services.ProfilePic;
using System.ComponentModel.DataAnnotations;

namespace SchoolEducationPortal.Services.OtpGenerate
{
    public class OTPGenratorViewModel
    {
        [Display(Name = "Enter OTP to Validate")]
        [Required(ErrorMessage = "Enter OTP to Validate")]
        public string GenerateOTP { get; set; }

        public ProfilePicViewModel? ProfilePicViewModel { get; set; }

        public EmpBankDetailsRegistration? EmpBankDetailsRegistration { get; set; }

        public MstEmployeeRegistration? MstEmployeeRegistration {  get; set; }

        public NomineeDetails? NomineeDetail { get; set; }

        public EmpAppointmentDetails? EmpAppointmentDetails {  get; set; }
        public IEnumerable<NomineeDetails>? NomineeDetails { get; set; }
        public IEnumerable<EmpQualificationDetails>? EmpQualificationDetails { get; set; }
    }
}
