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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw 6 x 6 grid using panel1 size
            int x = panel1.Width / n;
            int y = panel1.Height / n;
            Pen pen = new Pen(Color.Black, 2.5f);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * x, j * y, x, y);
                }
            }
        }
    }
}