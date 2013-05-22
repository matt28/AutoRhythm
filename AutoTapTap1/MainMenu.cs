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
    public partial class MainMenu : Form
    {
        public OpenFileDialog OFD = new OpenFileDialog();
        public MainMenu()
        {
            InitializeComponent();
            OFD.Filter = "wav files(*.wav)|*.wav";
            OFD.InitialDirectory = "C:/";
            OFD.Multiselect = false;
        }

        private void StartButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Choose a song!");
            OFD.ShowDialog();
            if (OFD.FileName != "")
            {
                GameForm.directory = OFD.FileName;
                this.Hide();
                Form tf = new LevelSelectForm();
                tf.Show();
            }
        }

        private void MainFormClosed(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("GoodBye! :)", "Exit", MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}
