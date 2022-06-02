using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static warCWBv2.MapForm;

namespace warCWBv2
{
    public partial class GameScreen : Form
    {
        public static Team[] teams = CreateTeams();
        static Player[] players = CreatePlayers();
        static int current = 0;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            MapForm mapForm = new MapForm() { TopLevel = false, TopMost = true };

            this.panel1.Controls.Add(mapForm);
            mapForm.Show();

            
        }

        public void UpdateLabels()
        {
            label1.Text = GetCurrentPlayer().GetTeam().GetColor().Name;
            switch ((int)GetCurrentPlayer().GetAction())
            {
                case 0:
                    label2.Text = "Place Troops";
                    break;
                case 1:
                    label2.Text = "Attack";
                    break;
                case 2:
                    label2.Text = "Move Troops";
                    break;
                case 3:
                    label2.Text = "Waiting";
                    break;
            }
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
            Player p1 = new Player(teams[0]);
            Player p2 = new Player(teams[1]);
            Player p3 = new Player(teams[2]);
            Player p4 = new Player(teams[3]);

            return new Player[] { p1, p2, p3, p4 };
        }


        public static Team[] GetAllTeams()
        {
            return teams;
        }
    }
}
