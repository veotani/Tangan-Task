using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.MailManager.Config;

namespace TanganTaskTests.MailManager
{
    [TestClass()]
    public class PasswordRegistryTests
    {
        [TestMethod()]
        public void GetPasswordTest()
        {
            if (!PasswordRegistry.GetPassword("HKEY_CURRENT_CONFIG", "TanganPassword", "HKEY_CURRENT_CONFIG//TanganPassword").Equals("TestOK")) Assert.Fail();
        }
    }
}