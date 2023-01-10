using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using NAudio;
using NAudio.Wave;

namespace Reversiii
{
    public partial class Form1 : Form
    {
        Form2 nameForm = new Form2();
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        Song[] playlist;
        Song[] songs =
        {
            new Song(Path.Combine(Application.StartupPath, "Resources\\1.wav"), "Style", "Taylor Swift"),
            new Song(Path.Combine(Application.StartupPath, "Resources\\2.wav"), "Anti-hero", "Taylor Swift"),
            new Song(Path.Combine(Application.StartupPath, "Resources\\3.wav"), "Just the Way You Are", "Bruno Mars"),
            new Song(Path.Combine(Application.StartupPath, "Resources\\4.wav"), "Rain On Me", "Lady Gaga ft. Ariana Grande"),
            new Song(Path.Combine(Application.StartupPath, "Resources\\5.wav"), "I Want To Break Free", "Queen"),
            new Song(Path.Combine(Application.StartupPath, "Resources\\6.wav"), "Bohemian Rhapsody", "Queen"),
        };
        int songIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 6;
            
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Board size selection box has an invalid parameter!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                    case "32x32":
                        n = 32;
                        break;
                    case "64x64":
                        n = 64;
                        break;
                    case "128x128":
                        n = 128;
                        break;
                    case "256x256":
                        n = 256;
                        break;
                }
                spelbord1.BoardSize = n;
                spelbord1.SwitchPlayers(2, 1);
                spelbord1.resetGame();
                nameForm.Show();
            }
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
            
            if(bord.getPlayingPlayer() == 1)
            {
                playerOneLabel.Text = $"{bord.getPlayerOneScore()} stones - {Form2.name1}'s turn";
                playerTwoLabel.Text = $"{bord.getPlayerTwoScore()} stones";
            }
            else
            {
                playerOneLabel.Text = $"{bord.getPlayerOneScore()} stones";
                playerTwoLabel.Text = $"{bord.getPlayerTwoScore()} stones - {Form2.name2}'s turn";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nameForm.SetForm(this);
            nameForm.TopMost = true;
            nameForm.Show();
            nameForm.Focus();
            comboBox1.SelectedIndex = 0;
            Random rnd = new Random();

            outputDevice = new WaveOutEvent();
            playlist = songs.OrderBy(x => rnd.Next()).ToArray();
            string musicPath = playlist[songIndex].GetPath();
            audioFile = new AudioFileReader(musicPath);
            outputDevice.Init(audioFile);
            outputDevice.Volume = (float)trackBar1.Value / 100;
            outputDevice.PlaybackStopped += PlaybackStopped;
            playingSongLabel.Text = $"Now playing: {playlist[songIndex].GetTitle()} by {playlist[songIndex].GetAuthor()}";
            outputDevice.Play();
        }
        
        public void PlaybackStopped(object sender, StoppedEventArgs args)
        {

            if(outputDevice.PlaybackState != PlaybackState.Paused)
            {
                songIndex++;
                if (songIndex > playlist.Length-1)
                {
                    songIndex = 0;
                    Random rnd = new Random();
                    playlist = songs.OrderBy(x => rnd.Next()).ToArray();
                    string nextSong = playlist[songIndex].GetPath();
                    outputDevice.Init(new AudioFileReader(nextSong));
                    playingSongLabel.Text = $"Now playing: {playlist[songIndex].GetTitle()} by {playlist[songIndex].GetAuthor()}";
                    outputDevice.Play();
                }
                else
                {
                    string nextSong = playlist[songIndex].GetPath();
                    outputDevice.Init(new AudioFileReader(nextSong));
                    playingSongLabel.Text = $"Now playing: {playlist[songIndex].GetTitle()} by {playlist[songIndex].GetAuthor()}";
                    outputDevice.Play();
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            spelbord1.ShowHelp = true;
            spelbord1.Invalidate();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            outputDevice.Volume = (float)trackBar1.Value / 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputDevice.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Pause();
                playingSongLabel.Text = "Currently not playing music";
            }
            else
            {
                outputDevice.Play();
                playingSongLabel.Text = $"Now playing: {playlist[songIndex].GetTitle()} by {playlist[songIndex].GetAuthor()}";
            }
        }

        private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "https://en.wikipedia.org/wiki/Reversi";
            process.Start();
        }
    }

    internal class Song
    {
        private string path;
        private string title;
        private string author;

        public Song(string path, string title, string author)
        {
            this.path = path;
            this.title = title;
            this.author = author;
        }

        public string GetPath()
        {
            return path;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

    }
}