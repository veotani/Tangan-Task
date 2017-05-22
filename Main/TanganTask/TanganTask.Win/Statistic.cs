using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanganTask.DAL.DAL;
using TanganTask.MailManager.Config;
using TanganTask.MailManager.MailBox;

namespace TanganTask.Win
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            var mailBox = ImapMailBox.Singleton();
            var config = ConfigService.Singleton();
            mailBox.Connect("tangantasktest", 
                PasswordRegistry.GetPassword("HKEY_CURRENT_CONFIG", "TanganPassword", "HKEY_CURRENT_CONFIG//TanganPassword"), 
                config.ImapServer, 
                config.ImapPort, config.ImapSSL);
            int unread = mailBox.CountUnread();
            var dal = new DataAccessLayer("Database.db");
            dal.Check(mailBox.LastUnreadDate());
            this.label1.Text = "Количество непрочитанных сообщений: " + unread;
        }
    }
}
