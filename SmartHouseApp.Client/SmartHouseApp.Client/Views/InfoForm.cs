using SmartHouseApp.Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client.Views
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        public static void ShowError(string msg)
        {
            using (InfoForm info = new InfoForm())
            {
                info.pictureBox1.Image = Resources.do_not_disturb_96px;
                info.label1.Text = msg;
                info.Text = "Błąd!";
                info.ShowDialog();
            }
        }

        public static void ShowWarning(string msg)
        {
            using (InfoForm info = new InfoForm())
            {
                info.pictureBox1.Image = Resources.error_96px;
                info.label1.Text = msg;
                info.Text = "Ostrzeżenie!";
                info.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
