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
    public partial class Vehiculo : Form
    {
        int idsuplidor;
        public Vehiculo()
        {
            InitializeComponent();
        }
        public Vehiculo(int idSuplidor)
        {
            InitializeComponent();
            this.idsuplidor = idSuplidor;
            txtSup.Text = idSuplidor.ToString();
        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            CARSTAY car = new CARSTAY(idsuplidor);
            car.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           Modificaciones mod = new Modificaciones(idsuplidor);
          mod.Show();
           this.Hide();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Catalogo catalogo = new Catalogo(idsuplidor);
            catalogo.Show();
            this.Hide();
        }
    }
}
