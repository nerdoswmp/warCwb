using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warCWBv2
{
    public class Zona
    {
        private List<Territorio> territorios = new List<Territorio>();
        private int bonusTroops { get; }
        private string name;

        public Zona(int troops, string name) { this.bonusTroops = troops; this.name = name; }
        public bool InsertTerr(Territorio territorio)
        {
            if (!territorios.Contains(territorio))
            {
                territorios.Add(territorio);
                return true;
            }
            return false;
        }

        public List<Territorio> GetTerritorios()
        {
            return territorios;
        }

        public string GetName()
        {
            return name;
        }
    }
}
