using System;
using System.Collections.Generic;
using System.Linq;
using ImapX;
using ImapX.Enums;
using TanganTask.MailManager.Interfaces;

namespace TanganTask.MailManager.MailBox
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

        public List<string> GetLastTenSubjects()
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
        public int CountUnread()
        {
            var messages = _client.Folders.Inbox.Search("UNSEEN", MessageFetchMode.ClientDefault);
            return messages.Length;
        }

        public DateTime LastUnreadDate()
        {
            var messages = _client.Folders.Inbox.Search("UNSEEN", MessageFetchMode.InternalDate, 1);
            return messages.Last().Date.GetValueOrDefault();
        }

        public void SaveLastAttachment(string folder, string filename)
        {
            var message = _client.Folders.Inbox.Search("ALL", MessageFetchMode.ClientDefault, 1);
            foreach (var file in message[0].Attachments)
            {
                file.Download();
                file.Save(folder, filename);
            }
            
        }
    }
}