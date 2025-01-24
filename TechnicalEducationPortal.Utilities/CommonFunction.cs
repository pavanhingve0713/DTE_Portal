using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalEducationPortal.Utilities
{
    public class CommonFunction
    {
        public string GetIP()
        {
            string hostName = Dns.GetHostName();
            return Convert.ToString(Dns.GetHostByName(hostName).AddressList[0]);
        }


        //private readonly IHttpContextAccessor? _contextAccessor;

        //public CommonFunction(IHttpContextAccessor contextAccessor)
        //{
        //    _contextAccessor = contextAccessor;
        //}
        //public string GetIP()
        //{
        //    //string hostName = Dns.GetHostName();
        //    //return Convert.ToString(Dns.GetHostByName(hostName).AddressList[0]);

        //    return IpAddressHelper.GetClientIpAddress(_contextAccessor.HttpContext);
        //}
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        //public static async Task<bool> SendEmail(string emailTo, string emailsFrom, string subject, string body, string name, int port, string password, string smtpHost)
        //{
        //    try
        //    {

        //        var email = new MimeMessage();
        //        email.From.Add(MailboxAddress.Parse(emailsFrom + "@mail.stmpmail.in"));
        //        string[] emails = emailTo.Split(',');
        //        foreach (var mails in emails)
        //        {
        //            email.To.Add(MailboxAddress.Parse(mails));
        //        }
        //        email.Subject = subject;
        //        email.Body = new TextPart(TextFormat.Html)
        //        {
        //            Text = "<h3>Hello " + name + ",<br/> Your Valid OTP for Registration of user is below, Kinly Please validate the OTP Code.</h3>" + "<h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + body + "</h2>"
        //        };

        //        using (var smtp = new MailKit.Net.Smtp.SmtpClient())
        //        {
        //            // smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //            //  smtp.Authenticate("abhijeethalder9101@gmail.com", "lwtp wpgy zpzi fwkx");

        //            smtp.Connect(smtpHost, port, SecureSocketOptions.None);
        //            smtp.Authenticate(emailsFrom, password);
        //            await smtp.SendAsync(email);
        //            smtp.DisconnectAsync(true);
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static async Task<BankDetailVM> GetBankDetailsbyIfscCode(string IfscCode)
        //{
        //    BankDetailVM _bank = new BankDetailVM();
        //    try
        //    {
        //        using (var client = new WebClient())
        //        {
        //            //client.Headers.Add("DY-X-Authorization: 8fe69b30f07a07692796fbd751d625a7d0920d1c");
        //            var result = client.DownloadString("https://ifsc.razorpay.com/" + IfscCode.Trim());
        //            var BankResult = JsonConvert.DeserializeObject<BankDetailVM>(result);
        //            _bank.bank = BankResult.bank;
        //            _bank.IFSC = BankResult.IFSC;
        //            _bank.MICR = BankResult.MICR;
        //            _bank.branch = BankResult.branch;
        //            _bank.Address = BankResult.Address;
        //            _bank.Contact = BankResult.Contact;
        //            _bank.City = BankResult.City;
        //            _bank.District = BankResult.District;
        //            _bank.State = BankResult.State;
        //            return _bank;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return _bank;
        //}
    }
}
