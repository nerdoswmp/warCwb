using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace warCWBv2
{
    public class Team
    {
        public Color Color { get; set; }
        private int objective { get; set; }
        private List<Zona> zonas = new List<Zona>();
        private List<Territorio> territorios = new List<Territorio>();

        public bool InsertZona(Zona zona)
        {
            bool haszone = zona.GetTerritorios().All(t => territorios.Contains(t));
            if (haszone)
                zonas.Add(zona);
            return haszone;
        }

        public bool InsertTerr(Territorio territorio)
        {
            if (!territorios.Contains(territorio))
            {
                territorios.Add(territorio);
                return true;
            }
            return false;
        }

    }
}
