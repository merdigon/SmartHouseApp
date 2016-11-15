using SmartHouseApp.Client.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client
{
    public class PointPainter
    {
        Form1 MainForm;

        public PointPainter(Form1 mainForm)
        {
            MainForm = mainForm;
        }

        public void DrawPoints()
        {
            while (true)
            {
                int radius = 6;

                SolidBrush myBrush = new SolidBrush(Color.Red);
                       
                for (int i = 0; i < MainForm.Points.Count; i++)
                {
                    MethodInvoker mi = delegate ()
                    {
                        MainForm.pictureBox1.Invalidate();
                    };
                    MainForm.pictureBox1.Invoke(mi);

                    var point = MainForm.Points[i];
                    if (!point.ExpirationDate.HasValue || point.ExpirationDate.Value > DateTime.Now)
                    {
                        MethodInvoker min = delegate ()
                        {
                            MainForm.pictureBox1.CreateGraphics().FillEllipse(myBrush, (float)point.X - radius + MainForm.pictureBox1.Location.X, (float)point.Y - radius + MainForm.pictureBox1.Location.Y, radius + radius, radius + radius);
                        };
                        MainForm.pictureBox1.Invoke(min);
                    }
                    else
                        MainForm.Points.Remove(point);
                }
                Thread.Sleep(100);
            }
        }
    }
}
