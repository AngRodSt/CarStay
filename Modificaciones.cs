using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace CarStay
{
    public partial class Modificaciones : Form
    {

        MySqlConnection conn;
        string[] estado = { "En uso", "Disponible", "Mantenimiento", "Fuera de Servicio", "Nuevo" };
        string[] capacidad = { "1", "2", "4", "5", "8" };
        string[] cilindros = { "I4", "V6", "V8", "V10", "V12", "V16", "MOTOR ELECTRICO" };
        string[] marca = {"TOYOTA","FORD","CHEVROLET","VOLKSWAGEN","HONDA","MERCEDES-BENZ","BMW",
            "FERRARI","NISSAN","TESLA","AUDI","HYUNDAI","KIA","MEZDA","SUBARU","JEEP","LAND ROVER","JAGUAR","PORSCHE","ACURA","VOLVO","LAMBORGHINI"};

        private int idsuplidor;
        public Modificaciones() { InitializeComponent(); }
        public Modificaciones(int idSuplidor)
        {

            InitializeComponent();
            Desactivar();
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
            this.idsuplidor = idSuplidor;
            txtSup.Text = idsuplidor.ToString();
        }


        private void RellenarCB(ComboBox cb, string[] cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                cb.Items.Add(cad[i]);
            }
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Modificaciones_Load(object sender, EventArgs e)
        {
            cargarDatos();
            RellenarCB(cbMarca, marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            RellenarCB(cbEstado, estado);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files|*.*|Image Files|*.jpg";
            ofd.Title = "Selecciona una imagen";

            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                PicFoto.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conn.Open();

            byte[] imageData = null;
            MySqlDataReader reader = null;
            try
            {
                if (PicFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PicFoto.Image.Save(ms, PicFoto.Image.RawFormat);
                        imageData = ms.ToArray();
                    }
                }
                else
                {
                    PicFoto.Image = Properties.Resources.ImagenPredeterminada;
                }
                int precio;
                int codigo;
                int suplidor;
                Int32.TryParse(txtPrecio.Text, out precio);
                Int32.TryParse(txtSup.Text, out suplidor);
                Int32.TryParse(txtID.Text, out codigo);
                string cBuscar = "select idvehiculo from vehiculo where idvehiculo= " + codigo + " and idsuplidor= " + suplidor;
                using (MySqlCommand comando1 = new MySqlCommand(cBuscar, conn))
                {
                    reader = comando1.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        string cadUpdate = "update vehiculo set Photo=@photo ,Marca=@marca, Modelo=@modelo" +
                            ",Matricula=@matricula,Motor=@motor,Cilintros=@cili,Capacidad=@capacidad,Color=@color,Kilometraje=@Kilom,Dimensiones=@dimensiones," +
                            "Estado=@estado,Year=@year, Precio=@precio  where idvehiculo=" + codigo + " and idsuplidor= " + suplidor;
                        using (MySqlCommand comando2 = new MySqlCommand(cadUpdate, conn))
                        {
                            comando2.Parameters.Add("@photo", MySqlDbType.LongBlob).Value = imageData;
                            comando2.Parameters.AddWithValue("@marca", cbMarca.SelectedItem);
                            comando2.Parameters.AddWithValue("@modelo", txtModelo.Text);
                            comando2.Parameters.AddWithValue("@matricula", txtmatricula.Text);
                            comando2.Parameters.AddWithValue("@motor", txtMotor.Text);
                            comando2.Parameters.AddWithValue("@cili", cbCilindros.SelectedItem);
                            comando2.Parameters.AddWithValue("@capacidad", cbCapacidad.SelectedItem);
                            comando2.Parameters.AddWithValue("@color", txtColor.Text);
                            comando2.Parameters.AddWithValue("@Kilom", txtKilom.Text);
                            comando2.Parameters.AddWithValue("@dimensiones", txtDimenc.Text);
                            comando2.Parameters.AddWithValue("@estado", cbEstado.SelectedItem);
                            comando2.Parameters.AddWithValue("@year", txtYear.Text);
                            comando2.Parameters.AddWithValue("@precio", precio);

                            comando2.ExecuteNonQuery();
                            MessageBox.Show("Datos Actualizados Exitosamente");
                        }
                    }
                    else
                    {
                        reader.Close();
                        string Guardar = "insert into vehiculo (idvehiculo,idsuplidor,Photo,Marca," +
                            "Modelo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year,Precio) " +
                            "value (@codigo,@suplidor,@photo,@marca,@modelo,@matricula,@motor,@cili,@capacidad,@color,@Kilom,@dimensiones,@estado,@year,@precio)";
                        using (MySqlCommand comando = new MySqlCommand(Guardar, conn))
                        {


                            comando.Parameters.AddWithValue("@codigo", codigo);
                            comando.Parameters.Add("@photo", MySqlDbType.LongBlob).Value = imageData;
                            comando.Parameters.AddWithValue("@suplidor", suplidor);
                            comando.Parameters.AddWithValue("@marca", cbMarca.SelectedItem);
                            comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                            comando.Parameters.AddWithValue("@matricula", txtmatricula.Text);
                            comando.Parameters.AddWithValue("@motor", txtMotor.Text);
                            comando.Parameters.AddWithValue("@cili", cbCilindros.SelectedItem);
                            comando.Parameters.AddWithValue("@capacidad", cbCapacidad.SelectedItem);
                            comando.Parameters.AddWithValue("@color", txtColor.Text);
                            comando.Parameters.AddWithValue("@Kilom", txtKilom.Text);
                            comando.Parameters.AddWithValue("@dimensiones", txtDimenc.Text);
                            comando.Parameters.AddWithValue("@estado", cbEstado.SelectedItem);
                            comando.Parameters.AddWithValue("@year", txtYear.Text);
                            comando.Parameters.AddWithValue("@precio", precio);

                            comando.ExecuteNonQuery();
                            MessageBox.Show("Datos Guardados Exitosamente");

                        };
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            Limpiar();
            RellenarCB(cbMarca, marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            RellenarCB(cbEstado, estado);
            Desactivar();
            conn.Close();
            txtID.Enabled = true;

            cargarDatos();


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Vehiculo ver = new Vehiculo(idsuplidor);
            ver.Show();
            this.Close();

        }

        private void Limpiar()
        {
            txtID.Clear();
            txtPrecio.Clear();
            cbMarca.Items.Clear();
            txtModelo.Clear();
            txtColor.Clear();
            txtKilom.Clear();
            txtDimenc.Clear();
            txtmatricula.Clear();
            txtYear.Clear();
            cbCapacidad.Items.Clear();
            cbCilindros.Items.Clear();
            cbEstado.Items.Clear();
            txtMotor.Clear();
            PicFoto.Image = Properties.Resources.brands;


        }
        private void Desactivar()
        {

            cbMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtColor.Enabled = false;
            txtKilom.Enabled = false;
            txtDimenc.Enabled = false;
            txtmatricula.Enabled = false;
            txtYear.Enabled = false;
            cbCapacidad.Enabled = false;
            cbCilindros.Enabled = false;
            cbEstado.Enabled = false;
            txtMotor.Enabled = false;
            txtPrecio.Enabled = false;

        }
        private void Activar()
        {
            txtID.Enabled = true;
            cbMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtColor.Enabled = true;
            txtKilom.Enabled = true;
            txtDimenc.Enabled = true;
            txtmatricula.Enabled = true;
            txtYear.Enabled = true;
            cbCapacidad.Enabled = true;
            cbCilindros.Enabled = true;
            cbEstado.Enabled = true;
            txtMotor.Enabled = true;
            txtPrecio.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Activar();
            Limpiar();
            RellenarCB(cbMarca, marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            RellenarCB(cbEstado, estado);
            int nuevoNumero = ObtenerSiguienteNumero();
            txtID.Text = nuevoNumero.ToString();
            txtID.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo;
            int suplidor;
            Int32.TryParse(txtSup.Text, out suplidor);
            Int32.TryParse(txtID.Text, out codigo);

            conn.Open();
            string cBuscar = "select Marca,Modelo,Photo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year,Precio from " +
                "vehiculo where idvehiculo= " + codigo + " and idsuplidor= " + suplidor;
            MySqlCommand comando = new MySqlCommand(cBuscar, conn);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                byte[] imageData = (byte[])reader["Photo"];

                // Convierte los datos de la imagen a un objeto Image.
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image imagen = Image.FromStream(ms);

                    // Asigna la imagen al PictureBox.
                    PicFoto.Image = imagen;
                }
                cbMarca.Text = reader["Marca"].ToString();
                txtModelo.Text = reader["Modelo"].ToString();
                txtmatricula.Text = reader["Matricula"].ToString();
                txtMotor.Text = reader["Motor"].ToString();
                cbCilindros.Text = reader["Cilintros"].ToString();
                cbCapacidad.Text = reader["Capacidad"].ToString();
                txtColor.Text = reader["Color"].ToString();
                txtKilom.Text = reader["Kilometraje"].ToString();
                txtDimenc.Text = reader["Dimensiones"].ToString();
                cbEstado.Text = reader["Estado"].ToString();
                txtYear.Text = reader["Year"].ToString();
                txtPrecio.Text = reader["Precio"].ToString();
            }
            else
            {
                MessageBox.Show("Codigo no encontrado");
            }
            conn.Close();
        }
        private void cargarDatos()
        {
            conn.Open();
            int suplidor;
            Int32.TryParse(txtSup.Text, out suplidor);
            string cMostrar = "select idvehiculo,Photo,Marca,Modelo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year,Precio from vehiculo where idsuplidor=" + suplidor;

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cMostrar, conn))
            {

                DataSet ds = new DataSet();
                adapter.Fill(ds, "vehiculo");
                dgvModif.DataSource = ds.Tables["vehiculo"];
            };
            conn.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            conn.Open();
            int vehiculo = Convert.ToInt32(txtID.Text);
            string delete = "delete vehiculo from vehiculo where idvehiculo=" + vehiculo;
            MySqlCommand cmd = new MySqlCommand(delete, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vehiculo eliminado exitosamente");
            conn.Close();
            Limpiar();
            RellenarCB(cbMarca, marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            RellenarCB(cbEstado, estado);
            txtID.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Activar();
        }
        private int ObtenerSiguienteNumero()
        {

            conn.Open();

            string query = "SELECT COALESCE(MAX(idvehiculo), 0) + 1 FROM vehiculo";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {

                object resultado = command.ExecuteScalar();
                int siguienteNumero = Convert.ToInt32(resultado);
                conn.Close();
                return siguienteNumero;

            }

        }
    }
}
