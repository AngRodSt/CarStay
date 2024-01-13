using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class RegistroCliente : Form
    {
        MySqlConnection conn;
        public RegistroCliente()
        {
            InitializeComponent();
            Conexion conect = new Conexion();
            conect.conec();
            string cadena = conect.cadena;
            conn = new MySqlConnection(cadena);
        }
        public int idCliente;

        private void RegistroCliente_Load(object sender, EventArgs e)
        {

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
            button.BackgroundImage = Properties.Resources._6222603; ;
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

        private void btnIniciar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnIniciar);
        }

        private void btnIniciar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnIniciar);
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnSalir);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnSalir);
        }
        string cliente;
        string nombre;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            conn.Open();

            string Validar = "Select * from cliente where usuario= @usuario and password=@contrasena";
            using (MySqlCommand cmd = new MySqlCommand(Validar, conn))
            {
                cmd.Parameters.AddWithValue("@usuario", txtUs.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtCont.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null)
                {
                    foreach (DataRow fila in ds.Tables[0].Rows)
                    {
                        cliente = fila["idcliente"].ToString();
                        nombre = fila["nombre"].ToString();
                        ConsultaCliente bienvenida = new ConsultaCliente(cliente, nombre);
                        bienvenida.Show();
                        this.Close();

                    };
                }
                else { MessageBox.Show("Usuario no encontrado"); }
            }



            conn.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Ini_RegCliente atras = new Ini_RegCliente();
            atras.Show();
            this.Close();
        }


    }
}
