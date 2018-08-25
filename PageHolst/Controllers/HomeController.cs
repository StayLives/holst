using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PageHolst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       public JsonResult SendEmail(string name,string tel,string email)
        {
            string msg = string.Empty;
           if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(tel)){
               using (MailMessage mm = new MailMessage("Auzergos@gmail.com", "Auzergos@gmail.com")){
                   mm.Subject = "ЗаказHolst";
                   mm.Body = "Имя: " + name + "<br/>" + "Телефон: " + tel + "<br/>" + "Почта: " + email;
                   mm.IsBodyHtml = true;
                   using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 25)){
                       sc.EnableSsl = true;
                       sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                       sc.UseDefaultCredentials = false;
                       sc.EnableSsl = true;
                       sc.Timeout = 100000;
                       sc.Credentials = new NetworkCredential("Auzergos@gmail.com", "Monika7575");
                       sc.Send(mm);
                   }
               }
           }
           else{
               msg = "Заполните обязательные поля";
            }
           return Json(new { Answer = msg });
        }
    }
}