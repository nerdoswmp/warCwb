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
using static warCWBv2.Form1;

namespace warCWBv2
{
    public partial class Config : Form
    {
        
        public Config()
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
        private void picOn_Click(object sender, EventArgs e)
        {
            picOff.Visible = true;
            picOn.Visible = false;
            playGreca(1);
        }

        private void picOff_Click(object sender, EventArgs e)
        {
            picOff.Visible = false;
            picOn.Visible = true;
            playGreca(0);
        }
    }
}
