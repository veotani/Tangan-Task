using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using TanganTask.Interfaces;
using TanganTask.MailBox;

namespace TanganTask.DAL
{
    class DataAccessLayer : IDataAccessLayer
    {
        private readonly string _dbLocation;

        public DataAccessLayer(string dbLoc)
        {
            _dbLocation = dbLoc;
        }

        public void Check(DateTime datemsg)
        {
            using (var db = new LiteDatabase(_dbLocation))
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
        }

        public void LastCheck()
        {
            using (var db = new LiteDatabase(_dbLocation))
            {
                var hist = db.GetCollection<MailBoxInfo>("History");
                int count = hist.Count();           //количество записей в History
                var res = hist.FindById(count);     //в последней записи будут данные о последней проверке
                Console.WriteLine(res);
            }
        }
    }
}
