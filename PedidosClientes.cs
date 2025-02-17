﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarStay
{
    public partial class PedidosClientes : Form
    {
        MySqlConnection conn;
        string cliente;
        string nombreC;
        public PedidosClientes(string idcliente, string nombre)
        {
            InitializeComponent();
            cliente = idcliente;
            nombreC = nombre;
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
        }
        public PedidosClientes() { }

        private void PedidosClientes_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        string cMostrar;
        MySqlDataAdapter da;
        DataSet ds;
        private void MostrarDatos()
        {
            conn.Open();
            int idcliente = Convert.ToInt32(cliente);
            cMostrar = "select * from pedidos join vehiculo on pedidos.idvehiculo = vehiculo.idvehiculo where idcliente= " + idcliente;
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
                    PictureBox Photo = new PictureBox();
                    Label Lmarca = new Label();
                    Label Lyear = new Label();
                    Label Lmodelo = new Label();
                    Label Lprecio = new Label();
                    Label total = new Label();
                    Font labelF = new Font("Myanmar Text", 7, FontStyle.Bold);
                    Font labelF1 = new Font("Myanmar Text", 9, FontStyle.Bold);
                    Panel.Width = 500;
                    Panel.Height = 140;

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
                    total.Location = new Point(12, 112);
                    total.AutoSize = false; Lprecio.Width = 300;
                    total.Font = labelF1;
                    total.ForeColor = Color.DarkBlue;
                    total.BackColor = Color.LightGray;




                    byte[] img = (byte[])fila["Photo"];
                    MemoryStream ms = new MemoryStream(img);

                    Photo.Width = 155;
                    Photo.Height = 125;
                    Photo.BackgroundImage = Image.FromStream(ms);
                    Photo.BackgroundImageLayout = ImageLayout.Zoom;
                    Photo.Location = new Point(300, 6);
                    Photo.BackColor = Color.LightGray;




                    Panel.Controls.Add(Photo);


                    Panel.Controls.Add(Lmodelo);
                    Panel.Controls.Add(Lmarca);
                    Panel.Controls.Add(Lyear);
                    Panel.Controls.Add(total);
                    Panel.Controls.Add(Lprecio);


                    FLP2.Controls.Add(Panel);

                    // Mybutton.Click += btn_done_clicked;
                    /*  void btn_done_clicked(object sender, EventArgs e)
                      {
                          string codigo = fila["idvehiculo"].ToString();
                          DesVehiculo descripcion = new DesVehiculo(codigo, idcliente);
                          descripcion.Show();


                      }*/
                }

            }
            conn.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            ConsultaCliente menuP = new ConsultaCliente(cliente, nombreC);
            menuP.Show();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
