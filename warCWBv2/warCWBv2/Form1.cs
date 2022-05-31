using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace warCWBv2
{
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer(Properties.Resources.trilha);
        public Form1()
        {
            
            InitializeComponent();

        }
        private void playGreca(int val)
        {
            
            switch (val)
            {
                case 0:
                    player.PlayLooping();
                    break;
                case 1:
                    player.Stop();
                    break;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playGreca(0);
            // Não mexa kkkkkkkk
            var screen = Properties.Resources.imagemPrincipal_png;
            Bitmap bmp = new Bitmap(Width, Height);
            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(screen, new Rectangle(Point.Empty, this.Size));
            this.BackgroundImage = bmp;
            screen.Dispose();
            GC.Collect(2);
        }

        private void volume_Click(object sender, EventArgs e)
        {
            mute.Visible = true;
            volume.Visible = false;
            playGreca(1);

        }

        private void mute_Click(object sender, EventArgs e)
        {
            mute.Visible = false;
            volume.Visible = true;
            playGreca(0);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            PreOff preOff = new PreOff();
            preOff.Show();
            this.Hide();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
    
}
