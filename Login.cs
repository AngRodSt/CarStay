using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            TipoInicio inicio = new TipoInicio();
            inicio.Show();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            LoginProv loginProv = new LoginProv();
            loginProv.Show();
            this.Close();
        }

        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnAtras);
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnAtras);
        }

        private void btnIniciar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnIniciar);
        }

        private void btnIniciar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnIniciar);
        }

        private void btnRegistrar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnRegistrar);
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnRegistrar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroS Registro = new RegistroS();
            Registro.Show();
            this.Hide();
        }
    }
}
