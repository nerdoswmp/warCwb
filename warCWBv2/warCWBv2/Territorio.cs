using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warCWBv2
{
    public class Territorio
    {
        private List<Territorio> terAdjacente = new List<Territorio>();
        private Zona zona { get; }
        private int troops { get => this.troops; set => this.troops = value;}
        private bool bonus { get => this.bonus; set => this.bonus = value; }

        private Bitmap mapImg;
        private string name;
        public Territorio(bool bonus, Bitmap img, Zona zona, string name)
        {
            this.zona = zona;
            this.bonus = bonus;
            this.mapImg = img;
            this.name = name;
         }

        public bool InsertTerr(Territorio territorio)
        {
            if (!terAdjacente.Contains(territorio))
            {
                terAdjacente.Add(territorio);
                return true;
            }
            return false;
        }

        public string GetName()
        {
            return name;
        }

        public Bitmap GetBitmap()
        {
            return mapImg;
        }
        public List<Territorio> GetAdjacente()
        {
            return terAdjacente;
        }
    }
}
