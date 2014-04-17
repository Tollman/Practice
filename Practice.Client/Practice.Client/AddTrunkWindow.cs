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
        Trunk newTrunk = new Trunk();
        public AddTrunkWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string enteredName = NameBox.Text;
            string chekingName = enteredName.Trim();
            string enteredAddress = AddressBox.Text;
            string chekingAddress = enteredAddress.Trim();
            if (chekingName != "" && chekingAddress != "")
            {
                newTrunk.Name = chekingName;
                newTrunk.Address = chekingAddress;
                Program.trunkRepo.Add(newTrunk);
                this.Close();
            }
            else MessageBox.Show("You don't enter a trunk name or address");  
            //Program.trunkRepo.Add(
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
