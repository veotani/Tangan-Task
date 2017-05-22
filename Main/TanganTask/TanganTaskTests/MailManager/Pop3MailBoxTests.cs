using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.MailManager.Config;
using TanganTask.MailManager.MailBox;

namespace TanganTaskTests.MailManager
{
    [TestClass()]
    public class Pop3MailBoxTests
    {
        private Pop3MailBox _connection;
        [TestMethod()]
        public void ConnectTest()
        {
            var config = ConfigService.Singleton();
            var server = config.Pop3Server;
            var port = config.Pop3Port;
            var ssl = config.Pop3SSL;
            var login = "tangantasktest";
            var password = "Testing111";
            _connection = Pop3MailBox.Singleton();
            _connection.Connect(login, password, server, port, ssl);
        }

        [TestMethod()]
        public void GetLastTenMessagesTest()
        {
            ConnectTest();
            var messages = new List<string>();
            messages = _connection.GetLastTenMessages();
        }
    }
}