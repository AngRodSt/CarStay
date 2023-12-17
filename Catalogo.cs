using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStay
{
    public partial class Catalogo : Form
    {
        MySqlConnection conn;
        public Catalogo()
        {
            InitializeComponent();
        }
        private int idsuplidor;
        public Catalogo(int idSuplidor)
        {
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
            this.idsuplidor = idSuplidor;
            txtSup.Text = idsuplidor.ToString();
            MostrarBotton();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void MostrarBotton()
        {
            conn.Open();
            foreach(Control item in FLP1.Controls)
            {
                FLP1.Controls.Remove(item);
            }
            FLP1.Controls.Clear();
            int suplidor;
            Int32.TryParse(txtSup.Text, out suplidor);
           
            string cMostrar = "select * from vehiculo where idsuplidor=" + suplidor;
            MySqlDataAdapter da = new MySqlDataAdapter(cMostrar, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Button Mybutton;

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow fila in ds.Tables[0].Rows)
                {
                    Mybutton = new Button();
                    Font myfont = new Font("Myanmar Text", 10, FontStyle.Bold);

                    Mybutton.Text = fila["Modelo"].ToString();
                    Mybutton.Tag = fila["idvehiculo"];

                    byte[] img = (byte[])fila["Photo"];
                    MemoryStream ms = new MemoryStream(img);

                    Mybutton.Width = 150;
                    Mybutton.Height = 150;
                    Mybutton.BackgroundImageLayout = ImageLayout.Zoom;
                    Mybutton.Font = myfont;
                    Mybutton.ForeColor = Color.Black;
                    Mybutton.BackColor = Color.White;
                    Mybutton.TextAlign = ContentAlignment.TopLeft;
                    Mybutton.BackgroundImage = Image.FromStream(ms);
                    Mybutton.FlatAppearance.BorderSize = 2;
                    Mybutton.FlatAppearance.BorderColor = Color.AliceBlue; Mybutton.FlatStyle = FlatStyle.Flat;
                    FLP1.Controls.Add(Mybutton);

                    Mybutton.Click += btn_done_clicked;
                }
                
                
            }
            conn.Close();
        }
        private void btn_done_clicked(object sender, EventArgs e)
        {
            conn.Open();
            int automovilID= Convert.ToInt32(((Button)sender).Tag);

            string cadena = "select Marca, Modelo, Photo, Matricula, Motor, Cilintros, Capacidad, Color, Kilometraje, Dimensiones, " +
                "Estado, Year from vehiculo where idvehiculo = " + automovilID;

            MySqlCommand comando = new MySqlCommand(cadena, conn);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {

                
                txtMarca.Text = reader["Marca"].ToString();
                txtModelo.Text = reader["Modelo"].ToString();
                txtMatricula.Text = reader["Matricula"].ToString();
                txtMotor.Text = reader["Motor"].ToString();
                txtCilindros.Text = reader["Cilintros"].ToString();
                txtCapacidad.Text = reader["Capacidad"].ToString();
                txtColor.Text = reader["Color"].ToString();
                txtKilometraje.Text = reader["Kilometraje"].ToString();
                txtDimensiones.Text = reader["Dimensiones"].ToString();
                txtEstado.Text = reader["Estado"].ToString();
                txtYear.Text = reader["Year"].ToString();
            }
            else
            {
                MessageBox.Show("Codigo no encontrado");
            }
            conn.Close();
           
        }


    
        private void Catalogo_Load(object sender, EventArgs e)
        {
            MostrarBotton();
       
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Vehiculo car = new Vehiculo(idsuplidor);
            car.Show();
            this.Hide();

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
