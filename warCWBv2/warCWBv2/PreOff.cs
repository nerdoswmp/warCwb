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
                gs = new GameScreen();
                gs.Show();
                this.Close();
            }
            else if(comboBox2.SelectedIndex == 1 || comboBox3.SelectedIndex == 2 || comboBox4.SelectedIndex == 2)
            {
                MessageBox.Show("Ainda não implementamos a IA");
            }
            else if(comboBox3.SelectedIndex == 0 || comboBox4.SelectedIndex == 0)
            {
                MessageBox.Show("Apenas o modo de 4 players está implementado");
            }
            else
            {
                MessageBox.Show("Selecione os 4 players");
            }
        }


    }
}
