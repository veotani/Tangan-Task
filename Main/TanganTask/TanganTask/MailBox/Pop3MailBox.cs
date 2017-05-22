using System.Collections.Generic;
using OpenPop.Pop3;
using TanganTask.Interfaces;

namespace TanganTask.MailBox
{
    public class Pop3MailBox: IMailBox
    {
        private readonly Pop3Client _client;
        private static Pop3MailBox _mailbox;
        private Pop3MailBox()
        {
            _client = new Pop3Client();
        }
        public static Pop3MailBox Singleton()
        {
            if (_mailbox == null)
            {
                _mailbox = new Pop3MailBox();
            }
            return _mailbox;
        }

        public void Connect(string login, string password, string server, int port, bool ssl)
        {
            // Подключаемся к серверу
            _client.Connect(server, port, ssl);
            // Авторизация пользователя
            _client.Authenticate(login, password);
        }
        public List<string> GetLastTenMessages()
        {
            var res = new List<string>();
            var messageCount = _client.GetMessageCount();
            var i = messageCount;
            while(i >= messageCount - 9 && i >= 1)
            {
                var headers = _client.GetMessageHeaders(i);
                var subject = headers.Subject;
                res.Add(subject);
                i--;
            }
            return res;
        }
    }
}