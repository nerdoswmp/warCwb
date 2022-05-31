using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warCWBv2
{
    public partial class PreOff : Form
    {
        public PreOff()
        {
            InitializeComponent();

        }
        private void PreOff_Load(object sender, EventArgs e)
        {
            var screen = Properties.Resources.war;
            Bitmap bmp = new Bitmap(Width, Height);
            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(screen, new Rectangle(Point.Empty, this.Size));
            this.BackgroundImage = bmp;
            screen.Dispose();
            GC.Collect(2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            MapForm mapForm = new MapForm();
            mapForm.Show();
        }
    }
}
