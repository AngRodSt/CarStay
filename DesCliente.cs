using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class DesCliente : Form
    {

        string idpedidos;
        int idsuplidor;
        MySqlConnection conn;
        public DesCliente(string pedidos, int suplidor)
        {
            InitializeComponent();

            idpedidos = pedidos;
            idsuplidor = suplidor;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            PedidosSuplidor supli = new PedidosSuplidor(idsuplidor);
            supli.Show();
            this.Close();

        }

        private void DesCliente_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }
        void mostrarDatos()
        {
            conn.Open();

            int pedido = Convert.ToInt32(idpedidos);
            string consulta = "select * from pedidos join cliente on pedidos.idcliente = cliente.idcliente where idpedidos=" + pedido;
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

                Button alquilar = new Button();

                panel.Width = 569;
                panel.Height = 240;
                panel.BackColor = System.Drawing.Color.LightGray;

                Marca.Font = myfont;
                Marca.Location = new Point(8, 10);
                Marca.Text = "Cliente: " + fila["nombre"].ToString() + " " + fila["apellido"].ToString();
                Marca.AutoSize = false;
                Marca.Width = 230;
                Marca.BackColor = System.Drawing.Color.LightGray;

                Modelo.Font = myfont;
                Modelo.Location = new Point(8, 43);
                Modelo.Text = "Cedula: " + fila["cedula"].ToString();
                Modelo.AutoSize = false;
                Modelo.Width = 300;
                Modelo.BackColor = System.Drawing.Color.LightGray;

                Matricula.Font = myfont;
                Matricula.Location = new Point(8, 75);
                Matricula.Text = "Tel.: " + fila["telefono"].ToString();
                Matricula.AutoSize = false;
                Matricula.Width = 300;
                Matricula.BackColor = System.Drawing.Color.LightGray;

                Motor.Font = myfont;
                Motor.Location = new Point(8, 107);
                Motor.Text = "Retiro: " + fila["retiro"].ToString();
                Motor.AutoSize = false;
                Motor.Width = 300;
                Motor.BackColor = System.Drawing.Color.LightGray;

                Cilindros.Font = myfont;
                Cilindros.Location = new Point(8, 139);
                Cilindros.Text = "Entrega: " + fila["entrega"].ToString();
                Cilindros.AutoSize = false;
                Cilindros.Width = 300;
                Cilindros.BackColor = System.Drawing.Color.LightGray;

                Capacidad.Font = myfont;
                Capacidad.Location = new Point(8, 171);
                Capacidad.Text = "Cobertura full Cover: " + fila["extra1"].ToString();
                Capacidad.AutoSize = false;
                Capacidad.Width = 300;
                Capacidad.BackColor = System.Drawing.Color.LightGray;

                Color.Font = myfont;
                Color.Location = new Point(8, 203);
                Color.Text = "Conductor extra: " + fila["extra3"].ToString();
                Color.AutoSize = false;
                Color.Width = 300;
                Color.BackColor = System.Drawing.Color.LightGray;

                Kilometraje.Font = myfont;
                Kilometraje.Location = new Point(350, 10);
                Kilometraje.Text = "Asiento extra: " + fila["extra4"].ToString();
                Kilometraje.AutoSize = false;
                Kilometraje.Width = 300;
                Kilometraje.BackColor = System.Drawing.Color.LightGray;

                Dimensiones.Font = myfont;
                Dimensiones.Location = new Point(350, 43);
                Dimensiones.Text = "Total: " + fila["total"].ToString();
                Dimensiones.AutoSize = false;
                Dimensiones.Width = 200;
                Dimensiones.BackColor = System.Drawing.Color.LightGray;

                /*Estado.Font = myfont;
                 Estado.Location = new Point(350, 75);
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
                 precio.BackColor = System.Drawing.Color.LightGray;*/


                alquilar.Font = myfont;
                alquilar.Location = new Point(367, 203);
                alquilar.Width = 175;
                alquilar.Height = 27;
                alquilar.BackColor = System.Drawing.Color.Navy;
                alquilar.ForeColor = System.Drawing.Color.White;
                alquilar.Text = "ALQUILAR";

                panel.Controls.Add(alquilar);
                panel.Controls.Add(Marca);
                panel.Controls.Add(Modelo);
                panel.Controls.Add(Matricula);
                panel.Controls.Add(Motor);
                panel.Controls.Add(Cilindros);
                panel.Controls.Add(Capacidad);
                panel.Controls.Add(Color);
                panel.Controls.Add(Kilometraje);
                panel.Controls.Add(Dimensiones);


                FLP2.Controls.Add(panel);

                conn.Close();

                alquilar.Click += btn_done_clicked;

            }

        }
        void btn_done_clicked(object sender, EventArgs e)
        {
            conn.Open();
            int estado = 2;
            int pedido = Convert.ToInt32(idpedidos);
            string actualizar = "update pedidos set estado=@estado where idpedidos=" + pedido;
            using (MySqlCommand cmd = new MySqlCommand(actualizar, conn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);

                cmd.ExecuteNonQuery();
            };

            PedidosSuplidor pedidoS = new PedidosSuplidor(idsuplidor);
            pedidoS.Show();
            this.Hide();
            conn.Close();
        }
    }
}

