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
                    label2.Text = "Colocar Tropas";
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

        //public static void RemovePlayer()
        //{
        //    players[]
        //}

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
            Player p1 = new Player(teams[0], 0);
            Player p2 = new Player(teams[1], 0);
            Player p3 = new Player(teams[2], 0);
            Player p4 = new Player(teams[3], 0);

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
            UpdateLabels();
            UpdateTurn();
        }

        private void bt_Objective_Click(object sender, EventArgs e)
        {
            vitoria form = new vitoria();
            form.Show();
            this.Hide();
            //string text = "";
            //switch (GetCurrentPlayer().GetObjective())
            //{
            //    case 0:
            //        text = "Conquistar CIC e PORTÃO";
            //        break;
            //    case 1:
            //        text = "Existir";
            //        break;
            //}

            //MessageBox.Show(text);
            //familia.Play();
            //player.Play();
        }
    }
}
