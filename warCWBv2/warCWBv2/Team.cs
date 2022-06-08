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
        public Color Color;
        private List<Zona> zonas = new List<Zona>();
        private List<Territorio> territorios = new List<Territorio>();
        private int troopsToInsert = 5;
        public Team(Color color)
        {
            this.Color = color;
        }

        public void RefreshToInsert()
        {
            troopsToInsert = 2 + zonas.Count() + (territorios.Count()/2)-2;
        }

        public int GetTroopsToInsert()
        {
            return troopsToInsert;
        }
        public bool InsertZona(Zona zona)
        {
            bool haszone = zona.GetTerritorios().All(t => territorios.Contains(t));
            if (haszone && !zonas.Contains(zona))
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

        public bool RemoveTerr(Territorio territorio)
        {
            if (territorios.Contains(territorio))
            {
                territorios.Remove(territorio);
                return true;
            }
            return false;
        }

        public List<Territorio> GetTerritorios()
        {
            return territorios;
        }

        public List<Zona> GetZonas()
        {
            return zonas;
        }

        public Color GetColor()
        {
            return Color;
        }
    }
}
