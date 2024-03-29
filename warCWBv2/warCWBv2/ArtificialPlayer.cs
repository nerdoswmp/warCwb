﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static warCWBv2.GameScreen;
using static warCWBv2.MapForm;

namespace warCWBv2
{
    public class ArtificialPlayer : Player
    {
        private int objective;
        private Zona[] objzonas;
        TurnAction action;
        Team team;
        bool playing = true;
        MapForm mp;
        MapManager mm;
        Territorio temp = new Territorio();
        Territorio[] moveto = new Territorio[2];

        public ArtificialPlayer(Team team, int obj, MapForm mp) : base(team, obj)
        {
            this.team = team;
            this.objective = obj;


            switch (obj)
            {
                case 0:
                    //"Conquistar CIC, PORTÃO e CAJURU"
                    objzonas = GetZonas().Where(x => x.GetName() == "CIC" || x.GetName() == "PORTÃO"
                    || x.GetName() == "CAJURU").ToArray();
                    break;
                case 1:
                    //"Conquistar PINHEIRINHO, BAIRRO NOVO e BOA VISTA"
                    objzonas = GetZonas().Where(x => x.GetName() == "PINHEIRINHO" || x.GetName() == "BAIRRO NOVO"
                    || x.GetName() == "BOA VISTA").ToArray();
                    break;
                case 2:
                    //"Conquistar PINHEIRINHO, BOQUEIRÃO e SANTA FELICIDADE"
                    objzonas = GetZonas().Where(x => x.GetName() == "PINHEIRINHO" || x.GetName() == "BOQUEIRÃO"
                    || x.GetName() == "SANTA FELICIDADE").ToArray();
                    break;
                case 3:
                    //"Conquistar MATRIZ e PORTÃO"
                    objzonas = GetZonas().Where(x => x.GetName() == "MATRIZ" || x.GetName() == "PORTÃO").ToArray();
                    break;
                case 4:
                    //"Conquistar CIC, BAIRRO NOVO e BOA VISTA"
                    objzonas = GetZonas().Where(x => x.GetName() == "CIC" || x.GetName() == "BAIRRO NOVO"
                    || x.GetName() == "BOA VISTA").ToArray();
                    break;
                case 5:
                    //"Conquistar BOQUEIRÃO, CAJURU e SANTA FELICIDADE"
                    objzonas = GetZonas().Where(x => x.GetName() == "BOQUEIRÃO" || x.GetName() == "CAJURU"
                    || x.GetName() == "SANTA FELICIDADE").ToArray();
                    break;
                case 6:
                    //"Conquistar CIC, MATRIZ e BOQUEIRÃO"
                    objzonas = GetZonas().Where(x => x.GetName() == "CIC" || x.GetName() == "MATRIZ"
                    || x.GetName() == "BOQUEIRÃO").ToArray();
                    break;
                case 99:
                    //"tudo nosso nada deles"
                    objzonas = GetZonas().Where(x => x.GetName() == "CIC" || x.GetName() == "BAIRRO NOVO"
                    || x.GetName() == "BOA VISTA" || x.GetName() == "PINNHEIRINHO" || x.GetName() == "PORTÃO"
                    || x.GetName() == "SANTA FELICIDADE" || x.GetName() == "BOQUEIRÃO" || x.GetName() == "CAJURU"
                    || x.GetName() == "MATRIZ").ToArray();
                    break;
            }
        }

        public Zona[] GetObjZonas()
        {
            return objzonas;
        }

        public void SetEssentials(MapManager map, MapForm form)
        {
            this.mm = map;
            this.mp = form;
        }
        public Point Play(int act)
        {
            bool hasterr = GetZonas().Any();
            Random rand = new Random();
            if (GetCurrentPlayer() == this)
            {
                Point place;
                if (team.GetTerritorios().Count() > 0 )
                {
                    place = team.GetTerritorios()[rand.Next(0, team.GetTerritorios().Count())].GetCoord();
                }
                else
                {
                    place = new Point();
                }
                switch (act)
                {
                    case 0:

                        if (team.GetTerritorios().Contains(moveto[1]) && moveto[1] != null)
                        {
                            return moveto[0].GetCoord();
                        }

                        for (int i = 0; i < objzonas.Length; i++)
                        {
                            bool haster = objzonas[i].GetTerritorios().Any(t => team.GetTerritorios().Contains(t));
                            bool haszona = team.GetZonas().Contains(objzonas[i]);
                            if (haster && !haszona)
                            {
                               foreach(var t in objzonas[i].GetTerritorios())
                                {
                                    var decide = rand.Next(0, 101);
                                    Territorio insert;
                                    if (decide >= 50)
                                    {
                                        insert = team.GetTerritorios().Where(x => x.GetName() == t.GetName() && x.GetTroops() > 1)
                                            .OrderBy(a => rand.Next()).FirstOrDefault();
                                    }
                                    else
                                    {
                                        insert = team.GetTerritorios().Where(x => x.GetName() == t.GetName() && x.GetTroops() > 1)
                                            .OrderBy(a => rand.Next()).LastOrDefault();
                                    }
                                    if (insert != null && !insert.GetAdjacente().All(x => team.GetTerritorios().Contains(x))){
                                        place = insert.GetCoord();
                                        temp = insert;
                                        Console.WriteLine($"not random in theory: {place}");
                                        return place;
                                    }
                                }
                            }
                            else if (haster && haszona)
                            {
                                foreach (var t in objzonas[i].GetTerritorios())
                                {
                                    var decide = rand.Next(0,101);
                                    Territorio insert;
                                    if (decide >= 50)
                                    {
                                        insert = team.GetTerritorios().Where(x => x.GetName() == t.GetName() && x.GetTroops() > 1)
                                            .OrderBy(a => rand.Next()).FirstOrDefault();
                                    }
                                    else
                                    {
                                        insert = team.GetTerritorios().Where(x => x.GetName() == t.GetName() && x.GetTroops() > 1)
                                            .OrderBy(a => rand.Next()).LastOrDefault();
                                    }
                                    
                                    if (insert != null && !insert.GetAdjacente().All(x => team.GetTerritorios().Contains(x)))
                                    {
                                        place = insert.GetCoord();
                                        temp = insert;
                                        Console.WriteLine($"not random in theory: {place}");
                                        return place;
                                    }
                                }
                            }
                        }
                        return place;
                    case 1:
                        Territorio[] adjacentes = temp.GetAdjacente().Where(x => x.GetTroops() <= temp.GetTroops())
                            .OrderBy(a => rand.Next()).ToArray();
                        //Console.WriteLine("###########################################################################");
                        //foreach (var adjacente in adjacentes)
                        //{
                        //    Console.WriteLine(adjacente.GetName());
                        //}


                        for (int i = 0; i < objzonas.Length; i++)
                        {
                            //Console.WriteLine($"{objzonas[i].GetName()} ###################################");
                            //foreach (var z in objzonas[i].GetTerritorios())
                            //{
                            //    Console.WriteLine(z.GetName());
                            //}

                            for (int j = 0; j < adjacentes.Length; j++)
                            {
                                bool haster = objzonas[i].GetTerritorios().Contains(adjacentes[j]);

                                if (haster && team.GetTerritorios().Contains(adjacentes[j]) == false && temp.GetTroops() > 1)
                                {
                                    Console.WriteLine($"purposefully attacked {adjacentes[j].GetCoord()}");
                                    
                                    return adjacentes[j].GetCoord();
                                }
                            }

                            for (int j = 0; j < adjacentes.Length; j++)
                            {
                                if (team.GetTerritorios().Contains(adjacentes[j]) == false && temp.GetTroops() > 1)
                                {
                                    moveto[0] = temp;
                                    moveto[1] = adjacentes[j];
                                    Console.WriteLine($"attacked {adjacentes[j].GetCoord()}");
                                    return adjacentes[j].GetCoord();
                                }
                            }
                        }
                        moveto[0] = null;
                        moveto[1] = null;
                        break;
                    case 2:
                        adjacentes = temp.GetAdjacente().Where(x => x.GetTroops() <= temp.GetTroops())
                            .OrderBy(a => rand.Next()).ToArray();
                        //Console.WriteLine("###########################################################################");
                        //foreach (var adjacente in adjacentes)
                        //{
                        //    Console.WriteLine(adjacente.GetName());
                        //}
                        if (team.GetTerritorios().Contains(moveto[1]) && moveto[1] != null)
                        {
                            return moveto[1].GetCoord();
                        }
                        else
                        {
                            for (int i = 0; i < objzonas.Length; i++)
                            {
                                //Console.WriteLine($"{objzonas[i].GetName()} ###################################");
                                //foreach (var z in objzonas[i].GetTerritorios())
                                //{
                                //    Console.WriteLine(z.GetName());
                                //}

                                for (int j = 0; j < adjacentes.Length; j++)
                                {
                                    bool haster = objzonas[i].GetTerritorios().Contains(adjacentes[j]);

                                    if (haster && team.GetTerritorios().Contains(adjacentes[j]) == true && temp.GetTroops() > 1)
                                    {
                                        Console.WriteLine($"attacked {adjacentes[j].GetCoord()}");
                                        return adjacentes[j].GetCoord();
                                    }
                                }

                                for (int j = 0; j < adjacentes.Length; j++)
                                {
                                    if (team.GetTerritorios().Contains(adjacentes[j]) == true && temp.GetTroops() > 1)
                                    {
                                        Console.WriteLine($"attacked {adjacentes[j].GetCoord()}");
                                        return adjacentes[j].GetCoord();
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        return place;
                }
            }
            return new Point();
        }
    }


}
