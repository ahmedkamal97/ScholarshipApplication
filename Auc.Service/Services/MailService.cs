using Auc.Common.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Auc.Service.Services
{
    public class MailService
    {
        private StudentService _studentService;
        public MailService()
        {
            _studentService = new StudentService();
        }

        public void SendMail(int Id)
        {
            var Student = _studentService.GetStudents().FirstOrDefault(c=>c.Id==Id);

            string Recept = Student.EmailAddress;
            var Subject = "";


   


            Subject = "Scholarship Application" + DateTime.Today.Date.ToString("dd-MM-yyyy");
            var MailBody = "";

            MailBody =  HtmlBody(Student);

            SendMail(Recept, Subject, MailBody);


        }
        public static void SendMail(string Recept, string subject, string body)
        {
            string EmailUser() => "";
            string EmailPassword() => "";

            using (SmtpClient smtp = new SmtpClient())
            {
                using (MailMessage Mail = new MailMessage())
                {
                    
                    Mail.To.Add(Recept);
                    Mail.From = new MailAddress($"{EmailUser()}@gmail.com", "ScholarShip Application");
                    smtp.Credentials = new NetworkCredential(EmailUser(), EmailPassword());
                    Mail.Subject = subject;
                    Mail.IsBodyHtml = true;
                    Mail.Body = body;
                    smtp.Send(Mail);
                }
            }
        }
        public static string HtmlBody(StudentVM Entity)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("<P>Dear, " +Entity.FirstName+"  "+Entity.SecondName + 
                "</p><P>Good day!</p>" +
                "<P>We just need to inform you that your application is " + Entity.Status + " "+"</p>");
            return SB.ToString();
        }


    }
}
