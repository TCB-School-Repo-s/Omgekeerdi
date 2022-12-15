using System.Diagnostics;

namespace Reversiii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedValue = "6x6";
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
            spelbord1.resetGame();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }
    }
}