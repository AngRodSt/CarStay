using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStay
{
    public partial class CARSTAY : Form
    {
        public CARSTAY()
        {
            InitializeComponent();
            btnvehiculo.FlatAppearance.BorderSize = 10;
            btnvehiculo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 15, 255, 255);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
