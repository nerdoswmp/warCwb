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
        private Zona zona;
        private int troops;
        private bool bonus;

        private object mapImg;
        private string name;
        public Territorio(bool bonus, object img, Zona zona, string name)
        {
            this.zona = zona;
            this.bonus = bonus;
            this.mapImg = img;
            this.name = name.ToLower().Replace("_", "");
         }

        public void InsertTerr(Territorio[] territorios)
        {
            foreach( var t in territorios)
            {
                if (!terAdjacente.Contains(t))
                {
                    terAdjacente.Add(t);
                }
            }
        }

        public void AddTroops(int t)
        {
            troops += t;
        }
        public int GetTroops()
        {
            return troops;
        }

        public bool GetBonus()
        {
            return bonus;
        }
        public string GetName()
        {
            return name;
        }
        public Zona GetZona()
        {
            return zona;
        }
        public object GetBitmap()
        {
            return mapImg;
        }
        public List<Territorio> GetAdjacente()
        {
            return terAdjacente;
        }
    }
}
