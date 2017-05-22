using System;
using System.Windows.Forms;

namespace TanganTask.Win
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            this.version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private void showStatisticButton_Click(object sender, EventArgs e)
        {
            Statistic stat = new Statistic();
            stat.Show();
        }
    }
}
