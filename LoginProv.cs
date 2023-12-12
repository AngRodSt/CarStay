using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace CarStay
{
    public partial class LoginProv : Form
    {
        MySqlConnection conn;
        public LoginProv()
        {
            InitializeComponent();
            Conexion conect = new Conexion();
            conect.conec();
            string cadena = conect.cadena;
            conn = new MySqlConnection(cadena);
            
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
            button.BackgroundImage = Image.FromFile(@"C:\Users\AngRod\source\repos\CarStay\imagenes\6222603.jpg");
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Validar = "Select idSuplidor from suplidores where Usuario=@Usuario and Contraseña=@Contra";
            using (MySqlCommand cValidar = new MySqlCommand(Validar, conn))
            {
                cValidar.Parameters.AddWithValue("@Usuario",txtUs.Text);
                cValidar.Parameters.AddWithValue("@Contra", txtCont.Text);
                object resultado = cValidar.ExecuteScalar();

               
                if (resultado != null)
                {
                    int idSuplidor = Convert.ToInt32(resultado);
                    CARSTAY menuP = new CARSTAY();
                    menuP.Show();
                    this.Hide();
                    Modificaciones mod = new Modificaciones(idSuplidor);
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            } ;
            
            conn.Close();
           
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnSalir);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnSalir);
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
    }
}
