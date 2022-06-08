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
        public static Team[] teams = CreateTeams();
        static Player[] players = CreatePlayers();
        static int current = 0;
        int turn = 0;
        SoundPlayer player = new SoundPlayer(Properties.Resources.trilha);
        SoundPlayer familia = new SoundPlayer(Properties.Resources.A_Família_Folhas_voltou___);

        public GameScreen()
        {
            InitializeComponent();
        }
        private void GameScreen_Load(object sender, EventArgs e)
        {
            MapForm mapForm = new MapForm() { TopLevel = false, TopMost = true };

            this.panel1.Controls.Add(mapForm);
            mapForm.Show();

            label3.Text = $"Turno {turn++}";

            bt_Skip.Enabled = false;
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
                    label2.Text = "Atacar";
                    break;
                case 2:
                    label2.Text = "Mover Tropas";
                    break;
                case 3:
                    label2.Text = "Aguardando";
                    break;
            }
            this.BackColor = GetCurrentPlayer().GetTeam().GetColor();
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
            if (current >= 3)
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
                MessageBox.Show("perdeu");
                NextPlayer();
            }
        }
        public static Team[] CreateTeams()
        {
            Team team1 = new Team(Color.Red);
            Team team2 = new Team(Color.Yellow);
            Team team3 = new Team(Color.Green);
            Team team4 = new Team(Color.Blue);

            return new Team[] { team1, team2, team3, team4 };
        }

        public static Player[] CreatePlayers()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Player p1 = new Player(teams[0], rand.Next(0, 5));
            Player p2 = new Player(teams[1], rand.Next(0, 5));
            Player p3 = new Player(teams[2], rand.Next(0, 5));
            Player p4 = new Player(teams[3], rand.Next(0, 5));

            return new Player[] { p1, p2, p3, p4 };
        }


        public static Team[] GetAllTeams()
        {
            return teams;
        }

        public void EnableSkip()
        {
            bt_Skip.Enabled = true;
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
                MessageBox.Show("perdeu");
                NextPlayer();
            }
            UpdateLabels();
            UpdateTurn();
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
    }
}
