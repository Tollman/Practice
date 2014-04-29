using Practice.Client.Services;
using Practice.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Practice.Client
{
	public partial class TrunkWindow : Form
	{
		public TrunkWindow()
		{
			InitializeComponent();

			Thread loadThread = new Thread(ThreadLoader);
			loadThread.IsBackground = true;
			loadThread.Name = "Load trunks";
			loadThread.Start();
		}

		private void ThreadLoader()
		{
			using (TrunkProxy proxy = new TrunkProxy(Program.TrunkUrl))
			{
				IEnumerable<Trunk> trunks = proxy.GetAll();
				dataGridView1.Invoke((MethodInvoker)(() =>
				{
					dataGridView1.DataSource = trunks;
				}));
			}
		}


		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTrunkWindow atw = new AddTrunkWindow();
			atw.Owner = this;
			atw.Show();
			atw.FormClosed += atw_FormClosed;
		}

		void atw_FormClosed(object sender, FormClosedEventArgs e)
		{
			(sender as AddTrunkWindow).FormClosed -= atw_FormClosed;

			dataGridView1.DataSource = null;
			using (TrunkProxy proxy = new TrunkProxy(Program.TrunkUrl))
			{
				IEnumerable<Trunk> trunks = proxy.GetAll();
				dataGridView1.DataSource = trunks;
			}
		}
	}
}
