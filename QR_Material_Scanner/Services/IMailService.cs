using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QR_Material_Scanner.Services;
using QR_Material_Scanner.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace QR_Material_Scanner.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }

    internal class SendMailService : IMailService
    {
        EmailConfiguration emailConfiguration = new EmailConfiguration();

        private readonly ILogger<SendMailService> _logger;
        private readonly IConfiguration _configuration;

        public SendMailService(ILogger<SendMailService> logger, IConfiguration configuration)
        {
       
            _logger = logger;
            _configuration = configuration;


            emailConfiguration.From = _configuration.GetSection("EmailConfiguration")["From"];
            emailConfiguration.SmtpServer = _configuration.GetSection("EmailConfiguration")["SmtpServer"];
            emailConfiguration.Port = Convert.ToInt32(_configuration.GetSection("EmailConfiguration")["Port"]);
            emailConfiguration.UserName = _configuration.GetSection("EmailConfiguration")["UserName"];
            emailConfiguration.Password = _configuration.GetSection("EmailConfiguration")["Password"];

        }

        public  Task SendEmailAsync(string toEmail, string subject, string content)
        {

            //var apiKey = _configuration["SendGridAPIKey"];
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("test@authdemo.com", "JWT Auth Demo");
            //var to = new EmailAddress(toEmail);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            //var response = await client.SendEmailAsync(msg);


            //MailMessage mm = new MailMessage();
            //mm.From = 
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress("Ariston Thermo", emailConfiguration.From));

       
            mailMessage.To.Add(new MailboxAddress(toEmail, toEmail));
            mailMessage.Subject = subject;
            var bodyBuilder = new BodyBuilder { HtmlBody =  content };
            mailMessage.Body = bodyBuilder.ToMessageBody();
         

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                smtpClient.Authenticate(emailConfiguration.UserName, emailConfiguration.Password);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            _logger.LogWarning("Dummy IEmailSender implementation is being used!!!");
            _logger.LogDebug($"{toEmail}{Environment.NewLine}{subject}{Environment.NewLine}{content}");
            return Task.CompletedTask;
        }
       
    }
}
