namespace AutoTapTap1
{
    partial class AdvancedLevelSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.avcvalIN = new System.Windows.Forms.TextBox();
            this.AvcNoteMakeLimitIN = new System.Windows.Forms.TextBox();
            this.MillSecWaitTimeIN = new System.Windows.Forms.TextBox();
            this.FmsTriggerValueIN = new System.Windows.Forms.TextBox();
            this.notemakeConstantIN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smoothness ( 3=hardly, 40=a lot):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(569, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time needed to wait before new note (milliseconds):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "rebound needed(0=none,100=a lot):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(591, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "note making sensitivity(0.01=very sensitive 0.5=not):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(536, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minumum averaged amplitude to make note(2 or 3):";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(492, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 76);
            this.button1.TabIndex = 10;
            this.button1.Text = "GO!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // avcvalIN
            // 
            this.avcvalIN.BackColor = System.Drawing.Color.Black;
            this.avcvalIN.ForeColor = System.Drawing.Color.Lime;
            this.avcvalIN.Location = new System.Drawing.Point(622, 9);
            this.avcvalIN.Name = "avcvalIN";
            this.avcvalIN.Size = new System.Drawing.Size(100, 23);
            this.avcvalIN.TabIndex = 11;
            this.avcvalIN.Text = "10";
            // 
            // AvcNoteMakeLimitIN
            // 
            this.AvcNoteMakeLimitIN.BackColor = System.Drawing.Color.Black;
            this.AvcNoteMakeLimitIN.ForeColor = System.Drawing.Color.Lime;
            this.AvcNoteMakeLimitIN.Location = new System.Drawing.Point(622, 116);
            this.AvcNoteMakeLimitIN.Name = "AvcNoteMakeLimitIN";
            this.AvcNoteMakeLimitIN.Size = new System.Drawing.Size(100, 23);
            this.AvcNoteMakeLimitIN.TabIndex = 12;
            this.AvcNoteMakeLimitIN.Text = "3";
            // 
            // MillSecWaitTimeIN
            // 
            this.MillSecWaitTimeIN.BackColor = System.Drawing.Color.Black;
            this.MillSecWaitTimeIN.ForeColor = System.Drawing.Color.Lime;
            this.MillSecWaitTimeIN.Location = new System.Drawing.Point(622, 89);
            this.MillSecWaitTimeIN.Name = "MillSecWaitTimeIN";
            this.MillSecWaitTimeIN.Size = new System.Drawing.Size(100, 23);
            this.MillSecWaitTimeIN.TabIndex = 13;
            this.MillSecWaitTimeIN.Text = "71";
            // 
            // FmsTriggerValueIN
            // 
            this.FmsTriggerValueIN.BackColor = System.Drawing.Color.Black;
            this.FmsTriggerValueIN.ForeColor = System.Drawing.Color.Lime;
            this.FmsTriggerValueIN.Location = new System.Drawing.Point(622, 62);
            this.FmsTriggerValueIN.Name = "FmsTriggerValueIN";
            this.FmsTriggerValueIN.Size = new System.Drawing.Size(100, 23);
            this.FmsTriggerValueIN.TabIndex = 14;
            this.FmsTriggerValueIN.Text = "20";
            // 
            // notemakeConstantIN
            // 
            this.notemakeConstantIN.BackColor = System.Drawing.Color.Black;
            this.notemakeConstantIN.ForeColor = System.Drawing.Color.Lime;
            this.notemakeConstantIN.Location = new System.Drawing.Point(622, 34);
            this.notemakeConstantIN.Name = "notemakeConstantIN";
            this.notemakeConstantIN.Size = new System.Drawing.Size(100, 23);
            this.notemakeConstantIN.TabIndex = 15;
            this.notemakeConstantIN.Text = "0.08";
            // 
            // AdvancedLevelSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(784, 322);
            this.Controls.Add(this.notemakeConstantIN);
            this.Controls.Add(this.FmsTriggerValueIN);
            this.Controls.Add(this.MillSecWaitTimeIN);
            this.Controls.Add(this.AvcNoteMakeLimitIN);
            this.Controls.Add(this.avcvalIN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "AdvancedLevelSelect";
            this.Text = "Any song rhythm tap game! (Advanced difficulty select)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox avcvalIN;
        private System.Windows.Forms.TextBox AvcNoteMakeLimitIN;
        private System.Windows.Forms.TextBox MillSecWaitTimeIN;
        private System.Windows.Forms.TextBox FmsTriggerValueIN;
        private System.Windows.Forms.TextBox notemakeConstantIN;
    }
}