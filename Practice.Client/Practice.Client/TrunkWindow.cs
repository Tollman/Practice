using Practice.Common;
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
	public partial class TrunkWindow : Form
	{
        public TrunkWindow()
		{
            InitializeComponent();
            this.Load += TrunkWindow_Load;
   		}

		void TrunkWindow_Load(object sender, EventArgs e)
		{
            IEnumerable<Trunk> trunks = Program.trunkRepo.GetAll();
            dataGridView1.DataSource = trunks;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTrunkWindow atw = new AddTrunkWindow();
            atw.Show();
            atw.FormClosed += atw_FormClosed;
        }

        void atw_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.DataSource = null;
           IEnumerable<Trunk> trunks = Program.trunkRepo.GetAll();
           dataGridView1.DataSource = trunks;
        }
        
        internal void ScrollControlIntoView()
        {
            throw new NotImplementedException();
        }
    }
}
