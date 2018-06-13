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
        Color color = Color.Snow;
        public int player = 2;
        public int turns = 0;
        public int xwin = 0;
        public int owin = 0;
        public string player1 = "X ";
        public string player2 = "O ";
        Color x_colour = Color.Red;
        Color o_colour = Color.Blue;
        public int draws = 0;
        private Graphics g;
        // use private

        public GUIView()
        {
            InitializeComponent();
            model = new Model(this);
        }

        public class ClientData
        {
            public Timer Timer { get; set; }
            public Random Random { get; set; }
            public Label Label { get; set; }
        }
        
        public ClientData CD;

        private void Form1_Load(object sender, EventArgs e)
        {
            CD = new ClientData
            {
                Timer = timer1,
                Random = rand,
                Label = label1
            };
            MessageBox.Show("Welcome to AJ's Amazing Creation of work");
            XWin.Text = player1 + xwin;
            OWin.Text = player2 + owin;
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
                    //change to int
                    button.ForeColor = x_colour;
                    button.Text = player1;
                    player++;
                    turns++;
                }
                else
                {
                    button.ForeColor = o_colour;
                    button.Text = player2;
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
                    if (button.Text == player1)
                    {
                        MessageBox.Show(player1 + "Won!", "Winner Winner!");
                        xwin++;
                        model.NewGame();
                    }
                    else
                    {
                        MessageBox.Show(player2 + "Won!", "Winner Winner!");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Utilities.Blink(CD);
        }

        private void GUIView_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //g.DrawString(new Pen(new SolidBrush(Color.Red)), 0 ,0, 34, 34);
            g.DrawString("Creator:", new Font("Arial", 16), new SolidBrush(Color.Snow), Width * 0.75f, Height * 0.75f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (true)
            {

            }

            if (textBox1.Text.Substring(0) == " ")
            {
                //MessageBox.Show("Invalid Text Length");
                textBox1.Text = "Player1";
            }

            else
            {
                firstplayer.Text = textBox1.Text;
            }
        }


    }
}
