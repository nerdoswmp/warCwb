using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static warCWBv2.MapForm;

namespace warCWBv2
{
    public partial class GameScreen : Form
    {
        static int current = 0;
        int turn = 0;
        public static Team[] teams;
        static Player[] players;
        SoundPlayer player = new SoundPlayer(Properties.Resources.trilha);
        SoundPlayer familia = new SoundPlayer(Properties.Resources.A_Família_Folhas_voltou___);
        MapForm mapForm;
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        bool hardmode = false;

        public GameScreen(int amount)
        {
            teams = CreateTeams(amount);
            players = CreatePlayers(amount);
            if (amount == 10)
            {
                hardmode = true;
            }
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            mapForm = new MapForm() { TopLevel = false, TopMost = true };

            this.panel1.Controls.Add(mapForm);
            mapForm.Show();

            label3.Text = $"Turno {turn++}";

            bt_Skip.Enabled = false;

            //ArtificialPlayer a1 = new ArtificialPlayer(teams[0], 0, mapForm);
            //string test = "";
            //foreach( var o in a1.GetObjZonas())
            //{
            //    test = test + " | " + o.GetName();
            //}
            //MessageBox.Show(test);
            
        }

        public MapForm GetMP()
        {
            return mapForm;
        }

        public void UpdateLabels()
        {
            label1.Text = $"Player: {GetCurrentPlayer().GetTeam().GetColor().Name}";
            switch ((int)GetCurrentPlayer().GetAction())
            {
                case 0:
                    label2.Text = $"Colocar Tropas ({GetCurrentPlayer().GetTeam().GetTroopsToInsert()})";
                    break;
                case 1:
                    if (hardmode)
                    {
                        label2.Text = "Pavimentar";
                    }
                    else
                    {
                        label2.Text = "Atacar";
                    }
                    break;
                case 2:
                    label2.Text = "Mover Tropas";
                    break;
                case 3:
                    label2.Text = "Aguardando";
                    break;
            }
            this.BackColor = GetCurrentPlayer().GetTeam().GetColor();
            Console.WriteLine(GetCurrentPlayer().GetTeam().GetColor());
        }

        public void UpdateTurn()
        {
            label3.Text = $"Turno {turn++}";
        }
        public static Player GetCurrentPlayer()
        {
            return players[current];
        }

        public static void NextPlayer()
        {
            Console.WriteLine($"{teams.Length} | {current}");
            if (current >= teams.Length-1)
            {
                current = 0;
                foreach(var p in players)
                {
                    p.ResetAct();
                }   
            }
            else
            {
                current++;
            }

            if (GetCurrentPlayer().GetTeam().GetTerritorios().Count() == 0)
            {
                //MessageBox.Show("perdeu");
                GetCurrentPlayer().PlayerDie();
                NextPlayer();
            }
        }
        public static Team[] CreateTeams(int amount)
        {
            Team team1 = new Team(Color.Red);
            Team team2 = new Team(Color.Yellow);
            Team team3 = new Team(Color.Green);
            Team team4 = new Team(Color.Blue);
            Team team5 = new Team(Color.Cyan);
            Team team6 = new Team(Color.Purple);
            Team team7 = new Team(Color.Magenta);
            Team team8 = new Team(Color.Gray);
            Team team9 = new Team(Color.Teal);
            Team team10 = new Team(Color.Fuchsia);
            Team team11 = new Team(Color.Silver);
            Team team12 = new Team(Color.Lime);
            Team team13 = new Team(Color.Navy);


            //Team team1 = new Team(ColorTranslator.FromHtml("#0EAD69"));
            //Team team2 = new Team(ColorTranslator.FromHtml("#3BCEAC"));
            //Team team3 = new Team(ColorTranslator.FromHtml("#FFD23F"));
            //Team team4 = new Team(ColorTranslator.FromHtml("#EE4266"));

            switch (amount)
            {
                case 2:
                    return new Team[] { team1, team2 };
                case 3:
                    return new Team[] { team1, team2, team3 };
                case 4:
                    return new Team[] { team1, team2, team3, team4 };
                case 5:
                    return new Team[] { team1, team2};
                case 6:
                    return new Team[] { team1, team2, team3 };
                case 7:
                    return new Team[] { team1, team2, team3, team4 };
                case 8:
                    return new Team[] { team1, team2, team3, team4 };
                case 9:
                    return new Team[] { team1, team2, team3, team4 };
                case 10:
                    return new Team[] { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12, team13 };
                default:
                    return new Team[] { team1, team2, team3, team4 };
            }
        }

        public Player[] CreatePlayers(int amount)
        {
            
            Player p1;
            Player p2;
            Player p3;
            Player p4;
            Player p5;
            Player p6;
            Player p7;
            Player p8;
            Player p9;
            Player p10;
            Player p11;
            Player p12;
            Player p13;


            switch (amount)
            {
                case 2:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    return new Player[] { p1, p2 };
                case 3:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    p3 = new Player(teams[2], rand.Next(0, 5));
                    return new Player[] { p1, p2, p3 };
                case 4:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    p3 = new Player(teams[2], rand.Next(0, 5));
                    p4 = new Player(teams[3], rand.Next(0, 5));
                    return new Player[] { p1, p2, p3, p4 };
                case 5:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new ArtificialPlayer(teams[1], rand.Next(0, 5), mapForm);
                    return new Player[] { p1, p2 };
                case 6:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new ArtificialPlayer(teams[1], rand.Next(0, 5), mapForm);
                    p3 = new ArtificialPlayer(teams[2], rand.Next(0, 5), mapForm);
                    return new Player[] { p1, p2, p3 };
                case 7:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new ArtificialPlayer(teams[1], rand.Next(0, 5), mapForm);
                    p3 = new ArtificialPlayer(teams[2], rand.Next(0, 5), mapForm);
                    p4 = new ArtificialPlayer(teams[3], rand.Next(0, 5), mapForm);
                    return new Player[] { p1, p2, p3, p4 };
                case 8:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    p3 = new ArtificialPlayer(teams[2], rand.Next(0, 5), mapForm);
                    p4 = new ArtificialPlayer(teams[3], rand.Next(0, 5), mapForm);
                    return new Player[] { p1, p2, p3, p4 };
                case 9:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    p3 = new Player(teams[2], rand.Next(0, 5));
                    p4 = new ArtificialPlayer(teams[3], rand.Next(0, 5), mapForm);
                    return new Player[] { p1, p2, p3, p4 };
                case 10:
                    p1 = new Player(teams[0], 5);
                    p2 = new ArtificialPlayer(teams[1], 5, mapForm);
                    p3 = new ArtificialPlayer(teams[2], 5, mapForm);
                    p4 = new ArtificialPlayer(teams[3], 5, mapForm);
                    p5 = new ArtificialPlayer(teams[4], 5, mapForm);
                    p6 = new ArtificialPlayer(teams[5], 5, mapForm);
                    p7 = new ArtificialPlayer(teams[6], 5, mapForm);
                    p8 = new ArtificialPlayer(teams[7], 5, mapForm);
                    p9 = new ArtificialPlayer(teams[8], 5, mapForm);
                    p10 = new ArtificialPlayer(teams[9], 5, mapForm);
                    p11 = new ArtificialPlayer(teams[10], 5, mapForm);
                    p12 = new ArtificialPlayer(teams[11], 5, mapForm);
                    p13 = new ArtificialPlayer(teams[12], 5, mapForm);
                    return new Player[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13 };
                default:
                    p1 = new Player(teams[0], rand.Next(0, 5));
                    p2 = new Player(teams[1], rand.Next(0, 5));
                    p3 = new Player(teams[2], rand.Next(0, 5));
                    p4 = new Player(teams[3], rand.Next(0, 5));
                    return new Player[] { p1, p2, p3, p4 };
            }
        }


        public static Team[] GetAllTeams()
        {
            return teams;
        }

        public static Player[] GetAllPlayers()
        {
            return players;
        }

        public void EnableSkip()
        {
            bt_Skip.Enabled = true;
        }

        public void DisableSkip()
        {
            bt_Skip.Enabled = false;
        }

        private void bt_Skip_Click_1(object sender, EventArgs e)
        {
            GetCurrentPlayer().NextAct();
            if((int)GetCurrentPlayer().GetAction() == 3)
            {
                NextPlayer();
            }
            if (GetCurrentPlayer().GetTeam().GetTerritorios().Count() == 0)
            {
                //MessageBox.Show("perdeu");
                GetCurrentPlayer().PlayerDie();
                NextPlayer();
            }
            UpdateLabels();
            UpdateTurn();
            mapForm.ResetVars();
        }

        private void bt_Objective_Click(object sender, EventArgs e)
        {
            string text = "";
            switch (GetCurrentPlayer().GetObjective())
            {
                case 0:
                    text = "Conquistar CIC, PORTÃO e CAJURU";
                    break;
                case 1:
                    text = "Conquistar PINHEIRINHO, BAIRRO NOVO e BOA VISTA";
                    break;
                case 2:
                    text = "Conquistar PINHEIRINHO, BOQUEIRÃO e SANTA FELICIDADE";
                    break;
                case 3:
                    text = "Conquistar MATRIZ e PORTÃO";
                    break;
                case 4:
                    text = "Conquistar CIC, BAIRRO NOVO e BOA VISTA";
                    break;
                case 5:
                    text = "ASFALTAR CURITIBA (TODOS TERRITÓRIOS)";
                    break;
            }

            MessageBox.Show(text);
            //familia.Play();
            //player.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se vira nerdola");
        }

        private void picCards_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O sistema de trocas ainda não foi implementado");
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            Mapa form = new Mapa();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            familia.Play();
        }



        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            if (openForms.Where(x => x.Name == "Form1").Last().Visible == false)
            {
                Environment.Exit(0);
            }

        }

        private void settingsPic_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.Show();
        }
    }
}
