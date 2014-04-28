using Practice.Client.Services;
using Practice.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Practice.Client
{
	public partial class CarWindow : Form
	{
		public CarWindow()
		{
			InitializeComponent();
			
            Thread loadThread = new Thread(ThreadLoader);
            loadThread.IsBackground = true;
            loadThread.Name = "Load cars";
            loadThread.Start();
		}

        private void ThreadLoader()
        {
            using (CarProxy proxy = new CarProxy(Program.CarUrl))
            {
                IEnumerable<Car> cars = proxy.GetAll();
                carDataGridView.Invoke((MethodInvoker)(() =>
                {
                    carDataGridView.DataSource = cars;
                }));
            }
        }

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddCarWindow acw = new AddCarWindow();
			acw.Owner = this;
			acw.Show();
			acw.FormClosed += acw_FormClosed;
		}

		private void acw_FormClosed(object sender, FormClosedEventArgs e)
		{
			(sender as AddCarWindow).FormClosed -= acw_FormClosed;
			carDataGridView.DataSource = null;
            Thread loadThread = new Thread(ThreadLoader);
            loadThread.IsBackground = true;
            loadThread.Name = "Load cars";
            loadThread.Start();
            //ThreadLoader();
		}
	}
}