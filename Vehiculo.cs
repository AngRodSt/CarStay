using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class Vehiculo : Form
    {
        int idsuplidor;

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

        private void button2_Click(object sender, EventArgs e)
        {
            PedidosAceptadoscs aceptados = new PedidosAceptadoscs(idsuplidor);
            aceptados.Show();
            this.Hide();
        }
        public void Marcar(Button button)
        {
            button.BackColor = Color.Navy;
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = null;
        }

        public void Desmarcar(Button button)
        {
            button.BackColor = SystemColors.Control;
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = Properties.Resources._6222603;
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCatalogo_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnCatalogo);
        }

        private void btnCatalogo_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnCatalogo);
        }

        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnModificar);
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnModificar);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Marcar(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(button2);
        }

        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnAtras);
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnAtras);
        }
    }
}
