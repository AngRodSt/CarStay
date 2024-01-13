using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarStay
{
    public partial class SolicitudV : Form
    {
        string codigo;
        string idcliente;
        string idsuplidor;

        ConsultaCliente1 menuP;


        MySqlConnection conn;
        string[] retiro = { "AEROPUERTO INTERNACIONAL LAS AMERICAS", "AEROPUERTO INTERNACIONAL DEL CIBAO", "AEROPUERTO INTERNACIONAL DE PUNTA CANA", "OFICINA LOCAL" };

        public SolicitudV(string codigo1, string cliente)
        {
            codigo = codigo1;

            idcliente = cliente;
            InitializeComponent();
            Conexion conexion = new Conexion();
            conexion.conec();
            string cadena = conexion.cadena;
            conn = new MySqlConnection(cadena);
            menuP = new ConsultaCliente1(idcliente);
        }

        private void RellenarCB(ComboBox cb, string[] cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                cb.Items.Add(cad[i]);
            }
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SolicitudV_Load(object sender, EventArgs e)
        {
            txtContrato.Text = "Carstay facilita el arriendameinto de vehículos con sujeción a los términos y condiciones establecidos por el presente contrato. El arrendatario se considera informado del contenido. Es nuestro propósito que todos los términos queden aquí recogidos. Rogamos lo lea detenidamente " +
                "y si no entendiera o no estuviera conforme en alguno de los puntos lo haga saber antes de aceptarlo\r\n \r\n\r\nEntrega y Devolución\r\nCarstay garantiza la entrega del vehículo en buen estado general y de funcionamiento y carente de defectos aparentes. Usted se obliga a devolverlo en el mismo " +
                "estado con todos los documentos, piezas y accesorios en el lugar, en fecha y horas señalados en este contrato. Cualquier alteración deberá ser previamente autorizada por Carstay \r\n\r\nA traves de Carstay este podrá volver a tomar posesión del vehículo en cualquier momento sin previo aviso y" +
                " a su propia costa si el vehículo se utilizara incumpliendo lo establecido en este contrato.\r\n\r\nNos reservamos el derecho a cancelar la entrega del vehículo por antecedentes de éste de impagos o incidentes graves con volandorentcar.com\r\n\r\nUtilización del vehículo\r\nEl arrendatario se compromete a utilizar el vehículo de acuerdo a las normas del código de circulación. Además, debe conservarlo en buen estado, asegurarse de que permanezca cerrado cuando no lo usa, utilizar el combustible correcto y poner en funcionamiento los mecanismos de seguridad instalados en caso necesario. Queda expresamente prohibido y, por tanto, se considerará incumplimiento de contrato:\r\n\r\n(a) " +
                "Subarrendar el vehículo.\r\n\r\n(b) Transportar mercancías\r\n\r\n(c) Empujar o remolcar cualquier vehículo, tráiler u otro objeto.\r\n\r\n(d) Participar en carreras, rallies, pruebas u otros concursos similares.\r\n\r\n(e) Conducir bajo los efectos del alcohol, drogas o cualquier otra sustancia que afecte a la consciencia o capacidad de reacción.\r\n\r\n(f) Cometer cualquier tipo de delito contra la seguridad de vial.\r\n\r\n(g) Conducir el vehículo personas no autorizadas en el anverso del contrato. En tales casos, también se responsabiliza usted del vehículo de acuerdo con este contrato.\r\n\r\n(h) Si no cumple los requisitos mínimos estipulados en nuestra lista de tarifas vigentes " +
                "sobre edad (min 20 años) y posesión de permiso de conducir vigente y original del mismo (min 2 años).\r\n\r\n(k) Conducir en zonas restringidas: pistas de aeropuerto y zonas asociadas, vías no aptas para la circulación (son vías aptas las de dominio público, garajes o aparcamientos y las privadas no destinadas al uso industrial o agrícola). Zonas prohibidas o peligrosas (playas, barrancos, montañas, etc…) carreteras sin asfaltar y otras vías que deterioren el estado de los neumáticos o puedan dañar los bajos del vehículo.\r\n\r\nMultas, Sanciones, Servicio de Grúas y gastos de gestión como paralización del vehículo por infracciones de tráfico o infracciones de Leyes, Reglamentos u Ordenanzas," +
                " roturas de llantas, neumáticos y gasolina son a cargo del arrendatario.\r\nCargos del Alquiler\r\nEl arrendatario acepta pagar el precio del alquiler según tarifa e impuestos vigentes, seguros (contemplado en punto 4), demora por devolución del vehículo (a partir de 59 minutos después de la hora prevista), combustible consumido, repostaje, cargos adicionales como:\r\n\r\n– Entrega en aeropuerto (Tarifa que corresponda)\r\n\r\n– Pérdida de accesorios adicionales y documentos (Tarifa que corresponda)\r\n\r\n– Entrega en Parking privados (Tarifa que corresponda)\r\n\r\n– Reposición de llaves (Tarifa que corresponda)\r\n\r\n– Limpieza del vehículo por exceso de suciedad (Tarifa que corresponda)\r\n\r\n5.- " +
                "Accidentes\r\n\r\nEl arrendatario deberá tomar las siguientes medidas en caso de accidente:\r\n\r\na) Obligación de comunicar cualquier accidente de tráfico, pérdida, daños o robo a Carstay y a la policía, inmediatamente.\r\nb) No reconocer o prejuzgar la responsabilidad del hecho.\r\nc) Obtener datos completos de la parte contraria, que remitirá urgentemente a volandorentcar.com Se obliga a colaborar con nosotros y con nuestra compañía de seguros en cualquier investigación o posteriores procedimientos legales. Si no cumple dicha solicitud, todas las coberturas aceptadas y pagadas resultarán nulas.\r\n6.- Reparaciones\r\n\r\nEl arrendador se hará cargo de los gastos habidos durante el arrendamiento por engrases," +
                " cambios de aceite, agua y pequeñas reparaciones (excepto pinchazos) hasta un máximo de 10€. Éstas deberán de justificarse con los oportunos recibos o facturas. Será indispensable obtener la previa autorización del arrendador para efectuar reparaciones o remolcar el vehículo.\r\n\r\n7.- Nuestra responsabilidad\r\n\r\nCarstay declara haber tomado las debidas precauciones para evitar fallos mecánicos del vehículo. En caso de producirse estos, nos responsabilizamos de los daños sufridos por usted en caso de fallecimiento o lesiones. El arrendador no asume ninguna responsabilidad por los perjuicios que directa o indirectamente pudieran causarle al arrendatario como consecuencia de fallos o averías fortuitas.\r\n\r\n8.- " +
                "Condiciones\r\n\r\nEdad mínima para alquilar vehículos es de 20 años y antigüedad de carnet de conducir 2 años.\r\n\r\nKilometraje ilimitado\r\n\r\nSegundo conductor sin cargo adicional\r\n\r\nEntrega en aeropuerto: Mínimo 3 días\r\n\r\n9.- Sistemas de Retención Infantil\r\n\r\nvolandorentcar.com facilitará al cliente que lo solicite sillas de bebé, elevadores y otros suplementos homologados. El personal de Volando Rent a Car S.R.L no está autorizado a la instalación de dichos sistemas, por tanto, el arrendatario será siempre responsable del montaje y sujeción de estos accesorios en el interior del vehículo, así como de las edades de los niños que correspondan a cada sistema de retención infantil. Dejando eximida de toda responsabilidad a" +
                " Carstay de cualquier daño y/o perjuicio que pudiera sufrir el usuario de dichos sistemas.\r\n\r\n10.- Datos personales\r\n\r\nLA Protección de Datos de Carácter Personal, informamos que los datos personales que nos ha facilitado, serán tratados e incluidos automatizadamente en nuestros ficheros con la única finalidad de llevar a cabo gestiones relacionadas con nuestra actividad. volandorentcar.com garantiza la confidencialidad y el buen uso de la información y adoptará medidas de seguridad, de índole técnica y organizativa, necesaria y exigida para garantizarlo.";
            int numeracion = ObtenerSiguienteNumero();

            txtID.Text = numeracion.ToString();

            RellenarCB(cbRetiro, retiro);
            RellenarCB(cbEntrega, retiro);

            int codigoV = Convert.ToInt32(codigo);
            conn.Open();
            string consulta = "select * from vehiculo where idvehiculo=" + codigoV;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                byte[] img = (byte[])fila["Photo"];
                MemoryStream ms = new MemoryStream(img);
                Photo.BackgroundImage = Image.FromStream(ms);
                Photo.BackgroundImageLayout = ImageLayout.Zoom;
                idsuplidor = fila["idsuplidor"].ToString();
                txtPrecio.Text = fila["Precio"].ToString();
            }
            int clienteC = Convert.ToInt32(idcliente);
            string cCliente = "select * from cliente where idcliente =" + clienteC;
            da = new MySqlDataAdapter(cCliente, conn);
            da.Fill(ds);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                txtNombre.Text = fila["nombre"].ToString();
                txtApellido.Text = fila["apellido"].ToString();
                txtCedula.Text = fila["cedula"].ToString();
                txtCorreo.Text = fila["correo"].ToString();
                txtTelefono.Text = fila["telefono"].ToString();
            }
            conn.Close();
            VerificarTotal();

        }

        private void VerificarTotal()
        {
            int alquiler = Convert.ToInt32(txtPrecio.Text);
            int extra1 = Convert.ToInt32(txtProd1.Text);
            int extra2 = Convert.ToInt32(txtProd2.Text);
            int extra3 = Convert.ToInt32(txtProd3.Text);
            int extra4 = Convert.ToInt32(txtPro4.Text);
            int resultado = alquiler + extra1 + extra2 + extra3 + extra4;
            txtTotal.Text = resultado.ToString();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private int ObtenerSiguienteNumero()
        {

            conn.Open();

            string query = "SELECT COALESCE(MAX(idpedidos), 0) + 1 FROM pedidos";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {

                object resultado = command.ExecuteScalar();
                int siguienteNumero = Convert.ToInt32(resultado);
                conn.Close();
                return siguienteNumero;

            }

        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            menuP.Show();
            this.Close();

        }

        private void btnAg1_Click(object sender, EventArgs e)
        {
            if (txtProd1.Text == "0" & txtNom1.Text == "")
            {
                txtNom1.Text = "Cobertura Full Cover";
                txtProd1.Text = "450";
            }
            else
            {
                txtNom1.Text = "";
                txtProd1.Text = "0";
            }
            VerificarTotal();
        }

        private void btnAg2_Click(object sender, EventArgs e)
        {
            if (txtProd2.Text == "0" & txtNom2.Text == "")
            {
                txtNom2.Text = "Cobertura Full";
                txtProd2.Text = "300";
            }
            else
            {
                txtNom2.Text = "";
                txtProd2.Text = "0";
            }
            VerificarTotal();
        }

        private void btConductor_Click(object sender, EventArgs e)
        {
            if (txtProd3.Text == "0" & txtNom3.Text == "")
            {
                txtNom3.Text = "Conductor Adicional";
                txtProd3.Text = "100";
            }
            else
            {
                txtNom3.Text = "";
                txtProd3.Text = "0";
            }
            VerificarTotal();

        }

        private void btnAsiento_Click(object sender, EventArgs e)
        {
            if (txtPro4.Text == "0" & txtNom4.Text == "")
            {
                txtPro4.Text = "50";
                txtNom4.Text = "Asiento Adicional";
            }
            else
            {
                txtPro4.Text = "0";
                txtNom4.Text = "";
            }
            VerificarTotal();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pContrato.Visible = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int estado = 1;
            int codigoP = Convert.ToInt32(txtID.Text);
            int codigoV = Convert.ToInt32(codigo);
            int codigoS = Convert.ToInt32(idsuplidor);
            int codigoC = Convert.ToInt32(idcliente);
            int total = Convert.ToInt32(txtTotal.Text);
            int extra1 = Convert.ToInt32(txtProd1.Text);
            int extra2 = Convert.ToInt32(txtProd2.Text);
            int extra3 = Convert.ToInt32(txtProd3.Text);
            int extra4 = Convert.ToInt32(txtPro4.Text);
            DateTime dtRetiro1 = dtRetiro.Value;
            DateTime dtEntrega1 = dtEntrega.Value;
            conn.Open();
            string cGuardar = "insert into pedidos (idpedidos, idvehiculo, idsuplidor, idcliente, retiro, entrega, fechaR, fechaE," +
                "total,extra1,extra2,extra3, extra4, estado, direccion) value (@idpedidos, @idvehiculo, @idsuplidor, @idcliente, " +
                "@retiro, @entrega, @fechaR, @fechaE,@total,@extra1,@extra2,@extra3, @extra4, @estado, @direccion)";
            using (MySqlCommand cmd = new MySqlCommand(cGuardar, conn))
            {
                cmd.Parameters.AddWithValue("@idpedidos", codigoP);
                cmd.Parameters.AddWithValue("@idvehiculo", codigoV);
                cmd.Parameters.AddWithValue("@idsuplidor", codigoS);
                cmd.Parameters.AddWithValue("@idcliente", codigoC);
                cmd.Parameters.AddWithValue("@retiro", cbRetiro.SelectedItem).ToString();
                cmd.Parameters.AddWithValue("@entrega", cbEntrega.SelectedItem).ToString();
                cmd.Parameters.AddWithValue("@fechaR", dtRetiro1.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@fechaE", dtEntrega1.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@extra1", extra1);
                cmd.Parameters.AddWithValue("@extra2", extra2);
                cmd.Parameters.AddWithValue("@extra3", extra3);
                cmd.Parameters.AddWithValue("@extra4", extra4);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Pedido realizado exitosamente");
            this.Hide();
            menuP.Show();

        }

        private void btnRegresarC_Click(object sender, EventArgs e)
        {
            pContrato.Visible = false;
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.Navy;
            btnGuardar.ForeColor = Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = SystemColors.Control;
            btnGuardar.ForeColor = Color.Black;
        }
    }
}
