namespace Reversiii
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.invoer1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.invoer2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // invoer1
            // 
            this.invoer1.Location = new System.Drawing.Point(50, 167);
            this.invoer1.Name = "invoer1";
            this.invoer1.Size = new System.Drawing.Size(270, 27);
            this.invoer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "What is your name, player 1?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Let\'s play!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "What is your name, player 2?";
            // 
            // invoer2
            // 
            this.invoer2.Location = new System.Drawing.Point(437, 167);
            this.invoer2.Name = "invoer2";
            this.invoer2.Size = new System.Drawing.Size(270, 27);
            this.invoer2.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 394);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invoer2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Welcome to omgekeerdi!";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox invoer1;
        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox invoer2;
    }
}