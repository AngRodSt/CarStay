using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStay
{
    public partial class DesVehiculo : Form
    {
        MySqlConnection conn;
        string codigo;
        public DesVehiculo(string codigo1)
        {
            InitializeComponent();
            codigo = codigo1;
            ConexionW conexion = new ConexionW();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);

        }

        private void DesVehiculo_Load(object sender, EventArgs e)
        {
            int codigoV= Convert.ToInt32(codigo);
            
            conn.Open();
            string consulta = "select * from vehiculo where idvehiculo=" + codigoV;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Font myfont = new Font("Myanmar Text", 9, FontStyle.Bold);
                Panel panel = new Panel();
                Label Marca = new Label();
                Label Modelo = new Label();
                Label Matricula = new Label();
                Label Motor = new Label();
                Label Cilindros = new Label();
                Label Capacidad = new Label();
                Label Color = new Label();
                Label Kilometraje = new Label();
                Label Dimensiones = new Label();
                Label Estado = new Label();
                Label Año = new Label();
                PictureBox Photo = new PictureBox();
                Button alquilar = new Button();

                panel.Width = 569;
                panel.Height = 240;

                Marca.Font = myfont;
                Marca.Location = new Point(8, 10);
                Marca.Text = "Marca: " + fila["Marca"].ToString();
                Marca.AutoSize = false;
                Marca.Width = 150;

                Modelo.Font = myfont;
                Modelo.Location = new Point(8, 43);
                Modelo.Text = "Modelo: " + fila["Modelo"].ToString();
                Modelo.AutoSize = false;
                Modelo.Width = 200;

                Matricula.Font = myfont;
                Matricula.Location = new Point(8, 75);
                Matricula.Text = "matricula: " + fila["Matricula"].ToString();
                Matricula.AutoSize = false;
                Matricula.Width = 150;

                Motor.Font = myfont;
                Motor.Location = new Point(8, 107);
                Motor.Text = "Motor: " + fila["Motor"].ToString();
                Motor.AutoSize = false;
                Motor.Width = 150;

                Cilindros.Font = myfont;
                Cilindros.Location = new Point(8, 139);
                Cilindros.Text = "Cilindros: " + fila["Cilintros"].ToString();
                Cilindros.AutoSize = false;
                Cilindros.Width = 150;

                Capacidad.Font = myfont;
                Capacidad.Location = new Point(8, 171);
                Capacidad.Text = "Capacidad: " + fila["Capacidad"].ToString();
                Capacidad.AutoSize = false;
                Capacidad.Width = 150;

                Color.Font = myfont;
                Color.Location = new Point(8, 203);
                Color.Text = "Color: " + fila["Color"].ToString();
                Color.AutoSize = false;
                Color.Width = 150;

                Kilometraje.Font = myfont;
                Kilometraje.Location = new Point(211, 10);
                Kilometraje.Text = "Kilometraje: " + fila["Kilometraje"].ToString();
                Kilometraje.AutoSize = false;
                Kilometraje.Width = 150;

                Dimensiones.Font = myfont;
                Dimensiones.Location = new Point(211, 43);
                Dimensiones.Text = "Dimensiones: " + fila["Dimensiones"].ToString();
                Dimensiones.AutoSize = false;
                Dimensiones.Width = 200;

                Estado.Font = myfont;
                Estado.Location = new Point(211, 75);
                Estado.Text = "Estado: " + fila["Estado"].ToString();
                Estado.AutoSize = false;
                Estado.Width = 150;

                Año.Font = myfont;
                Año.Location = new Point(211, 107);
                Año.Text = "Año: " + fila["Year"].ToString();
                Año.AutoSize = false;
                Año.Width = 150;

                byte[] img = (byte[])fila["Photo"];
                MemoryStream ms = new MemoryStream(img);

                Photo.Width = 175;
                Photo.Height = 175;
                Photo.BackgroundImage = Image.FromStream(ms);
                Photo.BackgroundImageLayout = ImageLayout.Zoom;
                Photo.Location = new Point(367, 10);

                alquilar.Font = myfont;
                alquilar.Location = new Point(367, 203);
                alquilar.Width = 175;
                alquilar.Height = 23;
                alquilar.BackColor = System.Drawing.Color.LimeGreen;
                alquilar.Text = "ALQUILAR";

                panel.Controls.Add( alquilar );
                panel.Controls.Add(Photo);
                panel.Controls.Add(Año);
                panel.Controls.Add(Marca);
                panel.Controls.Add(Modelo);
                panel.Controls.Add(Matricula);
                panel.Controls.Add(Motor);
                panel.Controls.Add(Cilindros);
                panel.Controls.Add(Capacidad);
                panel.Controls.Add(Color);
                panel.Controls.Add(Kilometraje);
                panel.Controls.Add(Dimensiones);
                panel.Controls.Add(Estado);
                
                FLP2.Controls.Add(panel);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
