namespace Reversiii
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playingSongLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerTwoScore = new System.Windows.Forms.PictureBox();
            this.playerOneScore = new System.Windows.Forms.PictureBox();
            this.spelbord1 = new Reversiii.Spelbord();
            this.spelBordMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x10ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerTwoScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneScore)).BeginInit();
            this.spelBordMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.playingSongLabel);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(590, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(313, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Settings";
            // 
            // playingSongLabel
            // 
            this.playingSongLabel.AutoSize = true;
            this.playingSongLabel.Location = new System.Drawing.Point(6, 124);
            this.playingSongLabel.Name = "playingSongLabel";
            this.playingSongLabel.Size = new System.Drawing.Size(38, 15);
            this.playingSongLabel.TabIndex = 8;
            this.playingSongLabel.Text = "label3";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Pause Music";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Skip current song";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Music Volume";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(87, 50);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(220, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 15;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Board Size";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "6x6",
            "8x8",
            "10x10",
            "12x12",
            "16x16",
            "32x32",
            "64x64",
            "128x128",
            "256x256"});
            this.comboBox1.Location = new System.Drawing.Point(87, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 182);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hint";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 156);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(303, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.playerTwoLabel);
            this.groupBox2.Controls.Add(this.playerOneLabel);
            this.groupBox2.Controls.Add(this.playerTwoScore);
            this.groupBox2.Controls.Add(this.playerOneScore);
            this.groupBox2.Location = new System.Drawing.Point(590, 247);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(313, 341);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Statistics";
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.AutoSize = true;
            this.playerTwoLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerTwoLabel.Location = new System.Drawing.Point(87, 234);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(63, 25);
            this.playerTwoLabel.TabIndex = 3;
            this.playerTwoLabel.Text = "label3";
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.AutoSize = true;
            this.playerOneLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerOneLabel.Location = new System.Drawing.Point(87, 77);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(63, 25);
            this.playerOneLabel.TabIndex = 2;
            this.playerOneLabel.Text = "label2";
            // 
            // playerTwoScore
            // 
            this.playerTwoScore.Location = new System.Drawing.Point(6, 210);
            this.playerTwoScore.Name = "playerTwoScore";
            this.playerTwoScore.Size = new System.Drawing.Size(75, 77);
            this.playerTwoScore.TabIndex = 1;
            this.playerTwoScore.TabStop = false;
            this.playerTwoScore.Paint += new System.Windows.Forms.PaintEventHandler(this.playerTwoScore_Paint);
            // 
            // playerOneScore
            // 
            this.playerOneScore.Location = new System.Drawing.Point(6, 52);
            this.playerOneScore.Name = "playerOneScore";
            this.playerOneScore.Size = new System.Drawing.Size(75, 77);
            this.playerOneScore.TabIndex = 0;
            this.playerOneScore.TabStop = false;
            this.playerOneScore.Paint += new System.Windows.Forms.PaintEventHandler(this.playerOneScore_Paint);
            // 
            // spelbord1
            // 
            this.spelbord1.BackColor = System.Drawing.Color.SteelBlue;
            this.spelbord1.BoardSize = 8;
            this.spelbord1.ContextMenuStrip = this.spelBordMenu;
            this.spelbord1.Location = new System.Drawing.Point(12, 27);
            this.spelbord1.Name = "spelbord1";
            this.spelbord1.PlayerOneColor = System.Drawing.Color.Black;
            this.spelbord1.PlayerTwoColor = System.Drawing.Color.White;
            this.spelbord1.ShowHelp = false;
            this.spelbord1.Size = new System.Drawing.Size(570, 570);
            this.spelbord1.TabIndex = 3;
            this.spelbord1.Paint += new System.Windows.Forms.PaintEventHandler(this.spelbord1_Paint);
            // 
            // spelBordMenu
            // 
            this.spelBordMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.spelBordMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.spelBordMenu.Name = "spelBordMenu";
            this.spelBordMenu.Size = new System.Drawing.Size(133, 26);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x6ToolStripMenuItem,
            this.x8ToolStripMenuItem,
            this.x10ToolStripMenuItem,
            this.x10ToolStripMenuItem1,
            this.x14ToolStripMenuItem,
            this.x16ToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // x6ToolStripMenuItem
            // 
            this.x6ToolStripMenuItem.Name = "x6ToolStripMenuItem";
            this.x6ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x6ToolStripMenuItem.Text = "6x6";
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x8ToolStripMenuItem.Text = "8x8";
            // 
            // x10ToolStripMenuItem
            // 
            this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
            this.x10ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x10ToolStripMenuItem.Text = "10x10";
            // 
            // x10ToolStripMenuItem1
            // 
            this.x10ToolStripMenuItem1.Name = "x10ToolStripMenuItem1";
            this.x10ToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.x10ToolStripMenuItem1.Text = "12x10";
            // 
            // x14ToolStripMenuItem
            // 
            this.x14ToolStripMenuItem.Name = "x14ToolStripMenuItem";
            this.x14ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x14ToolStripMenuItem.Text = "14x14";
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x16ToolStripMenuItem.Text = "16x16";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameRulesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gameRulesToolStripMenuItem
            // 
            this.gameRulesToolStripMenuItem.Name = "gameRulesToolStripMenuItem";
            this.gameRulesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gameRulesToolStripMenuItem.Text = "Game rules";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 610);
            this.Controls.Add(this.spelbord1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Omgekeerdi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerTwoScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerOneScore)).EndInit();
            this.spelBordMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox1;
        private Spelbord board;
        private Button button1;
        private Button button2;
        private GroupBox groupBox2;
        private Spelbord spelbord1;
        private Label label1;
        private ComboBox comboBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem gameRulesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private PictureBox playerTwoScore;
        private PictureBox playerOneScore;
        private Label playerTwoLabel;
        private Label playerOneLabel;
        private ContextMenuStrip spelBordMenu;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem x6ToolStripMenuItem;
        private ToolStripMenuItem x8ToolStripMenuItem;
        private ToolStripMenuItem x10ToolStripMenuItem;
        private ToolStripMenuItem x10ToolStripMenuItem1;
        private ToolStripMenuItem x14ToolStripMenuItem;
        private ToolStripMenuItem x16ToolStripMenuItem;
        private Label label2;
        private TrackBar trackBar1;
        private Button button4;
        private Button button3;
        private Label playingSongLabel;
    }
}