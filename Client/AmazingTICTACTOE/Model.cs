using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazingTICTACTOE
{
    public class Model
    {
        GUIView view;
        public Model(GUIView form)
        {
            view = form;
        }

        public bool CheckWinner()
        {
            if ((view.t1.Text == view.t2.Text) && (view.t2.Text == view.t3.Text) && view.t1.Text != ""
                || ((view.m1.Text == view.m2.Text) && (view.m2.Text == view.m3.Text) && view.m1.Text != "")
                || ((view.b1.Text == view.b2.Text) && (view.b2.Text == view.b3.Text) && view.b1.Text != "")
                || ((view.t1.Text == view.m1.Text) && (view.m1.Text == view.b1.Text) && view.t1.Text != "")
                || ((view.t2.Text == view.m2.Text) && (view.m2.Text == view.b2.Text) && view.t2.Text != "")
                || ((view.t3.Text == view.m3.Text) && (view.m3.Text == view.b3.Text) && view.t3.Text != "")
                || ((view.t1.Text == view.m2.Text) && (view.m2.Text == view.b3.Text) && view.t1.Text != "")
                || ((view.t3.Text == view.m2.Text) && (view.m2.Text == view.b1.Text) && view.t3.Text != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDraw()
        {
            if ((view.turns == 9) && CheckWinner() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NewGame()
        {
            view.player = 2;
            view.turns = 0;
            view.t1.Text = view.t2.Text = view.t3.Text = view.m1.Text = view.m2.Text = view.m3.Text = view.b1.Text = view.b2.Text = view.b3.Text = "";
            view.XWin.Text = view.player1 + view.xwin;
            view.OWin.Text = view.player2 + view.owin;
            view.Draws.Text = "Draws: " + view.draws;
        }

        public void ParseButtonPress(Button button)
        {


        }
    }
}

