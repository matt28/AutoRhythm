using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoTapTap1
{
    public partial class LevelSelectForm : Form
    {
        public LevelSelectForm()
        {
            InitializeComponent();
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            GameForm.AvcNoteMakeLimit = 2;
            GameForm.avcval = 30;
            GameForm.FmsTriggerValue = 450;
            GameForm.notemakeConstant = 1;
            GameForm.MillSecWaitTime = 0;
            this.Hide();
            Form tf = new GameForm();
            tf.Show();
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            GameForm.AvcNoteMakeLimit = 2;
            GameForm.avcval = 30;
            GameForm.FmsTriggerValue = 425;
            GameForm.notemakeConstant = 0.78;
            GameForm.MillSecWaitTime = 0;
            this.Hide();
            Form tf = new GameForm();
            tf.Show();
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            GameForm.AvcNoteMakeLimit = 2;
            GameForm.avcval = 30;
            GameForm.FmsTriggerValue = 375;
            GameForm.notemakeConstant = 0.67;
            GameForm.MillSecWaitTime = 0;
            this.Hide();
            Form tf = new GameForm();
            tf.Show();
        }

        private void ExtremeButton_Click(object sender, EventArgs e)
        {
            GameForm.AvcNoteMakeLimit = 2;
            GameForm.avcval = 30;
            GameForm.FmsTriggerValue = 200;
            GameForm.notemakeConstant = 0.55;
            GameForm.MillSecWaitTime = 0;
            this.Hide();
            Form tf = new GameForm();
            tf.Show();
        }

        private void AdvancedModeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form tf = new AdvancedLevelSelect();
            tf.Show();
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Form tf = new MainMenu();
            tf.Show();
        }
    }
}
