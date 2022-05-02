using System;
using System.Collections.Generic;
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
        private string mapImg { get; set; }
        private string root = Directory.GetCurrentDirectory();
        public Territorio(bool bonus, string img, Zona zona) 
        { 
            this.zona = zona;
            this.bonus = bonus;
            this.mapImg = root.Replace(@"\bin\Debug", "") + img;
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

        public List<Territorio> GetAdjacente()
        {
            return terAdjacente;
        }
    }
}
