using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practice.Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void trunksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrunkWindow tw = new TrunkWindow();
            tw.Activate();
            tw.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarWindow cw = new CarWindow();
            cw.Show();
        }
    }
}
