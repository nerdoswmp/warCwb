using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace warCWBv2
{
    public partial class MapForm : Form
    {
        Graphics g;
        List<Territorio> territorioList = new List<Territorio>();
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            pb.Refresh();

            Timer tm = new Timer();
            tm.Interval = 50;

            Zona cic = new Zona(3);
            Territorio t = new Territorio(true, Properties.Resources.mapa_cwb_outline, cic);

            string filepath = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", @"\Resources\assets_mapa");
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.png"))
            {
                Directory.Move(file.FullName, filepath + "\\TextFiles\\" + file.Name);
            }

            Bitmap bg = Properties.Resources.mapa_cwb_outline;
            var aguaverde = Properties.Resources.AGUA_VERDE; 
            var portao = Properties.Resources.PORTAO;

            tm.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(bg, new RectangleF(0, 0, pb.Width, pb.Height), new RectangleF(0, 0, aguaverde.Width, aguaverde.Height), GraphicsUnit.Pixel);
                g.DrawImage(aguaverde, new RectangleF(0, 0, pb.Width, pb.Height), new RectangleF(0, 0, aguaverde.Width, aguaverde.Height), GraphicsUnit.Pixel);
                g.DrawImage(portao, new RectangleF(0, 0, pb.Width, pb.Height), new RectangleF(0, 0, aguaverde.Width, aguaverde.Height), GraphicsUnit.Pixel);

                pb.Refresh();
            };
            tm.Start();
        }

    }

}
