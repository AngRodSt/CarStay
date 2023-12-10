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
    public partial class TipoInicio : Form
    {
        public TipoInicio()
        {
            InitializeComponent();
        }

        private void btnProvedor_Click(object sender, EventArgs e)
        {
            Login logear = new Login();
            logear.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

