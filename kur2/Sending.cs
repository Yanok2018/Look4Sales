using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kur2
{
    class Sending
    {
        public void SendMessege(string msg, string clientmail)
        {

            MailAddress from = new MailAddress("supernikd@gmail.com", "Tom");

            MailAddress to = new MailAddress(clientmail);

            MailMessage m = new MailMessage(from, to);

            m.Subject = "Тест";

            m.Body = msg;

            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("supernikd@gmail.com", "killmepls");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
    }
}
