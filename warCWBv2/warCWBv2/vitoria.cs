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

namespace warCWBv2
{
    public partial class vitoria : Form
    {
        SoundPlayer SoundPlayer = new SoundPlayer(Properties.Resources.X2Download_com_TV_Globo__Tema_da_Vitória__Ayrton_Senna___128_kbps_);
        public vitoria()
        {
            InitializeComponent();
            SoundPlayer.Play();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SoundPlayer.Stop();
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
