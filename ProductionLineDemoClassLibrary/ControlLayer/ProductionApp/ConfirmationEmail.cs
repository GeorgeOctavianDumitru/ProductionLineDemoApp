using ProductionLineDemoClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHIELD.B67.MIR200.ClassLibrary.ControlLayer
{
    public class ConfirmationEmail
    {
        
       
        public static void send(string Name, string to, string from, string subject, string stopreason)
        {

            string message = $"Hello {Name},<br/>" +
                $"The AGV recovered from a stop <b>@{DateTime.Now.ToShortTimeString()}</b> on <b>{DateTime.Now.ToShortDateString()}</b> <br/>. " +
                $"The stop has been caused by {stopreason} and lasted for .....(s)";

            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(to);
                mailMessage.From = new MailAddress(from);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"{HTMLSTART}{message}{CLOSEMESSAGE}{SIGNATURE}";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Send(mailMessage);
                
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Could not send e-mail message because of {ex.Message}!");
            }


        }

        private const string HTMLSTART = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=us-ascii"" />
            </head>
            <body
            lang=""EN-GB""
            link=""#0563C1""
            vlink=""#954F72""
            style=""word-wrap: break-word""
            >
            <div class=""WordSection1"">

                <p class=""MsoNormal"">";
        private const string CLOSEMESSAGE = @"<o:p>&nbsp;</o:p></p><br/>";
        private const string SIGNATURE = @"
                GeorgeOctavianDumitru Company Footer
                </body>
            </html>";

    }
}
