using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class RegistroC : Form
    {
        MySqlConnection conn;
        public RegistroC()
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
            int IdCliente = Convert.ToInt32(txtID.Text);
            int edad = Convert.ToInt32(txtEdad.Text);
            string cadena = "insert into cliente (idcliente, nombre, apellido, edad, cedula, usuario, password, correo, telefono) value (@idcliente, @nombre, @apellido, @edad, @cedula, @usuario, @password, @correo, @telefono)";
            using (MySqlCommand cmd = new MySqlCommand(cadena, conn))
            {
                cmd.Parameters.AddWithValue("idcliente", IdCliente);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@password", txtContra.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Registro realizado exitosamente");
            RegistroCliente cliente = new RegistroCliente();
            cliente.Show();
            this.Hide();
        }
        private int ObtenerSiguienteNumero()
        {

            conn.Open();

            string query = "SELECT COALESCE(MAX(idcliente), 0) + 1 FROM cliente";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {

                object resultado = command.ExecuteScalar();
                int siguienteNumero = Convert.ToInt32(resultado);
                conn.Close();
                return siguienteNumero;

            }

        }

        private void RegistroC_Load(object sender, EventArgs e)
        {
            int numero = ObtenerSiguienteNumero();
            txtID.Text = numero.ToString();
        }

        private void btnCLiente_Click(object sender, EventArgs e)
        {
            Ini_RegCliente menu = new Ini_RegCliente();
            menu.Show();
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
        private void btnCLiente_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnCLiente);
        }

        private void btnCLiente_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnCLiente);

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
