using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class EditarRegCliente : Form
    {
        MySqlConnection conn;
        string idCliente;
        string nombreCl;
        ConsultaCliente cliente;
        public EditarRegCliente(string idcliente, string nombreC)
        {
            InitializeComponent();
            idCliente = idcliente;
            nombreCl = nombreC;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
            cliente = new ConsultaCliente(idCliente, nombreCl);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conn.Open();
            int IdCliente = Convert.ToInt32(idCliente);
            int edad = Convert.ToInt32(txtEdad.Text);
            string cadena = "update cliente set  nombre=@nombre, apellido=@apellido, edad=@edad, cedula=@cedula, usuario=@usuario, password=@password, correo=@correo, telefono=@telefono where idcliente=" + IdCliente;
            using (MySqlCommand cmd = new MySqlCommand(cadena, conn))
            {

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
            MessageBox.Show("Actualizacion realizada exitosamente");

            cliente.Show();
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            cliente.Show();
            this.Close();
        }
        private void Cargar()
        {
            conn.Open();
            int IdCliente = Convert.ToInt32(idCliente);
            string cadena = "select * from cliente where idcliente=" + IdCliente;
            MySqlCommand cmd = new MySqlCommand(cadena, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["nombre"].ToString();
                txtApellido.Text = reader["apellido"].ToString();
                txtCedula.Text = reader["cedula"].ToString();
                txtEdad.Text = reader["edad"].ToString();
                txtUsuario.Text = reader["usuario"].ToString();
                txtContra.Text = reader["password"].ToString();
                txtCorreo.Text = reader["correo"].ToString();
                txtTelefono.Text = reader["telefono"].ToString();

            }
            conn.Close();
        }

        private void EditarRegCliente_Load(object sender, EventArgs e)
        {
            Cargar();
            txtID.Text = idCliente;
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
        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnAtras);
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnAtras);
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnGuardar);
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnGuardar);
        }
    }
}
