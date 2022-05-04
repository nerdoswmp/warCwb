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
using System.Reflection;

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

            List<Bitmap> list = new List<Bitmap>();

            Timer tm = new Timer();
            tm.Interval = 50;

            Zona cic = new Zona(3);
            Territorio t = new Territorio(true, Properties.Resources._1mapa_cwb_outline, cic);

            //string filepath = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", @"\Resources\assets_mapa");
            //DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var prop in typeof(Properties.Resources).GetRuntimeProperties())
            {
                Console.WriteLine(prop.Name);
                var bmp = prop.GetValue(prop.GetType());
                if (bmp != null)
                {
                    if (bmp.GetType() == pb.Image.GetType() && prop.Name.StartsWith("_"))
                    {
                        Console.WriteLine(bmp);
                        Console.WriteLine(bmp.GetType());
                        list.Add(new Bitmap((Bitmap)bmp));
                        //g.DrawImage(x, new RectangleF(0, 0, pb.Width, pb.Height), new RectangleF(0, 0, x.Width, x.Height), GraphicsUnit.Pixel);
                    }
                }

            }

            tm.Tick += delegate
            {
                g.Clear(Color.White);

                foreach (var map in list)
                {
                    g.DrawImage(map, new RectangleF(0, 0, pb.Width, pb.Height), new RectangleF(0, 0, map.Width, map.Height), GraphicsUnit.Pixel);
                }

                pb.Refresh();
            };
            tm.Start();
        }

    }

}
