using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using static warCWBv2.GameScreen;

namespace warCWBv2
{
    public partial class MapForm : Form
    {
        static List<Territorio> territorioList = new List<Territorio>();
        static string selected = "";
        static string tmp = "";
        static int step = 0;
        Label[] labels = new Label[38];
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        Graphics g;
        List<Zona> zonas = GetZonas();
        GameScreen gs = PreOff.gs;
        MapManager mm = new MapManager();
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            gs.UpdateLabels();
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            pb.Refresh();

            CreateTerritorio();
            Timer tm = new Timer();
            tm.Interval = 60;

            

            for (int i = 0; i < GetTerritorios().Count(); i++)
            {
                labels[i] = new Label();
                labels[i].Name = GetTerritorios()[i].GetName();
                labels[i].Text = GetTerritorios()[i].GetTroops().ToString();
                labels[i].Location = GetTerritorios()[i].GetCoord();
                labels[i].AutoSize = true;
                labels[i].Font = new Font("Calibri", 10);
                labels[i].ForeColor = Color.White;
                labels[i].BackColor = Color.Black;
                this.pb.Controls.Add(labels[i]);
                labels[i].Show();
            }

            tm.Tick += delegate
            {
                pb.Image = mm.Map;
            };
            tm.Start();

            mm.Initialize();
            mm.ClearRandom(territorioList);
            mm.Close();

            int turn0 = 0;
            pb.MouseDown += (o, mea) =>
            {
                //Console.WriteLine((int)GetCurrentPlayer().GetAction());
                //Console.WriteLine(turn0);

                if (turn0 >= 4)
                {
                    gs.EnableSkip();
                    switch ((int)GetCurrentPlayer().GetAction())
                    {
                        case 0:
                            InsertTurn(mm, mea);       
                            break;
                        case 1:
                            AttackTurn(mm, mea);
                            break;
                        case 2:
                            MoveTurn(mm, mea);
                            break;
                        case 3:
                            NextPlayer();
                            gs.UpdateLabels();
                            break;
                    };

                    foreach (var z in zonas)
                    {
                        GetCurrentPlayer().GetTeam().InsertZona(z);
                    }
                    GetCurrentPlayer().GetTeam().RefreshToInsert();

                    foreach (var y in GetCurrentPlayer().GetTeam().GetZonas())
                    {
                        Console.Write($"{y.GetName()} | ");
                    }

                    if (GetCurrentPlayer().ValidateObjective())
                    {
                        MessageBox.Show($"Player {GetCurrentPlayer().GetTeam().GetColor().Name} wins");
                        vitoria form = new vitoria();
                        form.Show();
                        this.Hide();
                    }

                }
                else
                {
                    if (InsertTurn(mm, mea))
                    {
                        NextPlayer();
                        turn0++;
                    }
                    gs.UpdateLabels();
                }
            };
        }

        public bool InsertTurn(MapManager mm, MouseEventArgs mea)
        {
            mm.Initialize();
            string tname = mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), mea.Location, 2);
            if (tname != null)
            {
                var terr = FindTerritorio(tname);
                terr.AddTroops(GetCurrentPlayer().GetTeam().GetTroopsToInsert());
                UpdateTroopLabels();
                mm.Close();
                GetCurrentPlayer().NextAct();
                tmp = tname;
                gs.UpdateLabels();
                gs.UpdateTurn();
                return true;
            }
            else
            {
                //Console.WriteLine("nope");
                mm.Close();
                gs.UpdateLabels();

            }
            tmp = tname;       
            return false;
        }
        public void AttackTurn(MapManager mm, MouseEventArgs mea)
        {
            //Console.WriteLine(mea.Location.ToString());
            if (step == 0)
            {
                mm.Initialize();
                string tname = mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), mea.Location, 2);
                if (tname != null && FindTerritorio(tname).GetTroops() > 1)
                {
                    selected = mm.Clear(Color.Orange, mea.Location, 1);
                    //Console.WriteLine("step 1");
                    step = 1;
                }
                else
                {
                    //Console.WriteLine("nope");
                }
                mm.Close();
                tmp = tname;
            }
            else
            {
                mm.Initialize();
                string name = mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), mea.Location, 1);
                mm.Close();
                int found = -1;
                if (name != null)
                {
                    var territorio = FindTerritorio(name);
                    mm.Initialize();
                    mm.Clear(GetAllTeams().Where(x => x.GetTerritorios().Contains(territorio))
                        .Single().GetColor(), territorio.GetCoord(), 1);
                    mm.Close();
                    if (FindTerritorio(tmp).GetAdjacente().Contains(territorio))
                    {
                        if (rand.Next(1, 7) > 3)
                        {
                            territorio.RemoveTroops(2);
                            if (territorio.GetTroops() <= 0)
                            {
                                territorio.SetTroop(0);
                            }
                            FindTerritorio(tmp).RemoveTroops(1);

                            UpdateTroopLabels();
                        }
                        else
                        {
                            FindTerritorio(tmp).RemoveTroops(1);
                            UpdateTroopLabels();
                        }
                        if (territorio.GetTroops() <= 0)
                        {
                            mm.Initialize();
                            territorio.SetTroop(1);
                            FindTerritorio(tmp).RemoveTroops(1);
                            if (FindTerritorio(tmp).GetTroops() <= 0)
                            {
                                FindTerritorio(tmp).SetTroop(1);
                            }
                            UpdateTroopLabels();
                            GetAllTeams().Where(x => x.GetTerritorios().Contains(territorio))
                            .Single().RemoveTerr(territorio);

                            GetCurrentPlayer().GetTeam().InsertTerr(territorio);

                            mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), territorio.GetCoord(), 1);
                            //GetCurrentPlayer().NextAct();
                            gs.UpdateLabels();
                            gs.UpdateTurn();
                            step = 0;

                            var selectedobj = FindTerritorio(selected);
                            mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), selectedobj.GetCoord(), 1);
                            mm.Close();
                        }
                        else if (FindTerritorio(tmp).GetTroops() <= 1)
                        {
                            FindTerritorio(tmp).SetTroop(1);
                            //GetCurrentPlayer().NextAct();
                            gs.UpdateLabels();
                            gs.UpdateTurn();

                            step = 0;
                            mm.Initialize();
                            var selectedobj = FindTerritorio(selected);
                            mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), selectedobj.GetCoord(), 1);
                            mm.Close();
                        }
                        found = 1;
                    }

                    if (found != 1)
                    {
                        mm.Initialize();
                        mm.Clear(GetAllTeams().Where(x => x.GetTerritorios().Contains(territorio))
                                .Single().GetColor(), mea.Location, 1);
                        gs.UpdateLabels();
                        mm.Close();
                    }
                }
            }
            gs.UpdateLabels();
        }
        public void MoveTurn(MapManager mm, MouseEventArgs mea)
        {
            //Console.WriteLine(step);
            if (step == 0)
            {
                mm.Initialize();
                string tname = mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), mea.Location, 2);
                if (tname != null && FindTerritorio(tname).GetTroops() > 1)
                {
                    selected = mm.Clear(Color.Orange, mea.Location, 1);
                    //Console.WriteLine("step 1");
                    step = 1;
                }
                else
                {
                    //Console.WriteLine("nope");
                }
                mm.Close();
            }
            else
            {
                if (selected != null)
                {
                    mm.Initialize();
                    string moveto = mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), mea.Location, 2);
                    mm.Close();
                    //Console.WriteLine("step 2");
                    if (moveto != null)
                    {
                        //Console.WriteLine("step 3");
                        var movetoobj = FindTerritorio(moveto);
                        foreach (var t in FindTerritorio(selected).GetAdjacente())
                        {
                            if (t == movetoobj)
                            {
                                mm.Initialize();
                                var selectedobj = FindTerritorio(selected);
                                movetoobj.AddTroops(selectedobj.GetTroops() / 2);
                                selectedobj.RemoveTroops(selectedobj.GetTroops() / 2);
                                UpdateTroopLabels();
                                mm.Clear(GetCurrentPlayer().GetTeam().GetColor(), selectedobj.GetCoord(), 1);
                                mm.Close();
                                GetCurrentPlayer().NextAct();
                                step = 0;
                                NextPlayer();
                                gs.UpdateTurn();
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("fuck");
                    }
                }
                else
                {
                    //Console.WriteLine("nope");
                }
            }
            gs.UpdateLabels();
        }
        public static List<Zona> GetZonas()
        {
            List<Zona> list = new List<Zona>();
            Zona cic = new Zona(3, "CIC");
            Zona portao = new Zona(6, "PORTÃO");
            Zona bairronovo = new Zona(3, "BAIRRO NOVO");
            Zona pinheirinho = new Zona(3, "PINHEIRINHO");
            Zona stafelicidade = new Zona(4, "SANTA FELICIDADE");
            Zona boqueirao = new Zona(3, "BOQUEIRÃO");
            Zona cajuru = new Zona(3, "CAJURU");
            Zona matriz = new Zona(10, "MATRIZ");
            Zona boavista = new Zona(4, "BOA VISTA");

            list.AddRange(new[] { cic, portao, bairronovo, pinheirinho, stafelicidade, boqueirao, cajuru, matriz, boavista });

            return list;
        }

        public void CreateTerritorio()
        {
            List<Territorio> list = new List<Territorio>();
            
            // trigger warning: murilo moment
            // YANDERE DEV MOMENT assassinado Moll
            list.Add(new Territorio(false, new Point(233, 263), zonas[1], "água verde"));
            zonas[1].InsertTerr(list[0]);
            list.Add(new Territorio(false, new Point(336, 457), zonas[5], "alto boqueirão"));
            zonas[5].InsertTerr(list[1]);
            list.Add(new Territorio(false, new Point(320, 182), zonas[7], "alto da xv"));
            zonas[7].InsertTerr(list[2]);
            list.Add(new Territorio(false, new Point(217, 220), zonas[7], "batel"));
            zonas[7].InsertTerr(list[3]);
            list.Add(new Territorio(false, new Point(293, 105), zonas[8], "boa vista"));
            zonas[8].InsertTerr(list[4]);
            list.Add(new Territorio(true, new Point(336, 375), zonas[5], "boqueirão"));
            zonas[5].InsertTerr(list[5]);
            list.Add(new Territorio(false, new Point(87, 116), zonas[4], "butiatuvinha"));
            zonas[4].InsertTerr(list[6]);
            list.Add(new Territorio(true, new Point(308, 149), zonas[7], "cabral"));
            zonas[7].InsertTerr(list[7]);
            list.Add(new Territorio(false, new Point(283, 24), zonas[8], "cachoeira"));
            zonas[8].InsertTerr(list[8]);
            list.Add(new Territorio(false, new Point(395, 260), zonas[6], "cajuru"));
            zonas[6].InsertTerr(list[9]);
            list.Add(new Territorio(false, new Point(149, 247), zonas[4], "campo comprido"));
            zonas[4].InsertTerr(list[10]);
            list.Add(new Territorio(false, new Point(142, 617), zonas[3], "campo de santana"));
            zonas[3].InsertTerr(list[11]);
            list.Add(new Territorio(true, new Point(265, 209), zonas[7], "centro"));
            zonas[7].InsertTerr(list[12]);
            list.Add(new Territorio(false, new Point(258, 155), zonas[7], "centro cívico"));
            zonas[7].InsertTerr(list[13]);
            list.Add(new Territorio(true, new Point(132, 383), zonas[0], "cic"));
            zonas[0].InsertTerr(list[14]);
            list.Add(new Territorio(false, new Point(151, 318), zonas[1], "fazendinha"));
            zonas[1].InsertTerr(list[15]);
            list.Add(new Territorio(false, new Point(299, 541), zonas[2], "ganchinho"));
            zonas[2].InsertTerr(list[16]);
            list.Add(new Territorio(false, new Point(316, 222), zonas[7], "jardim botânico"));
            zonas[7].InsertTerr(list[17]);
            list.Add(new Territorio(false, new Point(334, 271), zonas[5], "jardim das américas"));
            zonas[6].InsertTerr(list[18]);
            list.Add(new Territorio(false, new Point(227, 186), zonas[7], "mercês"));
            zonas[7].InsertTerr(list[19]);
            list.Add(new Territorio(false, new Point(211, 341), zonas[1], "novo mundo"));
            zonas[1].InsertTerr(list[20]);
            list.Add(new Territorio(false, new Point(74, 191), zonas[4], "orleans"));
            zonas[4].InsertTerr(list[21]);
            list.Add(new Territorio(false, new Point(268, 299), zonas[1], "parolin"));
            zonas[1].InsertTerr(list[22]);
            list.Add(new Territorio(false, new Point(46, 307), zonas[0], "passaúna"));
            zonas[0].InsertTerr(list[23]);
            list.Add(new Territorio(true, new Point(218, 97), zonas[8], "pilarzinho"));
            zonas[8].InsertTerr(list[24]);
            list.Add(new Territorio(false, new Point(217, 415), zonas[3], "pinheirinho"));
            zonas[3].InsertTerr(list[25]);
            list.Add(new Territorio(true, new Point(198, 302), zonas[1], "portão"));
            zonas[1].InsertTerr(list[26]);
            list.Add(new Territorio(false, new Point(297, 248), zonas[7], "rebouças"));
            zonas[7].InsertTerr(list[27]);
            list.Add(new Territorio(false, new Point(363, 68), zonas[8], "santa cândida"));
            zonas[8].InsertTerr(list[28]);
            list.Add(new Territorio(true, new Point(143, 157), zonas[4], "santa felicidade"));
            zonas[4].InsertTerr(list[29]);
            list.Add(new Territorio(false, new Point(70, 385), zonas[0], "são miguel"));
            zonas[0].InsertTerr(list[30]);
            list.Add(new Territorio(true, new Point(280, 471), zonas[2], "sitio cercado"));
            zonas[2].InsertTerr(list[31]);
            list.Add(new Territorio(true, new Point(379, 158), zonas[8], "tarumã"));
            zonas[8].InsertTerr(list[32]);
            list.Add(new Territorio(false, new Point(151, 520), zonas[3], "tatuquara"));
            zonas[3].InsertTerr(list[33]);
            list.Add(new Territorio(false, new Point(383, 335), zonas[6], "uberaba"));
            zonas[6].InsertTerr(list[34]);
            list.Add(new Territorio(false, new Point(232, 564), zonas[2], "umbará"));
            zonas[2].InsertTerr(list[35]);
            list.Add(new Territorio(false, new Point(208, 151), zonas[4], "vista alegre"));
            zonas[4].InsertTerr(list[36]);
            list.Add(new Territorio(false, new Point(272, 386), zonas[5], "xaxim"));
            zonas[5].InsertTerr(list[37]);

            territorioList = list;
            InsertAdjacent();
        }
        public Territorio FindTerritorio(string name)
        {
            return territorioList.Where(t => t.GetName() == name).Single();
        }
        public void InsertAdjacent()
        {
            // AGUA VERDE
            FindTerritorio("água verde").InsertTerr(new Territorio[]{ FindTerritorio("batel"), FindTerritorio("portão"),
                 FindTerritorio("parolin"), FindTerritorio("fazendinha"), FindTerritorio("campo comprido"),
                 FindTerritorio("centro"), FindTerritorio("rebouças")});
            // ALTO BOQUEIRÃO
            FindTerritorio("alto boqueirão").InsertTerr(new Territorio[]{ FindTerritorio("boqueirão"), FindTerritorio("xaxim"),
                 FindTerritorio("sitio cercado"), FindTerritorio("ganchinho")});
            // ALTO DA XV
            FindTerritorio("alto da xv").InsertTerr(new Territorio[]{ FindTerritorio("jardim botânico"), FindTerritorio("centro"),
                 FindTerritorio("tarumã"), FindTerritorio("cabral")});
            // BATEL
            FindTerritorio("batel").InsertTerr(new Territorio[]{ FindTerritorio("água verde"), FindTerritorio("centro"),
                 FindTerritorio("campo comprido"), FindTerritorio("santa felicidade"), FindTerritorio("mercês")});
            // BOA VISTA
            FindTerritorio("boa vista").InsertTerr(new Territorio[]{ FindTerritorio("cabral"), FindTerritorio("santa cândida"),
                 FindTerritorio("cachoeira"), FindTerritorio("centro cívico"), FindTerritorio("pilarzinho"), FindTerritorio("tarumã")});
            // BOQUEIRÃO
            FindTerritorio("boqueirão").InsertTerr(new Territorio[]{ FindTerritorio("alto boqueirão"), FindTerritorio("xaxim"),
                 FindTerritorio("uberaba")});
            // BUTIATUVINHA
            FindTerritorio("butiatuvinha").InsertTerr(new Territorio[]{ FindTerritorio("santa felicidade"), FindTerritorio("orleans")});
            // CABRAL
            FindTerritorio("cabral").InsertTerr(new Territorio[]{ FindTerritorio("boa vista"), FindTerritorio("centro cívico"),
                 FindTerritorio("tarumã"), FindTerritorio("alto da xv"), FindTerritorio("centro")});
            // CACHOEIRA
            FindTerritorio("cachoeira").InsertTerr(new Territorio[]{ FindTerritorio("pilarzinho"), FindTerritorio("boa vista"),
                 FindTerritorio("santa cândida")});
            // CAJURU
            FindTerritorio("cajuru").InsertTerr(new Territorio[]{ FindTerritorio("uberaba"), FindTerritorio("jardim das américas"),
                 FindTerritorio("jardim botânico"), FindTerritorio("tarumã")});
            // CAMPO COMPRIDO
            FindTerritorio("campo comprido").InsertTerr(new Territorio[]{ FindTerritorio("batel"), FindTerritorio("água verde"),
                 FindTerritorio("santa felicidade"), FindTerritorio("orleans"), FindTerritorio("cic"),
                 FindTerritorio("fazendinha")});
            // CAMPO DE SANTANA
            FindTerritorio("campo de santana").InsertTerr(new Territorio[]{ FindTerritorio("tatuquara"), FindTerritorio("umbará")});
            // CENTRO
            FindTerritorio("centro").InsertTerr(new Territorio[]{ FindTerritorio("rebouças"), FindTerritorio("jardim botânico"),
                 FindTerritorio("batel"), FindTerritorio("água verde"), FindTerritorio("mercês"), FindTerritorio("centro cívico"),
                 FindTerritorio("alto da xv"), FindTerritorio("cabral")});
            // CENTRO CIVICO
            FindTerritorio("centro cívico").InsertTerr(new Territorio[]{ FindTerritorio("cabral"), FindTerritorio("centro"),
                 FindTerritorio("vista alegre"), FindTerritorio("pilarzinho"), FindTerritorio("boa vista"), FindTerritorio("mercês")});
            // CIC
            FindTerritorio("cic").InsertTerr(new Territorio[]{ FindTerritorio("tatuquara"), FindTerritorio("pinheirinho"),
                 FindTerritorio("são miguel"), FindTerritorio("passaúna"), FindTerritorio("fazendinha"), FindTerritorio("novo mundo"),
                 FindTerritorio("campo comprido"), FindTerritorio("orleans")});
            // FAZENDINHA
            FindTerritorio("fazendinha").InsertTerr(new Territorio[]{ FindTerritorio("cic"), FindTerritorio("portão"),
                 FindTerritorio("campo comprido"), FindTerritorio("novo mundo"), FindTerritorio("água verde")});
            // GANCHINHO
            FindTerritorio("ganchinho").InsertTerr(new Territorio[]{ FindTerritorio("umbará"), FindTerritorio("sitio cercado"),
                 FindTerritorio("alto boqueirão")});
            // JARDIM BOTÂNICO
            FindTerritorio("jardim botânico").InsertTerr(new Territorio[]{ FindTerritorio("centro"), FindTerritorio("tarumã"),
                 FindTerritorio("jardim das américas"), FindTerritorio("rebouças"), FindTerritorio("alto da xv"),  FindTerritorio("cajuru")});
            // JARDIM DAS AMÉRICAS
            FindTerritorio("jardim das américas").InsertTerr(new Territorio[]{ FindTerritorio("jardim botânico"), FindTerritorio("uberaba"),
                FindTerritorio("xaxim"), FindTerritorio("rebouças"),  FindTerritorio("cajuru")});
            // MERCÊS
            FindTerritorio("mercês").InsertTerr(new Territorio[]{ FindTerritorio("vista alegre"), FindTerritorio("centro cívico"),
                 FindTerritorio("centro"), FindTerritorio("batel"), FindTerritorio("santa felicidade")});
            // NOVO MUNDO
            FindTerritorio("novo mundo").InsertTerr(new Territorio[]{ FindTerritorio("cic"), FindTerritorio("fazendinha"),
                 FindTerritorio("portão"), FindTerritorio("parolin"), FindTerritorio("xaxim"),  FindTerritorio("pinheirinho")});
            // ORLEANS
            FindTerritorio("orleans").InsertTerr(new Territorio[]{ FindTerritorio("butiatuvinha"), FindTerritorio("santa felicidade"),
                 FindTerritorio("campo comprido"), FindTerritorio("cic"), FindTerritorio("passaúna")});
            // PAROLIN
            FindTerritorio("parolin").InsertTerr(new Territorio[]{ FindTerritorio("água verde"), FindTerritorio("portão"),
                 FindTerritorio("novo mundo"), FindTerritorio("xaxim"), FindTerritorio("rebouças")});
            // PASSAÚNA
            FindTerritorio("passaúna").InsertTerr(new Territorio[]{ FindTerritorio("são miguel"), FindTerritorio("cic"),
                 FindTerritorio("orleans")});
            // PILARZINHO
            FindTerritorio("pilarzinho").InsertTerr(new Territorio[]{ FindTerritorio("vista alegre"), FindTerritorio("boa vista"),
                 FindTerritorio("cachoeira"), FindTerritorio("centro cívico")});
            // PINHEIRINHO
            FindTerritorio("pinheirinho").InsertTerr(new Territorio[]{ FindTerritorio("cic"), FindTerritorio("xaxim"),
                 FindTerritorio("novo mundo"), FindTerritorio("tatuquara"), FindTerritorio("sitio cercado")});
            // PORTÃO
            FindTerritorio("portão").InsertTerr(new Territorio[]{ FindTerritorio("fazendinha"), FindTerritorio("novo mundo"),
                 FindTerritorio("água verde"), FindTerritorio("parolin")});
            // REBOUÇAS
            FindTerritorio("rebouças").InsertTerr(new Territorio[]{ FindTerritorio("centro"), FindTerritorio("água verde"),
                 FindTerritorio("parolin"), FindTerritorio("xaxim"), FindTerritorio("jardim das américas"), FindTerritorio("jardim botânico")});
            // SANTA CÂNDIDA
            FindTerritorio("santa cândida").InsertTerr(new Territorio[]{ FindTerritorio("boa vista"), FindTerritorio("cachoeira"),
                 FindTerritorio("tarumã")});
            // SANTA FELICIDADE 
            FindTerritorio("santa felicidade").InsertTerr(new Territorio[]{ FindTerritorio("orleans"), FindTerritorio("vista alegre"),
                 FindTerritorio("campo comprido"), FindTerritorio("butiatuvinha"), FindTerritorio("mercês"), FindTerritorio("batel")});
            // SÃO MIGUEL
            FindTerritorio("são miguel").InsertTerr(new Territorio[]{ FindTerritorio("passaúna"), FindTerritorio("cic"), FindTerritorio("tatuquara")});
            // SÍTIO CERCADO
            FindTerritorio("sitio cercado").InsertTerr(new Territorio[]{ FindTerritorio("pinheirinho"), FindTerritorio("xaxim"),
                 FindTerritorio("alto boqueirão"), FindTerritorio("ganchinho"), FindTerritorio("umbará"), FindTerritorio("tatuquara")});
            // TARUMÃ
            FindTerritorio("tarumã").InsertTerr(new Territorio[]{ FindTerritorio("alto da xv"), FindTerritorio("jardim botânico"),
                 FindTerritorio("cajuru"), FindTerritorio("cabral"), FindTerritorio("boa vista"), FindTerritorio("santa cândida")});
            // TATUQUARA
            FindTerritorio("tatuquara").InsertTerr(new Territorio[]{ FindTerritorio("cic"), FindTerritorio("pinheirinho"),
                 FindTerritorio("sitio cercado"), FindTerritorio("umbará"), FindTerritorio("campo de santana"), FindTerritorio("são miguel")});
            // UBERABA
            FindTerritorio("uberaba").InsertTerr(new Territorio[]{ FindTerritorio("boqueirão"), FindTerritorio("xaxim"),
                 FindTerritorio("jardim das américas"), FindTerritorio("cajuru")});
            // UMBARÁ
            FindTerritorio("umbará").InsertTerr(new Territorio[]{ FindTerritorio("ganchinho"), FindTerritorio("tatuquara"),
                 FindTerritorio("campo de santana"), FindTerritorio("sitio cercado")});
            // VISTA ALEGRE
            FindTerritorio("vista alegre").InsertTerr(new Territorio[]{ FindTerritorio("pilarzinho"), FindTerritorio("centro cívico"),
                 FindTerritorio("mercês"), FindTerritorio("santa felicidade")});
            // XAXIM
            FindTerritorio("xaxim").InsertTerr(new Territorio[]{ FindTerritorio("boqueirão"), FindTerritorio("alto boqueirão"),
                 FindTerritorio("novo mundo"), FindTerritorio("pinheirinho"), FindTerritorio("sitio cercado"), FindTerritorio("parolin"), FindTerritorio("rebouças"),
                FindTerritorio("jardim das américas"), FindTerritorio("uberaba")});
        }

        public static Point[] GetTerritorioCoords()
        {
            Point[] points = new Point[38];
            for (int i = 0; i<38; i++)
            {
                points[i] = territorioList[i].GetCoord();
            }
            return points;
        }

        public static List<Territorio> GetTerritorios()
        {
            return territorioList;
        }

        public void UpdateTroopLabels()
        {
            foreach (var l in labels)
            {
                l.Text = FindTerritorio(l.Name).GetTroops().ToString();
            }
        }

        public void ResetVars()
        {
            step = 0;
            selected = "";
            tmp = "";
            mm.Initialize();
            mm.ReClear();
            mm.Close();
        }
    }

}
