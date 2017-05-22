using System;
using LiteDB;
using TanganTask.DAL.Interfaces;

namespace TanganTask.DAL.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private LiteDatabase db;
        public DataAccessLayer(string dbLoc)
        {
            db = new LiteDatabase(dbLoc);
        }

        public void Check(DateTime datemsg)
        {
            var hist = db.GetCollection<MailBoxInfo>("History");
            var mail = new MailBoxInfo
            {
                Updated = DateTime.Now,
                Last = datemsg
            };
            hist.Insert(mail);
            hist.EnsureIndex("Updated");
        }

        public string LastCheck()
        {
            var hist = db.GetCollection<MailBoxInfo>("History");
            int count = hist.Count(); //количество записей в History
            var res = hist.FindById(count); //в последней записи будут данные о последней проверке
            return res.ToString();
        }

        ~DataAccessLayer()
        {
            db.Dispose();
        }
    }
}
