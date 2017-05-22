using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask;
using TanganTask.MailManager.Config;

namespace TanganTaskTests.MailManager
{
    [TestClass()]
    public class DeliveryManagerTests
    {
        [TestMethod()]
        public void SendMailTest()
        {
            var server = "smtp.yandex.ru";
            var port = 25;
            var ssl = true;
            var login = "tangantasktest@yandex.ru";
            var password = "Testing111"; 
            var from = new MailAddress("tangantasktest@yandex.ru");
            var to = new MailAddress("tangantasktest@gmail.com");
            var connection = DeliveryManager.Singleton(login, password, server, port, ssl);
            connection.SendMail(from, to, "This is testing message for our application",
                "This is testing message for our application. If you get it, feel free to delete it. We must be doing something wrong. We are sorry for bothering you." +
                " Have a nice day!");
        }

        [TestMethod()]
        public void SendMailsTest()
        {
            var server = "smtp.yandex.ru";
            var port = 25;
            var ssl = true;
            var login = "tangantasktest@yandex.ru";
            var password = "Testing111";
            var from = new MailAddress("tangantasktest@yandex.ru");
            var to = new List<MailAddress>()
            {
                new MailAddress("tangantasktest@gmail.com"),
                new MailAddress("ion6431@gmail.com")
            };

            var connection = DeliveryManager.Singleton(login, password, server, port, ssl);
            connection.SendMails(from, to, "This is testing message for our application",
                "This is testing message for our application. If you get it, feel free to delete it. We must be doing something wrong. We are sorry for bothering you." +
                " Have a nice day!");
        }

        [TestMethod()]
        public void SendMailWithAttachmentTest()
        {

            var server = "smtp.yandex.ru";
            var port = 25;
            var ssl = true;
            var login = "tangantasktest@yandex.ru";
            var password = "Testing111";
            var from = new MailAddress("tangantasktest@yandex.ru");
            var to = new MailAddress("tangantasktest@gmail.com");
            var attachPath = @"D:\v\test.txt";
            var connection = DeliveryManager.Singleton(login, password, server, port, ssl);
            connection.SendMailWithAttachment(from, to, "test1",
                "test2", attachPath);
        }

    }
}