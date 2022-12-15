using System.Diagnostics;

namespace Reversiii
{
    public partial class Form1 : Form
    {
        int n;

        int[,] bord;
        
        public Form1()
        {
            InitializeComponent();
            n = 6;
            bord = new int[6, 6] {
                {0,0,0,0,0,0},
                {0,0,0,0,0,0},
                {0,0,1,2,0,0},
                {0,0,2,1,0,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0}
            };

        }
    }
}