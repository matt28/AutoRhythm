namespace AutoTapTap1
{
    partial class MainMenu
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
            this.StartButton = new System.Windows.Forms.Button();
            this.HelpBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.ForeColor = System.Drawing.Color.SteelBlue;
            this.StartButton.Location = new System.Drawing.Point(81, 24);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 50);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "START!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButtonClicked);
            // 
            // HelpBttn
            // 
            this.HelpBttn.ForeColor = System.Drawing.Color.SteelBlue;
            this.HelpBttn.Location = new System.Drawing.Point(81, 80);
            this.HelpBttn.Name = "HelpBttn";
            this.HelpBttn.Size = new System.Drawing.Size(88, 57);
            this.HelpBttn.TabIndex = 3;
            this.HelpBttn.Text = "HELP";
            this.HelpBttn.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(376, 262);
            this.Controls.Add(this.HelpBttn);
            this.Controls.Add(this.StartButton);
            this.Name = "MainMenu";
            this.Text = "Any song rhythm tap game! (Main Menu)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button HelpBttn;
    }
}