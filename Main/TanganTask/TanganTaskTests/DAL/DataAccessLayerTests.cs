using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.DAL.DAL;

namespace TanganTaskTests.DAL
{
    [TestClass()]
    public class DataAccessLayerTests
    {
        [TestMethod()]
        public void DataAccessLayerTest()
        {
            DataAccessLayer dal = new DataAccessLayer("D://DataBaseTest/TestDB");
        }

        [TestMethod()]
        public void CheckTest()
        {
            DataAccessLayer db = new DataAccessLayer("D://DataBaseTest/TestDB");
            db.Check(DateTime.Now);
            DateTime dt = new DateTime(2007, 2, 3);
            db.Check(dt);
        }

        [TestMethod()]
        public void LastCheckTest()
        {
            DataAccessLayer db = new DataAccessLayer("D://DataBaseTest/TestDB");
            db.LastCheck();
        }
    }
}