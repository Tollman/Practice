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
		}
	}
}
