using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warCWBv2
{
    public class Player
    {
        private int objective;
        TurnAction action;
        Team team;

        public Player(Team team, int obj)
        {
            this.action = 0;
            this.team = team;
            this.objective = obj;
        }

        public Team GetTeam()
        {
            return this.team;
        }

        public TurnAction GetAction()
        {
            return this.action;
        }

        public void NextAct()
        {
            this.action++;
        }

        public void ResetAct()
        {
            this.action = 0;
        }

        public int GetObjective()
        {
            return objective;
        }
        public bool ValidateObjective()
        {
            bool win = false;
            int tmp = 0;
            switch (this.objective)
            {
                case 0:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "CIC" || z.GetName() == "PORTÃO" || z.GetName() == "CAJURU")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 3)
                    {
                        win = true;
                    }
                    break;
                case 1:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "PINHEIRINHO" || z.GetName() == "BAIRRO NOVO" || z.GetName() == "BOA VISTA")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 3)
                    {
                        win = true;
                    }
                    break;
                case 2:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "BOQUEIRÃO" || z.GetName() == "PINHEIRINHO" || z.GetName() == "SANTA FELICIDADE")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 3)
                    {
                        win = true;
                    }
                    break;
                case 3:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "MATRIZ" || z.GetName() == "PORTÃO")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 2)
                    {
                        win = true;
                    }
                    break;
                case 4:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "CIC" || z.GetName() == "BOA VISTA" || z.GetName() == "BAIRRO NOVO")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 3)
                    {
                        win = true;
                    }
                    break;

            }

            return win;
        }
    }

    
    public enum TurnAction
    {
        PlaceTroops = 0,
        Attack = 1,
        MoveTroops = 2,
        Waiting = 3
    }
}
//:)