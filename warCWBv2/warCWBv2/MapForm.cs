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

namespace warCWBv2
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {

        }

    }

    public abstract class DrawingArea : Panel
    {

        protected Graphics graphics;
        abstract protected void OnDraw();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Don't paint background
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Update the private member so we can use it in the OnDraw method
            this.graphics = e.Graphics;

            // Set the best settings possible (quality-wise)
            this.graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.graphics.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Calls the OnDraw subclass method
            OnDraw();
        }
    }

    class TerritorioImg : DrawingArea
    {
        protected override void OnDraw()
        {
            // Gets the image from the global resources
            Image cicImg = global::warCWBv2.Properties.Resources.CIC;
            Image bgImg = global::warCWBv2.Properties.Resources.mapa_cwb_outline;

            // Sets the images' sizes and positions
            Rectangle big = new Rectangle(0, 0, 454, 720);

            // Draws the two images
            this.graphics.DrawImage(cicImg, big);
            this.graphics.DrawImage(bgImg, big);
        }
    }
}
