﻿using System;
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
    public partial class Mapa : Form
    {
        public Mapa()
        {
            InitializeComponent();
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            var screen = Properties.Resources.warm4;
            Bitmap bmp = new Bitmap(Width, Height);
            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(screen, new Rectangle(0, 0, 720, 720));
            this.BackgroundImage = bmp;
            screen.Dispose();
            GC.Collect(2);
        }
    }
}
