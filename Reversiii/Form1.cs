using System.Diagnostics;

namespace Reversiii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 6;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "6x6":
                    n = 6;
                    break;
                case "8x8":
                    n = 8;
                    break;
                case "10x10":
                    n = 10;
                    break;
                case "12x12":
                    n = 12;
                    break;
                case "16x16":
                    n = 16;
                    break;
            }
            spelbord1.BoardSize = n;
            spelbord1.SwitchPlayers(2, 1);
            spelbord1.resetGame();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }

        private void playerTwoScore_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            e.Graphics.FillEllipse(new SolidBrush(spelbord1.PlayerTwoColor), 0, 0, box.Width, box.Height);
        }

        private void playerOneScore_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            e.Graphics.FillEllipse(new SolidBrush(spelbord1.PlayerOneColor), 0, 0, box.Width, box.Height);
        }

        private void spelbord1_Paint(object sender, PaintEventArgs e)
        {
            Spelbord bord = (Spelbord)sender;

            playerOneLabel.Text = bord.getPlayerOneScore().ToString();
            playerTwoLabel.Text = bord.getPlayerTwoScore().ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

    }
}