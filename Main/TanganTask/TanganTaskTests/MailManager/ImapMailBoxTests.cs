using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.MailManager.Config;
using TanganTask.MailManager.MailBox;

namespace TanganTaskTests.MailManager
{
    [TestClass()]
    public class ImapMailBoxTests
    {
        private ImapMailBox _connection;
        [TestMethod()]
        public void ConnectTest()
        {
            var config = ConfigService.Singleton();
            var server = config.ImapServer;
            var port = config.ImapPort;
            var ssl = config.ImapSSL;
            var login = "tangantasktest";
            var password = "Testing111";
            
            _connection = ImapMailBox.Singleton();
            _connection.Connect(login, password, server, port, ssl);
        }

        [TestMethod()]
        public void GetLastTenMessagesTest()
        {
            if (_connection == null)
            {
                ConnectTest();
            }
            var messages = new List<string>();
            messages = _connection.GetLastTenSubjects();
        }

        [TestMethod()]
        public void LastUnreadDateTest()
        {
            var config = ConfigService.Singleton();
            var server = config.ImapServer;
            var port = config.ImapPort;
            var ssl = config.ImapSSL;
            var login = "tangantasktest";
            var password = "Testing111";
            var mailbox = ImapMailBox.Singleton();
            mailbox.Connect(login, password, server, port, ssl);
            Assert.IsNotNull(mailbox.LastUnreadDate());
        }

        [TestMethod()]
        public void SaveLastAttachmentTest()
        {
            if (_connection == null)
            {
                ConnectTest();
            }
            _connection.SaveLastAttachment(@"D:\tempAttachm", "testattach");
        }
    }
}