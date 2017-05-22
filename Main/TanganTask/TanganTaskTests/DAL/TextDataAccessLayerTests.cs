using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanganTask.DAL.DAL;

namespace TanganTaskTests.DAL
{
    [TestClass()]
    public class TextDataAccessLayerTests
    {
        [TestMethod()]
        public void TextDataAccessLayerTest()
        {
            TextDataAccessLayer db = new TextDataAccessLayer();
        }

        [TestMethod()]
        public void LastCheckTest()
        {
            TextDataAccessLayer db = new TextDataAccessLayer();
            db.LastCheck();
        }

        [TestMethod()]
        public void CheckTest()
        {
            TextDataAccessLayer db = new TextDataAccessLayer();
            db.Check(DateTime.Now);
        }
    }
}