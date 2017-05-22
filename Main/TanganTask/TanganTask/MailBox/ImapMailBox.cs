using System;
using System.Collections.Generic;
using ImapX;
using ImapX.Enums;
using TanganTask.Interfaces;

namespace TanganTask.MailBox
{
    public class ImapMailBox : IMailBox
    {
        private readonly ImapClient _client;
        private static ImapMailBox _mailbox;

        private ImapMailBox()
        {
            _client = new ImapClient();
        }

        public static ImapMailBox Singleton()
        {
            if (_mailbox == null)
            {
                _mailbox = new ImapMailBox();
            }
            return _mailbox;
        }

        public void Connect(string login, string password, string server, int port, bool ssl)
        {
            // Авторизация пользователя если подключились
            if (_client.Connect(server, port, ssl))
            {

                if (_client.Login(login, password))
                {
                    Console.WriteLine("Login successful");
                }
            }
            else
            {
                Console.WriteLine("Login unsuccessful");
            }
        }

        public List<string> GetLastTenMessages()
        {
            var res = new List<string>();
            var messages = _client.Folders.Inbox.Search("ALL", MessageFetchMode.ClientDefault, 10);
            foreach(var item in messages)
            {
                var s = item.Subject;
                res.Add(s);
            }
            return res;
        }
    }
}