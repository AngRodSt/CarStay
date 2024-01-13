using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class Ini_RegCliente : Form
    {
        public Ini_RegCliente()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            RegistroCliente cliente = new RegistroCliente();
            cliente.Show();
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
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = Properties.Resources._6222603;
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnIniciar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnIniciar);
        }

        private void btnIniciar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnIniciar);
        }

        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnAtras);
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnAtras);
        }

        private void btnRegistrar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnRegistrar);
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnRegistrar);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            TipoInicio menu = new TipoInicio();
            menu.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroC Registro = new RegistroC();
            Registro.Show();
            this.Hide();
        }
    }
}
