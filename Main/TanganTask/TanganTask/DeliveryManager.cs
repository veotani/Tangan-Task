using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace TanganTask
{
    public class DeliveryManager
    {
        public static void SendMail(string login, string password, MailAddress from, MailAddress to, string subject, string body, string server, int port, bool ssl)
        {
            SmtpClient client = new SmtpClient(server, port);
            client.EnableSsl = ssl;
            client.Credentials = new NetworkCredential(login, password);
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = from;
            message.Subject = subject;
            message.Body = body;
            client.Send(message);

        }
        public static void SendMails(string login, string password, MailAddress from, List<MailAddress> adresses, string subject, string body, string server, int port, bool ssl)
        {
            foreach (var item in adresses)
            {
                SendMail(login, password, from, item, subject, body, server, port, ssl);
            }
        }
    }
}
