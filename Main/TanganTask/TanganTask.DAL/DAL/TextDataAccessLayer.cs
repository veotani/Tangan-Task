using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TanganTask.DAL.Interfaces;

namespace TanganTask.DAL.DAL
{
    public class TextDataAccessLayer : IDataAccessLayer
    {
        private List<String> db = new List<string>();
        public TextDataAccessLayer()
        {
            using (StreamReader sr = new StreamReader(@"D:\DataBaseTest\DataBase.txt"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    db.Add(line);
                }
            }
        }

        public string LastCheck()
        {
            string lane = db[db.Count - 1];
            string lastcheck = lane.Substring(0, 10);
            string lastmsg = lane.Substring(13, 10);
            return lastcheck;
        }

        public void Check(DateTime datemsg)
        {
            DateTime now = DateTime.Now;
            string st = now.ToString().Substring(0, 10);
            string st2 = datemsg.ToString().Substring(0, 10);
            string str = st + "   " + st2;
            db.Insert(0, str);
        }
        ~TextDataAccessLayer()
        {
            File.WriteAllText("database.txt", "");
            using (StreamWriter sw = new StreamWriter("database.txt"))
            {
                int i = db.Count - 1;
                while (i >= 0)
                {
                    sw.WriteLine(db[i]);
                    i--;
                }
            }
        }
    }
}