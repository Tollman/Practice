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
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string chekingCost = CostBox.Text.Trim();
            string chekingMark = MarkBox.Text.Trim();
            string chekingColor = ColorBox.Text.Trim();
            float cost;
            bool chekParse = float.TryParse(chekingCost, out cost);

            if (!string.IsNullOrEmpty(chekingCost) && !string.IsNullOrEmpty(chekingMark) && !string.IsNullOrEmpty(chekingColor) && chekParse)
            {
                Car newCar = new Car();
                newCar.Cost = cost;
                newCar.Mark = chekingMark;
                newCar.Color = chekingColor;
                Program.carRepo.Add(newCar);
                this.Close();
            }
            else
                MessageBox.Show("Maybe, You forgot fill some fields or You enter a wrong cost");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
