using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EZCourse.Models;
using MailKit.Net.Smtp;
using MimeKit;
using EZCourse.Services;

namespace EZCourse.Controllers
{
    public class HomeController : Controller
    {
        readonly Services.Smtp _smtpService;

        public HomeController(Services.Smtp smtpService)
        {
            _smtpService = smtpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var htmlBody = $"<p>{formData.Name} ({formData.Email})</p><p>{formData.Phone}</p><p>{formData.Message}</p>";
            var textBody = "{formData.Name} {formData.Email})\r\n{formData.Phone}\r\n{formData.Message}";

            _smtpService.SendSingle("Contact Form", htmlBody, textBody, "RM", "contact@domain.com",
                                    "noreply mysite", "noreply@domain");

            /* using (var client = new SmtpClient())
             {
                 client.Connect("mail.domain.com");
                 client.Authenticate("username", "password");
                 var bodyBuilder = new BodyBuilder();
                 bodyBuilder.HtmlBody = $"<p>{formData.Name} ({formData.Email})</p><p>{formData.Phone}</p><p>{formData.Message}</p>";
                 bodyBuilder.TextBody = "{formData.Name} {formData.Email})\r\n{formData.Phone}\r\n{formData.Message}";

                 var message = new MimeMessage();
                 message.Body = bodyBuilder.ToMessageBody();
                 message.From.Add(new MailboxAddress("noreply mysite", "noreply@video.com"));
                 message.To.Add(new MailboxAddress("RM", "contact@domain.com"));
                 message.Subject = "Contact Form";
                 client.Send(message);

                 client.Disconnect(true);

             }*/

            TempData["Message"] = "Thank you! Your message is sent to us";
            return RedirectToAction("Contact");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
