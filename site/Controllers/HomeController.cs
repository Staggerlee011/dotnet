using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using site.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using static site.Models.EmailModel;
using NToastNotify;

namespace site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private readonly IToastNotification _toastNotification;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration Configuration,
             IToastNotification toastNotification)
        {
            _logger = logger;
            _configuration = Configuration;
            _toastNotification = toastNotification;
        }

        

        public IActionResult Index()
        {
            ViewData["EnvTitle"] = _configuration["Environment:Title"];
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendgridEmailSubmit(EmailModel emailmodel)
        {
            ViewData["Message"] = "Email Sent!!!...";
            SendGrid emailexample = new SendGrid();
            await emailexample.Execute(emailmodel.From, emailmodel.To, emailmodel.Subject, emailmodel.Body
                , emailmodel.Body);
            
            ModelState.Clear();
            _toastNotification.AddSuccessToastMessage("Thanks someone will be contact with you soon");
            return View("Contact");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    internal class SendGrid
    {
        public async Task Execute(string From, string To, string subject, string plainTextContent, string htmlContent)
        {
            var apiKey = "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";
            
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(From);
            var to = new EmailAddress(To);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
