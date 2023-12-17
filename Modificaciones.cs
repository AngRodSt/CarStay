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
using MySql.Data.MySqlClient;
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
            for(int i = 0; i < cad.Length; i++)
            {
                cb.Items.Add(cad[i]);
            }
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Modificaciones_Load(object sender, EventArgs e)
        {
            cargarDatos();
            RellenarCB(cbMarca,marca);
            RellenarCB(cbCilindros, cilindros);
            RellenarCB(cbCapacidad, capacidad);
            RellenarCB(cbEstado, estado);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files|*.*|Image Files|*.jpg";
            ofd.Title = "Selecciona una imagen";

            if(ofd.ShowDialog()!= DialogResult.Cancel ) 
            {
                PicFoto.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            byte[] imageData=null;
           try
           {
                if(PicFoto.Image != null )
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        PicFoto.Image.Save(ms, PicFoto.Image.RawFormat);
                        imageData = ms.ToArray();   
                    }
                }
                else
                {
                    PicFoto.Image = Properties.Resources.ImagenPredeterminada;
                }

                int codigo;
                int suplidor;
                Int32.TryParse(txtSup.Text, out suplidor);
                Int32.TryParse(txtID.Text, out codigo);
                string Guardar = "insert into vehiculo (idvehiculo,idsuplidor,Photo,Marca," +
                    "Modelo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year) " +
                    "value (@codigo,@suplidor,@photo,@marca,@modelo,@matricula,@motor,@cili,@capacidad,@color,@Kilom,@dimensiones,@estado,@year)";
                using (MySqlCommand comando = new MySqlCommand(Guardar, conn))
                {

               
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.Add("@photo",MySqlDbType.LongBlob).Value = imageData;
                    comando.Parameters.AddWithValue("@suplidor", suplidor);
                    comando.Parameters.AddWithValue("@marca",cbMarca.SelectedItem);
                    comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                    comando.Parameters.AddWithValue("@matricula", txtmatricula.Text);
                    comando.Parameters.AddWithValue("@motor",txtMotor.Text);
                    comando.Parameters.AddWithValue("@cili",cbCilindros.SelectedItem);
                    comando.Parameters.AddWithValue("@capacidad",cbCapacidad.SelectedItem);
                    comando.Parameters.AddWithValue("@color",txtColor.Text);
                    comando.Parameters.AddWithValue("@Kilom",txtKilom.Text);
                    comando.Parameters.AddWithValue("@dimensiones",txtDimenc.Text);
                    comando.Parameters.AddWithValue("@estado", cbEstado.SelectedItem);
                    comando.Parameters.AddWithValue("@year",txtYear.Text);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Datos Guardados Exitosamente");
                    Limpiar();
                    RellenarCB(cbMarca, marca);
                    RellenarCB(cbCilindros, cilindros);
                    RellenarCB(cbCapacidad, capacidad);
                    RellenarCB(cbEstado, estado);
                    cargarDatos();

                } ;
            }
            catch(Exception ex)
            {
               Console.WriteLine("Error"+ ex.Message);
            }
            conn.Close();

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
            PicFoto.Image= null;

            
        }
        private void Desactivar()
        {
           
            cbMarca.Enabled=false;
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
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo;
            int suplidor;
            Int32.TryParse(txtSup.Text, out suplidor);
            Int32.TryParse(txtID.Text, out codigo);
            conn.Open();
            string cBuscar = "select Marca,Modelo,Photo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year from " +
                "vehiculo where idvehiculo= "+codigo+ " and idsuplidor= "+suplidor ;
            MySqlCommand comando = new MySqlCommand(cBuscar,conn);
            MySqlDataReader reader = comando.ExecuteReader();
            if(reader.Read())
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
                txtColor.Text= reader["Color"].ToString();
                txtKilom.Text = reader["Kilometraje"].ToString();
                txtDimenc.Text = reader["Dimensiones"].ToString();
                cbEstado.Text = reader["Estado"].ToString();
                txtYear.Text= reader["Year"].ToString();
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
            string cMostrar = "select Photo,Marca,Modelo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year from vehiculo where idsuplidor=" + suplidor;

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cMostrar, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds, "vehiculo");
                dgvModif.DataSource = ds.Tables["vehiculo"];
            } ;
            conn.Close();
        }
    }
}
