using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class EditRegSuplidorescs : Form
    {
        int idsuplidor;
        MySqlConnection conn;
        CARSTAY car;

        public EditRegSuplidorescs(int suplidor)
        {
            InitializeComponent();
            idsuplidor = suplidor;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
            car = new CARSTAY(idsuplidor);
        }

        private void EditRegSuplidorescs_Load(object sender, EventArgs e)
        {
            txtID.Text = idsuplidor.ToString();
            Cargar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conn.Open();

            string cadenaUpdate = "update suplidores set  Usuario=@Usuario, Contraseña=@Contraseña, Nombre=@Nombre, Rnc=@Rnc, Direccion=@Direccion, Nombre_Socio=@Nombre_Socio, Cedula=@Cedula, Telefono=@Telefono, Correo=@Correo where idSuplidor=" + idsuplidor;
            using (MySqlCommand cmd = new MySqlCommand(cadenaUpdate, conn))
            {

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
                MessageBox.Show("Actualizacion realizada exitosamente");

            }
            conn.Close();

            car.Show();
            this.Close();
        }
        private void Cargar()
        {
            conn.Open();
            string cadena = "select * from suplidores where idSuplidor=" + idsuplidor;
            MySqlCommand cmd = new MySqlCommand(cadena, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["Nombre"].ToString();
                txtRnc.Text = reader["Rnc"].ToString();
                txtDireccion.Text = reader["Direccion"].ToString();
                txtNombreP.Text = reader["Nombre_Socio"].ToString();
                txtCedula.Text = reader["Cedula"].ToString();
                txtTelefono.Text = reader["Telefono"].ToString();
                txtCorreo.Text = reader["Correo"].ToString();
                TxtUsuario.Text = reader["Usuario"].ToString();
                txtContra.Text = reader["Contraseña"].ToString();
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            car.Show();
            this.Close();
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
