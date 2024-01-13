using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class ConsultaCliente : Form
    {
        string idcliente;
        string nombreC;
        public ConsultaCliente(string codigo, string nombre)
        {
            InitializeComponent();
            idcliente = codigo;
            nombreC = nombre;
            txtNombre.Text = "Bienvebido/a " + nombreC;
            txtcodigo.Text = "Cliente N. " + idcliente;

        }


        private void btnCLiente_Click(object sender, EventArgs e)
        {
            ConsultaCliente1 menu = new ConsultaCliente1(idcliente, nombreC);
            menu.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            PedidosClientes pedidos = new PedidosClientes(idcliente, nombreC);
            pedidos.Show();
            this.Hide();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            EditarRegCliente update = new EditarRegCliente(idcliente, nombreC);
            update.Show();
            this.Hide();
        }
        public void Marcar(Button button)
        {
            button.BackColor = Color.Navy;
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = null;
        }
        //FUNCION PARA QUE RECUPEREN SU COLOR NORMAL AL QUITAR EL MOUSE
        public void Desmarcar(Button button)
        {
            button.BackColor = SystemColors.Control;
            button.ForeColor = System.Drawing.Color.Black;

        }
        private void btnCLiente_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnCLiente);
        }

        private void btnCLiente_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnCLiente);
        }

        private void btnPedidos_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnPedidos);
        }

        private void btnPedidos_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnPedidos);
        }

        private void btnUsuario_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnUsuario);
        }

        private void btnUsuario_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnUsuario);
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnSalir);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnSalir);
        }
    }
}
