using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AmazingTICTACTOE.GUIView;

namespace AmazingTICTACTOE
{
    class Utilities
    {
        public static void Blink(Clientdata CD)
        {
            Random rand = CD.Random;
            CD.Label.ForeColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }
    }
}
