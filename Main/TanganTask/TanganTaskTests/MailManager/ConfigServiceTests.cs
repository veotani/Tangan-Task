using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.MailManager.Config;

namespace TanganTaskTests.MailManager
{
    [TestClass()]
    public class ConfigServiceTests
    {

        [TestMethod()]
        public void FieldsTest()
        {
            var config = ConfigService.Singleton();
            var server = config.ImapServer;
            server = config.Pop3Server;
            var port = config.ImapPort;
            port = config.Pop3Port;
            var ssl = config.ImapSSL;
            ssl = config.Pop3SSL;
        }
    }
}