namespace AutoTapTap1
{
    partial class LevelSelectForm
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
            this.EasyButton = new System.Windows.Forms.Button();
            this.MediumButton = new System.Windows.Forms.Button();
            this.HardButton = new System.Windows.Forms.Button();
            this.ExtremeButton = new System.Windows.Forms.Button();
            this.AdvancedModeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EasyButton
            // 
            this.EasyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(79)))));
            this.EasyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.EasyButton.Location = new System.Drawing.Point(198, 62);
            this.EasyButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(183, 156);
            this.EasyButton.TabIndex = 0;
            this.EasyButton.Text = "EASY";
            this.EasyButton.UseVisualStyleBackColor = false;
            this.EasyButton.Click += new System.EventHandler(this.EasyButton_Click);
            // 
            // MediumButton
            // 
            this.MediumButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(79)))));
            this.MediumButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.MediumButton.Location = new System.Drawing.Point(428, 62);
            this.MediumButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MediumButton.Name = "MediumButton";
            this.MediumButton.Size = new System.Drawing.Size(178, 156);
            this.MediumButton.TabIndex = 1;
            this.MediumButton.Text = "MEDIUM";
            this.MediumButton.UseVisualStyleBackColor = false;
            this.MediumButton.Click += new System.EventHandler(this.MediumButton_Click);
            // 
            // HardButton
            // 
            this.HardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(79)))));
            this.HardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.HardButton.Location = new System.Drawing.Point(198, 243);
            this.HardButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(183, 152);
            this.HardButton.TabIndex = 2;
            this.HardButton.Text = "HARD";
            this.HardButton.UseVisualStyleBackColor = false;
            this.HardButton.Click += new System.EventHandler(this.HardButton_Click);
            // 
            // ExtremeButton
            // 
            this.ExtremeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(79)))));
            this.ExtremeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ExtremeButton.Location = new System.Drawing.Point(428, 243);
            this.ExtremeButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ExtremeButton.Name = "ExtremeButton";
            this.ExtremeButton.Size = new System.Drawing.Size(178, 152);
            this.ExtremeButton.TabIndex = 3;
            this.ExtremeButton.Text = "EXTREME";
            this.ExtremeButton.UseVisualStyleBackColor = false;
            this.ExtremeButton.Click += new System.EventHandler(this.ExtremeButton_Click);
            // 
            // AdvancedModeButton
            // 
            this.AdvancedModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AdvancedModeButton.Font = new System.Drawing.Font("Motorwerk", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdvancedModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(50)))));
            this.AdvancedModeButton.Location = new System.Drawing.Point(198, 407);
            this.AdvancedModeButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AdvancedModeButton.Name = "AdvancedModeButton";
            this.AdvancedModeButton.Size = new System.Drawing.Size(408, 124);
            this.AdvancedModeButton.TabIndex = 4;
            this.AdvancedModeButton.Text = "H4><0R |\\/|0D3";
            this.AdvancedModeButton.UseVisualStyleBackColor = false;
            this.AdvancedModeButton.Click += new System.EventHandler(this.AdvancedModeButton_Click);
            // 
            // LevelSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.AdvancedModeButton);
            this.Controls.Add(this.ExtremeButton);
            this.Controls.Add(this.HardButton);
            this.Controls.Add(this.MediumButton);
            this.Controls.Add(this.EasyButton);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "LevelSelectForm";
            this.Text = "Any song rhythm tap game! (Level select)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EasyButton;
        private System.Windows.Forms.Button MediumButton;
        private System.Windows.Forms.Button HardButton;
        private System.Windows.Forms.Button ExtremeButton;
        private System.Windows.Forms.Button AdvancedModeButton;
    }
}