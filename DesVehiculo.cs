using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarStay
{
    public partial class DesVehiculo : Form
    {
        MySqlConnection conn;
        string codigo;
        string idcliente;

        public DesVehiculo(string codigo1, string cliente)
        {
            InitializeComponent();
            codigo = codigo1;
            idcliente = cliente;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);

        }

        private void DesVehiculo_Load(object sender, EventArgs e)
        {
            int codigoV = Convert.ToInt32(codigo);

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
                Label precio = new Label();
                PictureBox Photo = new PictureBox();
                Button alquilar = new Button();

                panel.Width = 569;
                panel.Height = 240;
                panel.BackColor = System.Drawing.Color.LightGray;

                Marca.Font = myfont;
                Marca.Location = new Point(8, 10);
                Marca.Text = "Marca: " + fila["Marca"].ToString();
                Marca.AutoSize = false;
                Marca.Width = 150;
                Marca.BackColor = System.Drawing.Color.LightGray;

                Modelo.Font = myfont;
                Modelo.Location = new Point(8, 43);
                Modelo.Text = "Modelo: " + fila["Modelo"].ToString();
                Modelo.AutoSize = false;
                Modelo.Width = 200;
                Modelo.BackColor = System.Drawing.Color.LightGray;

                Matricula.Font = myfont;
                Matricula.Location = new Point(8, 75);
                Matricula.Text = "matricula: " + fila["Matricula"].ToString();
                Matricula.AutoSize = false;
                Matricula.Width = 150;
                Matricula.BackColor = System.Drawing.Color.LightGray;

                Motor.Font = myfont;
                Motor.Location = new Point(8, 107);
                Motor.Text = "Motor: " + fila["Motor"].ToString();
                Motor.AutoSize = false;
                Motor.Width = 150;
                Motor.BackColor = System.Drawing.Color.LightGray;

                Cilindros.Font = myfont;
                Cilindros.Location = new Point(8, 139);
                Cilindros.Text = "Cilindros: " + fila["Cilintros"].ToString();
                Cilindros.AutoSize = false;
                Cilindros.Width = 150;
                Cilindros.BackColor = System.Drawing.Color.LightGray;

                Capacidad.Font = myfont;
                Capacidad.Location = new Point(8, 171);
                Capacidad.Text = "Capacidad: " + fila["Capacidad"].ToString();
                Capacidad.AutoSize = false;
                Capacidad.Width = 150;
                Capacidad.BackColor = System.Drawing.Color.LightGray;

                Color.Font = myfont;
                Color.Location = new Point(8, 203);
                Color.Text = "Color: " + fila["Color"].ToString();
                Color.AutoSize = false;
                Color.Width = 150;
                Color.BackColor = System.Drawing.Color.LightGray;

                Kilometraje.Font = myfont;
                Kilometraje.Location = new Point(211, 10);
                Kilometraje.Text = "Kilometraje: " + fila["Kilometraje"].ToString();
                Kilometraje.AutoSize = false;
                Kilometraje.Width = 150;
                Kilometraje.BackColor = System.Drawing.Color.LightGray;

                Dimensiones.Font = myfont;
                Dimensiones.Location = new Point(211, 43);
                Dimensiones.Text = "Dimensiones: " + fila["Dimensiones"].ToString();
                Dimensiones.AutoSize = false;
                Dimensiones.Width = 200;
                Dimensiones.BackColor = System.Drawing.Color.LightGray;

                Estado.Font = myfont;
                Estado.Location = new Point(211, 75);
                Estado.Text = "Estado: " + fila["Estado"].ToString();
                Estado.AutoSize = false;
                Estado.Width = 150;
                Estado.BackColor = System.Drawing.Color.LightGray;

                Año.Font = myfont;
                Año.Location = new Point(211, 107);
                Año.Text = "Año: " + fila["Year"].ToString();
                Año.AutoSize = false;
                Año.Width = 150;
                Año.BackColor = System.Drawing.Color.LightGray;

                precio.Font = myfont;
                precio.Location = new Point(211, 139);
                precio.Text = "Precio: $ " + fila["Precio"].ToString();
                precio.AutoSize = false;
                precio.Width = 150;
                precio.ForeColor = System.Drawing.Color.DarkBlue;
                precio.BackColor = System.Drawing.Color.LightGray;

                byte[] img = (byte[])fila["Photo"];
                MemoryStream ms = new MemoryStream(img);

                Photo.Width = 175;
                Photo.Height = 175;
                Photo.BackgroundImage = Image.FromStream(ms);
                Photo.BackgroundImageLayout = ImageLayout.Zoom;
                Photo.Location = new Point(367, 10);
                Photo.BackColor = System.Drawing.Color.LightGray;

                alquilar.Font = myfont;
                alquilar.Location = new Point(367, 203);
                alquilar.Width = 175;
                alquilar.Height = 27;
                alquilar.BackColor = System.Drawing.Color.Navy;
                alquilar.ForeColor = System.Drawing.Color.White;
                alquilar.Text = "CREAR SOLICITUD";

                panel.Controls.Add(alquilar);
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
                panel.Controls.Add(precio);

                FLP2.Controls.Add(panel);


                alquilar.Click += btn_done_clicked;

            }
            conn.Close();
        }
        void btn_done_clicked(object sender, EventArgs e)
        {
            SolicitudV solicitudV = new SolicitudV(codigo, idcliente);
            ConsultaCliente1 consulta = Application.OpenForms["ConsultaCliente1"] as ConsultaCliente1;
            if (consulta != null)
            {
                consulta.Close();
            }
            solicitudV.Show();
            this.Hide();

        }
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FLP2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
