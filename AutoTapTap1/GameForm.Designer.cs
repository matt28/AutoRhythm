namespace AutoTapTap1
{
    partial class GameForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScoreDisplay = new System.Windows.Forms.Label();
            this.MultiplierDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.streakdisplay = new System.Windows.Forms.Label();
            this.AccuracyDisplay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BytesVis = new System.Windows.Forms.Label();
            this.ComboView = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(45)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 562);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(50, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "/////////////////////////////////////////////////////////////////////////////////" +
    "";
            // 
            // ScoreDisplay
            // 
            this.ScoreDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.ScoreDisplay.Font = new System.Drawing.Font("Matura MT Script Capitals", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ScoreDisplay.Location = new System.Drawing.Point(330, 383);
            this.ScoreDisplay.Name = "ScoreDisplay";
            this.ScoreDisplay.Size = new System.Drawing.Size(119, 36);
            this.ScoreDisplay.TabIndex = 13;
            this.ScoreDisplay.Text = "0";
            // 
            // MultiplierDisplay
            // 
            this.MultiplierDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.MultiplierDisplay.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplierDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MultiplierDisplay.Location = new System.Drawing.Point(455, 403);
            this.MultiplierDisplay.Name = "MultiplierDisplay";
            this.MultiplierDisplay.Size = new System.Drawing.Size(35, 16);
            this.MultiplierDisplay.TabIndex = 14;
            this.MultiplierDisplay.Text = "1";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.label3.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(487, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "x";
            // 
            // streakdisplay
            // 
            this.streakdisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.streakdisplay.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streakdisplay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.streakdisplay.Location = new System.Drawing.Point(381, 434);
            this.streakdisplay.Name = "streakdisplay";
            this.streakdisplay.Size = new System.Drawing.Size(68, 23);
            this.streakdisplay.TabIndex = 16;
            this.streakdisplay.Text = "0";
            // 
            // AccuracyDisplay
            // 
            this.AccuracyDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.AccuracyDisplay.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccuracyDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.AccuracyDisplay.Location = new System.Drawing.Point(327, 457);
            this.AccuracyDisplay.Name = "AccuracyDisplay";
            this.AccuracyDisplay.Size = new System.Drawing.Size(122, 43);
            this.AccuracyDisplay.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(160, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 450);
            this.label4.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(240, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 450);
            this.label5.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(327, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Streak:";
            // 
            // BytesVis
            // 
            this.BytesVis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(15)))));
            this.BytesVis.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BytesVis.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BytesVis.Location = new System.Drawing.Point(327, 419);
            this.BytesVis.Name = "BytesVis";
            this.BytesVis.Size = new System.Drawing.Size(122, 15);
            this.BytesVis.TabIndex = 21;
            this.BytesVis.Text = "TimeLabel";
            // 
            // ComboView
            // 
            this.ComboView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComboView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ComboView.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboView.Location = new System.Drawing.Point(134, 354);
            this.ComboView.Name = "ComboView";
            this.ComboView.Size = new System.Drawing.Size(140, 31);
            this.ComboView.TabIndex = 22;
            this.ComboView.Text = "HitComboLabel";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ComboView);
            this.Controls.Add(this.BytesVis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AccuracyDisplay);
            this.Controls.Add(this.streakdisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MultiplierDisplay);
            this.Controls.Add(this.ScoreDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GameForm";
            this.Text = "Any song rhythm tap game!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameFormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KP);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ScoreDisplay;
        private System.Windows.Forms.Label MultiplierDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label streakdisplay;
        private System.Windows.Forms.Label AccuracyDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BytesVis;
        private System.Windows.Forms.Label ComboView;
    }
}

