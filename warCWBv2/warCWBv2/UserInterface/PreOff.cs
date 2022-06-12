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
        public static GameScreen gs;
        public PreOff()
        {
            InitializeComponent();

        }
        private void PreOff_Load(object sender, EventArgs e)
        {
            var screen = Properties.Resources.preoff1;
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
            if(comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 1 && comboBox4.SelectedIndex == 1)
            {
                gs = new GameScreen(4);
                gs.Show();
                this.Close();
            }

            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
            {
                gs = new GameScreen(2);
                gs.Show();
                this.Close();
            }

            else if(comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 1 && comboBox4.SelectedIndex == 0)
            {
                gs = new GameScreen(3);
                gs.Show();
                this.Close();
            }

            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1 && comboBox3.SelectedIndex == 0 && comboBox4.SelectedIndex == 0)
            {
                gs = new GameScreen(5);
                gs.Show();
                this.Close();
            }

            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1 && comboBox3.SelectedIndex == 2 && comboBox4.SelectedIndex == 0)
            {
                gs = new GameScreen(6);
                gs.Show();
                this.Close();
            }

            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1 && comboBox3.SelectedIndex == 2 && comboBox4.SelectedIndex == 2)
            {
                gs = new GameScreen(7);
                gs.Show();
                this.Close();
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 2 && comboBox4.SelectedIndex == 2)
            {
                gs = new GameScreen(8);
                gs.Show();
                this.Close();
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 1 && comboBox4.SelectedIndex == 2)
            {
                gs = new GameScreen(9);
                gs.Show();
                this.Close();
            }
            else if (tb_Codigo.Text == "grecalover")
            {
                gs = new GameScreen(10);
                gs.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione os 4 players");
            }
        }


    }
}
