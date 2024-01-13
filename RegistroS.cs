using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class RegistroS : Form
    {
        MySqlConnection conn;
        public RegistroS()
        {
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            conn.Open();
            int IdSup = Convert.ToInt32(txtID.Text);
            string cadena = "insert into suplidores(idSuplidor, Usuario, Contraseña, Nombre, Rnc, Direccion, Nombre_Socio, Cedula, Telefono, Correo) value (@idSuplidor, @Usuario, @Contraseña, @Nombre, @Rnc, @Direccion, @Nombre_Socio, @Cedula, @Telefono, @Correo)";
            using (MySqlCommand cmd = new MySqlCommand(cadena, conn))
            {
                cmd.Parameters.AddWithValue("@idSuplidor", IdSup);
                cmd.Parameters.AddWithValue("@Usuario", TxtUsuario.Text);
                cmd.Parameters.AddWithValue("@Contraseña", txtContra.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Rnc", txtRnc.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@Nombre_Socio", txtNombreP.Text);
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro realizado exitosamente");

            }
            conn.Close();
            LoginProv loginProv = new LoginProv();
            loginProv.Show();
            this.Close();

        }
        private int ObtenerSiguienteNumero()
        {

            conn.Open();

            string query = "SELECT COALESCE(MAX(idSuplidor), 0) + 1 FROM suplidores";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {

                object resultado = command.ExecuteScalar();
                int siguienteNumero = Convert.ToInt32(resultado);
                conn.Close();
                return siguienteNumero;

            }

        }

        private void RegistroS_Load(object sender, EventArgs e)
        {
            int numero = ObtenerSiguienteNumero();
            txtID.Text = numero.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login menu = new Login();
            menu.Show();
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
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Marcar(button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(button3);
        }

        private void btnRegistrar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnRegistrar);
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnRegistrar);
        }
    }
}
