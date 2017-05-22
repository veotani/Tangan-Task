using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace TanganTask
{
    public class DeliveryManager
    {
        private readonly string _login;
        private readonly string _password;
        private readonly string _server;
        private readonly int _port;
        private readonly bool _ssl;

        private static DeliveryManager _client;

        private DeliveryManager(string login, string password, string server, int port, bool ssl)
        {
            _login = login;
            _password = password;
            _server = server;
            _port = port;
            _ssl = ssl;
        }

        public static DeliveryManager Singleton(string login, string password, string server, int port, bool ssl)
        {
            if (_client == null)
            {
                _client = new DeliveryManager(login, password, server, port, ssl);
            }
            return _client;
        }

        public void SendMail(MailAddress from, MailAddress to, string subject, string body)
        {
            SmtpClient client = new SmtpClient(_server, _port);
            client.EnableSsl = _ssl;
            client.Credentials = new NetworkCredential(_login, _password);
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = from;
            message.Subject = subject;
            message.Body = body;
            client.Send(message);

        }

        public void SendMails(MailAddress from, List<MailAddress> adresses, string subject, string body)
        {
            foreach (var item in adresses)
            {
                SendMail(from, item, subject, body);
            }
        }

        public void SendMailWithAttachment(MailAddress from, MailAddress to, string subject, string body, string attachmentLocation)
        {
            SmtpClient client = new SmtpClient(_server, _port);
            client.EnableSsl = _ssl;
            client.Credentials = new NetworkCredential(_login, _password);
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = from;
            message.Subject = subject;
            message.Body = body;
            Attachment data = new Attachment(attachmentLocation);
            message.Attachments.Add(data);
            client.Send(message);
        }
    }
}
