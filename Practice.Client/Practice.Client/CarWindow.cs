using Practice.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practice.Client
{
    public partial class CarWindow : Form
    {
        public CarWindow()
        {
            InitializeComponent();
            this.Load += CarWindow_Load;
        }

        private void CarWindow_Load(object sender, EventArgs e)
        {
            IEnumerable<Car> cars = Program.carRepo.GetAll();
            carDataGridView.DataSource = cars;
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
            IEnumerable<Car> cars = Program.carRepo.GetAll();
            carDataGridView.DataSource = cars;
        }
    }
}