using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        public int idSuplidor;

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
                cValidar.Parameters.AddWithValue("@Usuario", txtUs.Text);
                cValidar.Parameters.AddWithValue("@Contra", txtCont.Text);
                object resultado = cValidar.ExecuteScalar();


                if (resultado != null)
                {
                    idSuplidor = Convert.ToInt32(resultado);

                    CARSTAY menuP = new CARSTAY(idSuplidor);
                    menuP.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            };

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtCont_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUs_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginProv_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Login menu = new Login();
            menu.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
