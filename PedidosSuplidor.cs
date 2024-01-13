using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarStay
{
    public partial class PedidosSuplidor : Form
    {
        MySqlConnection conn;
        int idsuplidor;
        public PedidosSuplidor(int suplidor)
        {
            InitializeComponent();
            idsuplidor = suplidor;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
        }
        private void PedidosSuplidor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            CARSTAY menuPrin = new CARSTAY(idsuplidor);
            menuPrin.Show();
            this.Close();
        }
        string cMostrar;
        MySqlDataAdapter da;
        DataSet ds;

        int estado = 1;

        string idpedidos;
        private void MostrarDatos()
        {
            conn.Open();

            cMostrar = "select * from pedidos join vehiculo on pedidos.idvehiculo = vehiculo.idvehiculo where pedidos.estado=" + estado + " and pedidos.idsuplidor= " + idsuplidor;
            da = new MySqlDataAdapter(cMostrar, conn);
            ds = new DataSet();
            da.Fill(ds);
            foreach (Control item in FLP2.Controls)
            {
                FLP2.Controls.Remove(item);
            }
            FLP2.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {


                    Panel Panel = new Panel();
                    Button Mybutton = new Button();
                    PictureBox Photo = new PictureBox();
                    Label Lmarca = new Label();
                    Label marcaA = new Label();
                    Label Lyear = new Label();
                    Label Lmodelo = new Label();
                    Label Lprecio = new Label();
                    Label total = new Label();
                    Font labelF = new Font("Myanmar Text", 7, FontStyle.Bold);
                    Font labelF1 = new Font("Myanmar Text", 9, FontStyle.Bold);
                    Panel.Width = 500;
                    Panel.Height = 180;

                    Panel.BackColor = Color.LightGray;



                    Lmarca.Text = "Retiro: " + fila["retiro"].ToString();
                    Lmarca.Location = new Point(12, 23);
                    Lmarca.Font = labelF;
                    Lmarca.AutoSize = false;
                    Lmarca.Width = 300;
                    Lmarca.BackColor = Color.LightGray;

                    Lmodelo.Text = "Entrega: " + fila["entrega"].ToString();
                    Lmodelo.Location = new Point(12, 45);
                    Lmodelo.Font = labelF;
                    Lmodelo.AutoSize = false;
                    Lmodelo.Width = 300;
                    Lmodelo.BackColor = Color.LightGray;

                    Lyear.Text = "Fecha Retiro: " + fila["fechaR"].ToString();
                    Lyear.Location = new Point(12, 68);
                    Lyear.Font = labelF;
                    Lyear.AutoSize = false; Lyear.Width = 300;
                    Lyear.BackColor = Color.LightGray;

                    Lprecio.Text = "Fecha Entrega: " + fila["fechaE"].ToString();
                    Lprecio.Location = new Point(12, 90);
                    Lprecio.Font = labelF;
                    Lprecio.AutoSize = false; Lprecio.Width = 300;
                    Lprecio.BackColor = Color.LightGray;

                    total.Text = "Total: $ " + fila["total"].ToString();
                    total.Location = new Point(12, 134);
                    total.AutoSize = false; Lprecio.Width = 300;
                    total.Font = labelF1;
                    total.ForeColor = Color.DarkBlue;
                    total.BackColor = Color.LightGray;

                    marcaA.Text = "Modelo: " + fila["modelo"].ToString();
                    marcaA.Location = new Point(12, 112);
                    marcaA.Font = labelF;
                    marcaA.AutoSize = false; marcaA.Width = 300;
                    marcaA.BackColor = Color.LightGray;


                    byte[] img = (byte[])fila["Photo"];
                    MemoryStream ms = new MemoryStream(img);

                    Photo.Width = 155;
                    Photo.Height = 125;
                    Photo.BackgroundImage = Image.FromStream(ms);
                    Photo.BackgroundImageLayout = ImageLayout.Zoom;
                    Photo.Location = new Point(300, 6);
                    Photo.BackColor = Color.LightGray;

                    Mybutton.Text = "Informacion Personal";
                    Mybutton.Location = new Point(12, 156);
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
                    Panel.Controls.Add(total);
                    Panel.Controls.Add(Lprecio);
                    Panel.Controls.Add(Mybutton);
                    Panel.Controls.Add(marcaA);


                    FLP2.Controls.Add(Panel);

                    Mybutton.Click += btn_done_clicked;
                    void btn_done_clicked(object sender, EventArgs e)
                    {
                        idpedidos = fila["idpedidos"].ToString();
                        DesCliente descripcion = new DesCliente(idpedidos, idsuplidor);
                        descripcion.Show();
                        this.Hide();


                    }
                }

            }
            conn.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FLP2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
