using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarStay
{
    public partial class ConsultaCliente1 : Form
    {

        string[] capacidad = { " ", "1", "2", "4", "5", "8" };
        string[] cilindros = { " ", "I4", "V6", "V8", "V10", "V12", "V16", "MOTOR ELECTRICO" };
        string[] marca = { " ","TOYOTA","FORD","CHEVROLET","VOLKSWAGEN","HONDA","MERCEDES-BENZ","BMW",
            "FERRARI","NISSAN","TESLA","AUDI","HYUNDAI","KIA","MEZDA","SUBARU","JEEP","LAND ROVER","JAGUAR","PORSCHE","ACURA","VOLVO","LAMBORGHINI"};

        MySqlConnection conn;
        string idcliente;
        string nombreC;
        public ConsultaCliente1(string cliente, string nombre)
        {
            InitializeComponent();
            idcliente = cliente;
            nombreC = nombre;
            txtcodigo.Text = "N. Cliente: " + idcliente;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);


        }
        public ConsultaCliente1(string cliente)
        {
            InitializeComponent();
            idcliente = cliente;
            txtcodigo.Text = "N. Cliente: " + idcliente;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);


        }

        private void RellenarCB(ComboBox cb, string[] cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                cb.Items.Add(cad[i]);
            }
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        string cMostrar;
        MySqlDataAdapter da;
        DataSet ds;
        private void ConsultaCliente1_Load(object sender, EventArgs e)
        {
            RellenarCB(cbMarca, marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            conn.Open();
            cMostrar = "select * from vehiculo";
            da = new MySqlDataAdapter(cMostrar, conn);
            ds = new DataSet();
            da.Fill(ds);
            MostrarDatos();
            conn.Close();
        }

        private void MostrarDatos()
        {
            foreach (Control item in FLP2.Controls)
            {
                FLP2.Controls.Remove(item);
            }
            FLP2.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Button Mybutton = new Button();
                    Panel Panel = new Panel();
                    PictureBox Photo = new PictureBox();
                    Label Lmarca = new Label();
                    Label Lyear = new Label();
                    Label Lmodelo = new Label();
                    Label Lprecio = new Label();
                    Font labelF = new Font("Myanmar Text", 7, FontStyle.Bold);
                    Font labelF1 = new Font("Myanmar Text", 9, FontStyle.Bold);
                    Panel.Width = 357;
                    Panel.Height = 140;

                    Panel.BackColor = Color.LightGray;



                    Lmarca.Text = "Marca: " + fila["Marca"].ToString();
                    Lmarca.Location = new Point(12, 23);
                    Lmarca.Font = labelF;
                    Lmarca.AutoSize = false;
                    Lmarca.Width = 150;
                    Lmarca.BackColor = Color.LightGray;

                    Lmodelo.Text = "Modelo: " + fila["Modelo"].ToString();
                    Lmodelo.Location = new Point(12, 45);
                    Lmodelo.Font = labelF;
                    Lmodelo.AutoSize = false;
                    Lmodelo.Width = 150;
                    Lmodelo.BackColor = Color.LightGray;

                    Lyear.Text = "Año: " + fila["Year"].ToString();
                    Lyear.Location = new Point(12, 68);
                    Lyear.Font = labelF;
                    Lyear.BackColor = Color.LightGray;

                    Lprecio.Text = "Precio: $ " + fila["Precio"].ToString();
                    Lprecio.Location = new Point(12, 90);
                    Lprecio.Font = labelF1;
                    Lprecio.ForeColor = Color.DarkBlue;
                    Lprecio.BackColor = Color.LightGray;



                    byte[] img = (byte[])fila["Photo"];
                    MemoryStream ms = new MemoryStream(img);

                    Photo.Width = 155;
                    Photo.Height = 125;
                    Photo.BackgroundImage = Image.FromStream(ms);
                    Photo.BackgroundImageLayout = ImageLayout.Zoom;
                    Photo.Location = new Point(188, 6);
                    Photo.BackColor = Color.LightGray;

                    Mybutton.Text = "Saber más";
                    Mybutton.Location = new Point(12, 108);
                    Mybutton.Width = 91;
                    Mybutton.Height = 23;
                    Mybutton.Font = labelF;
                    Mybutton.ForeColor = Color.White;
                    Mybutton.BackColor = Color.Black;
                    Mybutton.TextAlign = ContentAlignment.TopCenter;
                    Mybutton.FlatAppearance.BorderSize = 2;
                    Mybutton.FlatStyle = FlatStyle.Flat;


                    Panel.Controls.Add(Photo);


                    Panel.Controls.Add(Lmodelo);
                    Panel.Controls.Add(Lmarca);
                    Panel.Controls.Add(Lyear);
                    Panel.Controls.Add(Mybutton);
                    Panel.Controls.Add(Lprecio);


                    FLP2.Controls.Add(Panel);

                    Mybutton.Click += btn_done_clicked;
                    void btn_done_clicked(object sender, EventArgs e)
                    {
                        string codigo = fila["idvehiculo"].ToString();
                        DesVehiculo descripcion = new DesVehiculo(codigo, idcliente);
                        descripcion.Show();


                    }
                }

            }
            conn.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            ConsultaCliente cliente = new ConsultaCliente(idcliente, nombreC);
            cliente.Show();
            this.Close();
        }

        private void btnFiltrarM_Click(object sender, EventArgs e)
        {
            conn.Open();
            cMostrar = "select * from vehiculo where Marca = @marca";
            using (MySqlCommand cmd = new MySqlCommand(cMostrar, conn))
            {
                cmd.Parameters.AddWithValue("@marca", cbMarca.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                cbCapacidad.SelectedIndex = 0;
                cbCilindros.SelectedIndex = 0;
                MostrarDatos();
            };
            conn.Close();

        }

        private void btnFiltrarC_Click(object sender, EventArgs e)
        {
            conn.Open();
            cMostrar = "select * from vehiculo where Cilintros = @cilindros";
            using (MySqlCommand cmd = new MySqlCommand(cMostrar, conn))
            {
                cmd.Parameters.AddWithValue("@cilindros", cbCilindros.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                cbCapacidad.SelectedIndex = 0;
                cbMarca.SelectedIndex = 0;
                MostrarDatos();
            };
            conn.Close();
        }

        private void btnFiltrarCa_Click(object sender, EventArgs e)
        {
            conn.Open();
            cMostrar = "select * from vehiculo where Capacidad = @capacidad";
            using (MySqlCommand cmd = new MySqlCommand(cMostrar, conn))
            {
                cmd.Parameters.AddWithValue("@capacidad", cbCapacidad.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                cbMarca.SelectedIndex = 0;
                cbCilindros.SelectedIndex = 0;
                MostrarDatos();
            };
            conn.Close();
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
            button.ForeColor = System.Drawing.Color.Black;

        }

        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnAtras);
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnAtras);
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnCerrar);
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnCerrar);
        }

        private void btnFiltrarM_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnFiltrarM);
        }

        private void btnFiltrarM_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnFiltrarM);
        }

        private void btnFiltrarC_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnFiltrarC);
        }

        private void btnFiltrarC_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnFiltrarC);
        }

        private void btnFiltrarCa_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnFiltrarCa);
        }

        private void btnFiltrarCa_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnFiltrarCa);
        }
    }
}
