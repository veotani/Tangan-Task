using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using TanganTask.Interfaces;

namespace TanganTask.DAL
{
    class TextDataAccessLayer : IDataAccessLayer
    {
        private List<String> db = new List<string>();
        public TextDataAccessLayer()
        {
            using (StreamReader sr = new StreamReader("database.txt"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    db.Add(line);
                }
            }
        }

        public void LastCheck()
        {
            try
            {
                string lane = db[0];
                string lastcheck = lane.Substring(0, 10);
                string lastmsg = lane.Substring(13, 10);
                Console.WriteLine("Последняя проверка осуществлялась: {0}; Последнее сообщение в ящике получено {1}",
                    lastcheck,
                    lastmsg);
            }
            catch (Exception)
            {
                Console.WriteLine("File doesn't exist or empty.");
            }
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