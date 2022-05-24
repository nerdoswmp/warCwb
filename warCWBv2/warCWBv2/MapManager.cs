using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static warCWBv2.MapForm;

namespace warCWBv2
{
    public class MapManager
    {
        private int channels = 4;
        public Bitmap Map { get; private set; } = Properties.Resources.mapfull;
        private byte[] bytes = null;
        private int stride = 0;
        private BitmapData data = null;
        private Random rand = new Random();

        public void Initialize()
        {
            data = Map.LockBits(new Rectangle(Point.Empty, Map.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            this.stride = data.Stride;
            if (bytes == null)
                bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        }

        public void Close()
        {
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
            Map.UnlockBits(data);
        }

        public void Clear(Color target, Point p)
        {
            int index = toindex(p);
            Color origin = Color.FromArgb(bytes[index + 3], bytes[index + 2], bytes[index + 1], bytes[index]);
            if (target.A == origin.A && target.R == origin.R && target.G == origin.G && target.B == origin.B)
                return;
            if (origin.A == 255 && origin.R == 255 && origin.G == 255 && origin.B == 255)
                return;
            clear(origin, target, index);
        }

        private void clear(Color origin, Color target, int index)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(index);
            int crr = -1;

            while (stack.Count > 0)
            {
                crr = stack.Pop();
                if (!compare(crr, origin))
                    continue;
                bytes[crr + 3] = target.A;
                bytes[crr + 2] = target.R;
                bytes[crr + 1] = target.G;
                bytes[crr + 0] = target.B;
                stack.Push(crr + channels);
                stack.Push(crr - channels);
                stack.Push(crr + stride);
                stack.Push(crr - stride);
            }
        }

        private int toindex(Point p)
            => channels * p.X + p.Y * stride;

        private Point topoint(int index)
            => new Point((index % stride) / channels, (index / stride) / channels);

        private bool compare(int index, Color c)
            => bytes[index + 3] == c.A && bytes[index + 2] == c.R && bytes[index + 1] == c.G && bytes[index] == c.B;

        public void ClearRandom(List<Territorio> territorios)
        {
            Team[] teams = GetAllTeams();
            int i = rand.Next(0,4);
            territorios = territorios.OrderBy(a => rand.Next()).ToList();
            foreach (var ter in territorios)
            {
                if (i >= 4)
                {
                    i = 0;
                }
                teams[i].InsertTerr(ter);
                Clear(teams[i++].GetColor(), ter.GetCoord());
                
            }
        }
    }
}
