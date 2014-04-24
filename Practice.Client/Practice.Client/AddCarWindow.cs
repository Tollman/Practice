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
	public partial class AddCarWindow : Form
	{
		public AddCarWindow()
		{
			InitializeComponent();

			Thread loadThread = new Thread(ThreadLoader);
			loadThread.IsBackground = true;
			loadThread.Name = "Load trunks";
			loadThread.Start();

			//BackgroundWorker bw = new BackgroundWorker();
			//bw.DoWork += bw_DoWork;
			//bw.RunWorkerAsync();
		}

		void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			(sender as BackgroundWorker).DoWork -= bw_DoWork;

			ThreadLoader();
		}

		private void ThreadLoader()
		{
			using (TrunkProxy proxy = new TrunkProxy(Program.TrunkUrl))
			{
				IEnumerable<Trunk> trunksSource = proxy.GetAll();
				TrunkChoseBox.Invoke((MethodInvoker)(() =>
				{
					TrunkChoseBox.DisplayMember = "Address";
					TrunkChoseBox.DataSource = trunksSource;
					TrunkChoseBox.SelectedIndex = -1;
				}));
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			string chekingCost = CostBox.Text.Trim();
			string chekingMark = MarkBox.Text.Trim();
			string chekingColor = ColorBox.Text.Trim();
			float cost;
			bool chekParse = float.TryParse(chekingCost, out cost);

			if (!string.IsNullOrEmpty(chekingCost) && !string.IsNullOrEmpty(chekingMark) && !string.IsNullOrEmpty(chekingColor) && chekParse && TrunkChoseBox.SelectedIndex > -1)
			{
				Car newCar = new Car();
				newCar.Cost = cost;
				newCar.Mark = chekingMark;
				newCar.Color = chekingColor;

				Trunk selectedTrunk = (TrunkChoseBox.SelectedValue as Trunk);
				if (selectedTrunk != null)
				{
					newCar.TrunkId = selectedTrunk.Id;
					selectedTrunk.Cars.Add(newCar);
					selectedTrunk.CarCount++;
					using (TrunkProxy proxy = new TrunkProxy(Program.TrunkUrl))
					{
						proxy.Update(selectedTrunk);
						//Program.trunkRepo.Update(selectedTrunk);
					}
				}
				//Program.carRepo.Add(newCar);
				this.Close();
			}
			else
				MessageBox.Show("Maybe, You forgot fill some fields or You enter a wrong cost or don't chose a trunk");
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
