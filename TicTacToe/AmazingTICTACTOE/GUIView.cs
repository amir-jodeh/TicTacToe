using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazingTICTACTOE
{
    public partial class GUIView : Form
    {
        public Model model;
        Random rand = new Random();
        public int player = 2;
        public int turns = 0;
        public int xwin = 0;
        public int owin = 0;
        public int draws = 0;

        public GUIView()
        {
            InitializeComponent();
            model = new Model(this);
        }

        public class Clientdata
        {
            public Timer Timer { get; set; }
            public Random Random { get; set; }
            public Label Label { get; set; }
        }
        
        public Clientdata CD;

        private void Form1_Load(object sender, EventArgs e)
        {
            CD = new Clientdata
            {
                Timer = timer1,
                Random = rand,
                Label = label1
            };
            MessageBox.Show("Welcome to AJ's Amazing Creation of work");
            XWin.Text = "X: " + xwin;
            OWin.Text = "O: " + owin;
            Draws.Text = "Draws: " + draws;
            timer1.Interval = 300;
            timer1.Start();
        }

        //Playboard buttons
        public void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text=="")
            {
                if (player % 2 == 0)
                {
                    button.ForeColor = Color.Red;
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.ForeColor = Color.Blue;
                    button.Text = "0";
                    player++;
                    turns++;
                }
                if (model.CheckDraw()==true)
                {
                    MessageBox.Show("Tie Game!");
                    draws++;
                    model.NewGame();
                }

                if (model.CheckWinner()==true)
                {
                    if (button.Text == "X")
                    {
                        MessageBox.Show("X Won!", "Winner Winner!");
                        xwin++;
                        model.NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O Won!", "Winner Winner!");
                        owin++;
                        model.NewGame();
                    }
                }
            }
        }

        private void EButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            xwin = owin = draws = 0;
            model.NewGame();
            MessageBox.Show("All points have been reset", "New Game!");
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            t1.Text = t2.Text = t3.Text = m1.Text = m2.Text = m3.Text = b1.Text = b2.Text = b3.Text = "";
            player = 2;
            turns = 0;
            MessageBox.Show("Progress Reset");
        }

        private void madeby(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Utilities.Blink(CD);
        }

    }
}
