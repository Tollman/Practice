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
    public partial class AddCarWindow : Form
    {
        private IEnumerable<Trunk> trunksSource = Program.trunkRepo.GetAll();
        public AddCarWindow()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            int i = -1;
            foreach (Trunk item in trunksSource)
            {
                i++;
                string allinfo = trunksSource.ElementAt<Trunk>(i).Id.ToString() + " " + trunksSource.ElementAt<Trunk>(i).Name + " " + trunksSource.ElementAt<Trunk>(i).Address;
                list.Add(allinfo);
            }
            list.Add(null);
            TrunkChoseBox.DataSource = list;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string chekingCost = CostBox.Text.Trim();
            string chekingMark = MarkBox.Text.Trim();
            string chekingColor = ColorBox.Text.Trim();
            float cost;
            bool chekParse = float.TryParse(chekingCost, out cost);

            if (!string.IsNullOrEmpty(chekingCost) && !string.IsNullOrEmpty(chekingMark) && !string.IsNullOrEmpty(chekingColor) && chekParse && TrunkChoseBox.SelectedIndex>-1)
            {
                Car newCar = new Car();
                newCar.Cost = cost;
                newCar.Mark = chekingMark;
                newCar.Color = chekingColor;
                int i = -1;
                     foreach (Trunk item in trunksSource)
                        {
                            i++;
                            string chekingTrunk = trunksSource.ElementAt<Trunk>(i).Id.ToString() + " " + trunksSource.ElementAt<Trunk>(i).Name + " " + trunksSource.ElementAt<Trunk>(i).Address;
                            if (TrunkChoseBox.SelectedValue.ToString() == chekingTrunk) 
                            { 
                                newCar.TrunkId = trunksSource.ElementAt<Trunk>(i).Id;
                                trunksSource.ElementAt<Trunk>(i).CarCount++;
                                trunksSource.ElementAt<Trunk>(i).Cars.Add(newCar);
                                Program.trunkRepo.Update(trunksSource.ElementAt<Trunk>(i));
                            }
                        }
                Program.carRepo.Add(newCar);
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
