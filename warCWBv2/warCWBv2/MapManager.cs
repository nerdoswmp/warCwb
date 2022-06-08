using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static warCWBv2.MapForm;
using static warCWBv2.GameScreen;

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

        public string Clear(Color target, Point p, int input)
        {
            int index = toindex(p);
            Color origin = Color.FromArgb(bytes[index + 3], bytes[index + 2], bytes[index + 1], bytes[index]);
            if (target.A == origin.A && target.R == origin.R && target.G == origin.G && target.B == origin.B && input != 2)
                return null;
            if (origin.A == 255 && origin.R == 255 && origin.G == 255 && origin.B == 255 && input != 2)
                return null;
            if (origin.A == 255 && origin.R == 0 && origin.G == 0 && origin.B == 0 && input != 2)
                return null;
            if (origin.A == 255 && origin.R == 255 && origin.G == 165 && origin.B == 0 && input != 2)
                return null;

            switch (input)
            {
                case 0: return clear(origin, target, index, 0);
                case 1: return clear(origin, target, index, 1);
                case 2: return search(origin, target, index);
            }
            return null;
        }

        private string clear(Color origin, Color target, int index, int input)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(index);
            int crr = -1;
            var t = GetTerritorioCoords();
            string tername = null;
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

                if (t.Contains(topoint(crr)) && input == 1)
                {
                    tername = GetTerritorios().Where(x => x.GetCoord() == topoint(crr)).Single().GetName();
                    Console.WriteLine($"{tername} | {topoint(crr)}");
                }
            }
            return tername;
        }

        private string search(Color origin, Color target, int index)
        {
            if (target.A != origin.A || target.R != origin.R || target.G != origin.G || target.B != origin.B)
            {
                return null;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(index);
            int crr = -1;
            var t = GetTerritorioCoords();
            string tername = null;
            var tmp = Color.Transparent;
            while (stack.Count > 0)
            {
                crr = stack.Pop();
                if (!compare(crr, origin))
                    continue;
                bytes[crr + 3] = tmp.A;
                bytes[crr + 2] = tmp.R;
                bytes[crr + 1] = tmp.G;
                bytes[crr + 0] = tmp.B;
                stack.Push(crr + channels);
                stack.Push(crr - channels);
                stack.Push(crr + stride);
                stack.Push(crr - stride);

                if (t.Contains(topoint(crr)))
                {
                    tername = GetTerritorios().Where(x => x.GetCoord() == topoint(crr)).Single().GetName();
                }
            }
            clear(tmp, target, index, 1);
            return tername;
        }


        private int toindex(Point p)
            => channels * p.X + p.Y * stride;

        private Point topoint(int index)
            => new Point((index % stride) / channels, (index / stride));

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
                Clear(teams[i++].GetColor(), ter.GetCoord(), 0);
                
            }
        }

        public void ReClear()
        {
            foreach (var t in GetTerritorios())
            {
                var color = GetAllTeams().Where(x => x.GetTerritorios().Contains(t)).Single().GetColor();
                Clear(color, t.GetCoord(), 1);
            }
        }
    }
}
