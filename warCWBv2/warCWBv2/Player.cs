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
    }

    public enum TurnAction
    {
        PlaceTroops = 0,
        Attack = 1,
        MoveTroops = 2,
        Waiting = 3
    }
}
