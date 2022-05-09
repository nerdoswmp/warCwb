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
        private int troops { get; set; }
        private bool bonus { get; }
        private Bitmap mapImg { get; set; }
        public Territorio(bool bonus, Bitmap img, Zona zona) 
        { 
            this.zona = zona;
            this.bonus = bonus;
            this.mapImg = img;
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

        public Bitmap getBitmap()
        {
            return mapImg;
        }
        public List<Territorio> GetAdjacente()
        {
            return terAdjacente;
        }
    }
}
