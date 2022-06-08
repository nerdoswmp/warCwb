using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static warCWBv2.GameScreen;

namespace warCWBv2
{
    public class Team
    {
        private Color Color;
        private List<Zona> zonas = new List<Zona>();
        private List<Territorio> territorios = new List<Territorio>();
        private int troopsToInsert = 5;
        public Team(Color color)
        {
            this.Color = color;
        }

        public void RefreshToInsert()
        {
            troopsToInsert = 2 + (zonas.Count()*2) + (territorios.Count()/2)-2;
        }

        public int GetTroopsToInsert()
        {
            return troopsToInsert;
        }
        public bool InsertZona(Zona zona)
        {
            bool haszone = zona.GetTerritorios().All(t => territorios.Contains(t));
            var prevteam = GetAllTeams().Where(z => z.GetZonas().Contains(zona) && z != this).FirstOrDefault();
            if (prevteam != null)
            {
                prevteam.RemoveZona(zona);
            }
            if (haszone && !zonas.Contains(zona))
            {
                //Console.WriteLine("added");
                zonas.Add(zona);
            }
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

        public bool RemoveZona(Zona zona)
        {
            try
            {
                this.zonas.Remove(zona);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Color GetColor()
        {
            return Color;
        }
    }
}
