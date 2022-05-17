using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace warCWBv2
{
    public class MapManager
    {
        public Bitmap Map { get; private set; } = Properties.Resources.mapfull;
        private byte[] bytes = null;
        private int stride = 0;
        private BitmapData data = null;

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
                stack.Push(crr + 4);
                stack.Push(crr - 4);
                stack.Push(crr + stride);
                stack.Push(crr - stride);
            }
        }

        private int toindex(Point p)
            => 4 * p.X + p.Y * stride;

        private Point topoint(int index)
            => new Point((index % stride) / 4, (index / stride) / 4);

        private bool compare(int index, Color c)
            => bytes[index + 3] == c.A && bytes[index + 2] == c.R && bytes[index + 1] == c.G && bytes[index] == c.B;
    }
}
