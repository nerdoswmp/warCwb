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

            Zona cic = new Zona(3);

            Timer tm = new Timer();
            tm.Interval = 10;

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
                        var img = (Bitmap)bmp;
                        territorioList.Add(new Territorio(true, img, cic));
                    }
                }

            }

            var rec = new RectangleF(0, 0, pb.Width, pb.Height);
            var outline = Properties.Resources._1mapa_cwb_outline;
            var outrec = new RectangleF(0, 0, outline.Width, outline.Height);

            tm.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(outline, rec, outrec, GraphicsUnit.Pixel);
                foreach (var map in territorioList)
                {
                    var bmpmap = map.getBitmap();
                    g.DrawImage(bmpmap, rec, outrec, GraphicsUnit.Pixel);
                }

                pb.Refresh();
            };
            tm.Start();
        }

    }

}
