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
        int idSuplidor;
        MySqlConnection conn;
        string[] estado = { "En uso", "Disponible", "Mantenimiento", "Fuera de Servicio", "Nuevo" };
        string[] capacidad = { "1", "2", "4", "5", "8" };
        string[] cilindros = { "I4", "V6", "V8", "V10", "V12", "V16", "MOTOR ELECTRICO" };
        string[] marca = {"TOYOTA","FORD","CHEVROLET","VOLKSWAGEN","HONDA","MERCEDES-BENZ","BMW",
            "FERRARI","NISSAN","TESLA","AUDI","HYUNDAI","KIA","MEZDA","SUBARU","JEEP","LAND ROVER","JAGUAR","PORSCHE","ACURA","VOLVO","LAMBORGHINI"};
        public Modificaciones()
        {
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
        }
        public Modificaciones(int idSuplidor)
        {
            this.idSuplidor = idSuplidor;
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
            byte[] imageData = null;
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
                int codigo;
                Int32.TryParse(txtID.Text, out codigo);
                string Guardar = "insert into vehiculo (idvehiculo,idsuplidor,Photo,Marca," +
                    "Modelo,Matricula,Motor,Cilintros,Capacidad,Color,Kilometraje,Dimensiones,Estado,Year) " +
                    "value (@codigo,@suplidor,@photo,@marca,@modelo,@matricula,@motor,@cili,@capacidad,@color,@Kilom,@dimensiones,@estado,@year)";
                using (MySqlCommand comando = new MySqlCommand(Guardar, conn))
                {
                    
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.Add("@photo",MySqlDbType.Binary).Value = imageData;
                    comando.Parameters.AddWithValue("@suplidor", idSuplidor);
                    
                } ;
            }
            catch
            {

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
