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
	public partial class AddTrunkWindow : Form
	{
		public AddTrunkWindow()
		{
			InitializeComponent();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			string chekingName = NameBox.Text.Trim();
			string chekingAddress = AddressBox.Text.Trim();

			if (!string.IsNullOrEmpty(chekingName) && !string.IsNullOrEmpty(chekingAddress))
			{
				Trunk newTrunk = new Trunk();
				newTrunk.Name = chekingName;
				newTrunk.Address = chekingAddress;
				Program.trunkRepo.Add(newTrunk);
				this.Close();
			}
			else
				MessageBox.Show("You don't enter a trunk name or address");
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
