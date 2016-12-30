using SmartHouseApp.Client.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHouseApp.Client.Model;

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
            Thread.Sleep(2000);
            while (true)
            {
                int radius = 6;

                SolidBrush myBrush = new SolidBrush(Color.Red);
                MethodInvoker mi = delegate ()
                    {
                        //MainForm.pictureBox1.Invalidate();
                        //graph.Clear(Color.Transparent);
                        Bitmap bitmap = new Bitmap(MainForm.PictureSize.Width, MainForm.PictureSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        bitmap.MakeTransparent();

                        using (var graph = Graphics.FromImage(bitmap))
                        {
                            for (int j = 0; j < MainForm.DeviceList.Count; j++)
                            {
                                var device = MainForm.DeviceList[j];
                                var positionForDevice = ResizeUserLocalizationDependingOnPictureSize(MainForm, device.X, device.Y);
                                graph.DrawImage(RenderTools.GetImageForDevice(device.DeviceCategory), new Rectangle(new Point(positionForDevice.Item1 + MainForm.pictureBox1.Location.X, positionForDevice.Item2 + MainForm.pictureBox1.Location.Y), new Size(32, 32)));

                            }

                            for (int i = 0; i < MainForm.Points.Count; i++)
                            {
                                var point = MainForm.Points[i];
                                if (!point.ExpirationDate.HasValue || point.ExpirationDate.Value > DateTime.Now)
                                {
                                    var positionForPoint = ResizeUserLocalizationDependingOnPictureSize(MainForm, point.X, point.Y);
                                    graph.FillEllipse(myBrush, (float)positionForPoint.Item1 - radius + MainForm.pictureBox1.Location.X, (float)positionForPoint.Item2 - radius + MainForm.pictureBox1.Location.Y, radius + radius, radius + radius);

                                }
                                else
                                    MainForm.Points.Remove(point);
                            }
                            
                            MainForm.pictureBox2.Image = bitmap;
                        }
                    };
                MainForm.pictureBox2.Invoke(mi);
                Thread.Sleep(500);
            }
        }

        public static Tuple<int, int> ResizeUserLocalizationDependingOnPictureSize(Form1 mainForm, double x, double y)
        {
            int xIS = mainForm.PictureSize.Width;
            int yIS = mainForm.PictureSize.Height;

            int xREAL = (int)((x / mainForm.MapSize.Item1) * xIS);
            int yREAL = (int)((y / mainForm.MapSize.Item2) * yIS);
            return new Tuple<int, int>(xREAL, yREAL);
        }
    }
}
