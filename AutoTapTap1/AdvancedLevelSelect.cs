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
    public partial class AdvancedLevelSelect : Form
    {
        public AdvancedLevelSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//This is the go button.
        {
            GameForm.AvcNoteMakeLimit = Convert.ToInt16(AvcNoteMakeLimitIN.Text);
            GameForm.avcval = Convert.ToInt32(avcvalIN.Text);
            GameForm.MillSecWaitTime = Convert.ToInt32(MillSecWaitTimeIN.Text);
            GameForm.notemakeConstant = Convert.ToDouble(notemakeConstantIN.Text);
            GameForm.FmsTriggerValue = Convert.ToInt32(FmsTriggerValueIN.Text);
            Form tf = new GameForm();
            this.Hide();
            tf.Show();
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Form tf = new MainMenu();
            tf.Show();
        }
    }
}
