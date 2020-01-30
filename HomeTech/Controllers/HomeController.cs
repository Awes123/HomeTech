using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TechVibes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string Contact(string name, string number, string mail, string msg)
        {
            string rtnmsg = "Done";
            string bodys="Hi " +name+" <br><br>Thanks For Your Feedback. The <b>Tech Vibes Team</b> will contact you soon.<br><br><b>Best Regards</b><br><b>TECH VIBES Team</b>";
            string EBody1 = "Hi Admin,<br><br> you have new message from : <br><table><tr><td>Name</td><td>"+name+"<td></tr><tr><td>Email</td><td>"+mail+"<td></tr><tr><td>Mobile</td><td>"+number+"<td></tr></table><br><h4>" + msg + "</h4><br><br>Please take a look and provide answer as required.";
            sendemails(mail, bodys);
            sendemails("fahadshaikh123487@gmail.com", EBody1);
            sendemails("bagban333awes@gmail.com", EBody1);
            return rtnmsg;
        }
       
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        public void GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            GmailSSL = true;
        }

        public void Send()
        {

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }
        public void sendemails(string Email,string statment)
        {
            string Usermail = string.Empty;
            string UsPass = string.Empty;
            GmailUsername = "awesfdev@gmail.com";
            GmailPassword = "Techvibes1";
            GMailer();
            ToEmail = Email;
            Subject = "TECH VIBES FEEDBACK";
            Body = statment;
            IsHtml = true;
            Send();
        }

    }

}