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
        private int troops = 2;
        private bool bonus;

        private Point coord;
        private string name;
        public Territorio(bool bonus, Point coord, Zona zona, string name)
        {
            this.zona = zona;
            this.bonus = bonus;
            this.coord = coord;
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

        public void RemoveTroops(int t)
        {
            troops -= t;
        }
        public int GetTroops()
        {
            return troops;
        }

        public void SetTroop(int troop)
        {
            troops = troop;
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
        public Point GetCoord()
        {
            return coord;
        }

        public void SetCoords(Point p)
        {
            coord = p;
        }
        public List<Territorio> GetAdjacente()
        {
            return terAdjacente;
        }
    }
}
