using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStay
{
    public partial class RegistroCliente : Form
    {   MySqlConnection conn;
        public RegistroCliente()
        {
            InitializeComponent();
            ConexionW  conect = new ConexionW();
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
            button.BackColor = Color.LightCoral;
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Validar = "Select idcliente from cliente where usuario=@Usuario and password=@Contra";
            using (MySqlCommand cValidar = new MySqlCommand(Validar, conn))
            {
                cValidar.Parameters.AddWithValue("@Usuario", txtUs.Text);
                cValidar.Parameters.AddWithValue("@Contra", txtCont.Text);
                object resultado = cValidar.ExecuteScalar();


                if (resultado != null)
                {
                    idCliente = Convert.ToInt32(resultado);
                   
                    ConsultaCliente bienvenida = new ConsultaCliente();
                    bienvenida.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            };

            conn.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            TipoInicio atras = new TipoInicio();
            atras.Show();
            this.Close();
        }

       
    }
}
