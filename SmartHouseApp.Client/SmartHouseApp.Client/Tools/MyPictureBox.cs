using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client.Tools
{
    public partial class MyPictureBox : PictureBox
    {
        public Image MainPicture;       

        public MyPictureBox()
        {
            //MainPicture = new Bitmap(1, 1);
            InitializeComponent();
        }

        public MyPictureBox(Image mainPicture)
        {
            InitializeComponent();
        }

        public string ImageLocationNew
        {
            set
            {
                base.ImageLocation = value;
                MainPicture = (Image)this.Image.Clone();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (MainPicture != null && this.Image != null)
            {
                this.Image = (Image)MainPicture.Clone();
                base.OnResize(e);
                MainPicture = (Image)this.Image;
            }
        } 
    }
}
