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
    public partial class ConsultaCliente : Form
    {
        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void btnCLiente_Click(object sender, EventArgs e)
        {
            ConsultaCliente1 menu = new ConsultaCliente1();
            menu.Show();
            this.Hide();
        }


    }
}
