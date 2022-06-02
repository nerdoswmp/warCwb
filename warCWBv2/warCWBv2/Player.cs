using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warCWBv2
{
    public class Player
    {
        TurnAction action;
        Team team;

        public Player(Team team)
        {
            this.action = 0;
            this.team = team;
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
    }

    
    public enum TurnAction
    {
        PlaceTroops = 0,
        Attack = 1,
        MoveTroops = 2,
        Waiting = 3
    }
}
