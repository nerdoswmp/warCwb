using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static warCWBv2.GameScreen;

namespace warCWBv2
{
    public class Player
    {
        private int objective;
        TurnAction action;
        Team team;
        bool playing = true;

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
                case 5:
                    foreach (var z in team.GetZonas())
                    {
                        if (z.GetName() == "CIC" || z.GetName() == "BOA VISTA" || z.GetName() == "BAIRRO NOVO" || z.GetName() == "MATRIZ" ||
                             z.GetName() == "PORTÃO" || z.GetName() == "CAJURU" || z.GetName() == "BOQUEIRÃO" || z.GetName() == "PINHEIRINHO" ||
                              z.GetName() == "SANTA FELICIDADE")
                        {
                            tmp++;
                        }
                    }
                    if (tmp == 9)
                    {
                        win = true;
                    }
                    break;
                    //case 5:
                    //    switch (GetAllPlayers().Length)
                    //    {
                    //        case 2:
                    //            if (!GetAllPlayers().Where(x => x.GetTeam() != this.team).First().IsAlive())
                    //            {
                    //                win = true;
                    //            }
                    //            break;

                    //            // é necessário fazer uma condição pra cada player em cada quantidade de jogadores onde
                    //            // o inimigo a ser morto não pode ser você, e visto que você tem que mostrar isso numa 
                    //            // messagebox.. fica meio complicado
                    //    }
            }

            return win;
        }

        public void PlayerDie()
        {
            playing = false;
        }

        public bool IsAlive()
        {
            return playing;
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