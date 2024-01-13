using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarStay
{
    public partial class CARSTAY : Form
    {
        public int idsuplidor;

        public CARSTAY(int idSuplidor)
        {
            InitializeComponent();
            btnvehiculo.FlatAppearance.BorderSize = 10;
            btnvehiculo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 15, 255, 255);
            this.idsuplidor = idSuplidor;
            txtSup.Text = idsuplidor.ToString();

        }

        //FUNCION PARA QUE LOS BOTONES CAMBIEN DE COLOR AL PASARLE EL MOUSE POR ENCIMA
        public void Marcar(Button button)
        {
            button.BackColor = Color.Navy;
            button.ForeColor = System.Drawing.Color.White;
        }
        //FUNCION PARA QUE RECUPEREN SU COLOR NORMAL AL QUITAR EL MOUSE
        public void Desmarcar(Button button)
        {
            button.BackColor = SystemColors.Control;
            button.ForeColor = System.Drawing.Color.Black;
        }
        //AL HACER CLICK EN VEHICULO SE ABRA EL APARTADO
        private void btnvehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo ver = new Vehiculo(idsuplidor);
            ver.Show();
            this.Hide();
        }
        //SALIR DEL FORM
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            TipoInicio tipoInicio = new TipoInicio();
            tipoInicio.Close();
        }

        //APLICANDO LA FUNCION A LOS BOTONES DEL FORM
        private void btnvehiculo_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnvehiculo);
        }

        private void btnvehiculo_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnvehiculo);
        }

        private void btnPedidos_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnPedidos);
        }

        private void btnPedidos_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnPedidos);
        }


        private void btnTransaccion_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnUsuario);
        }

        private void btnTransaccion_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnUsuario);
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnSalir);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnSalir);
        }
        //FIN DECLARACION DE COLOR A LOS BOTONES

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            PedidosSuplidor pedidos = new PedidosSuplidor(idsuplidor);
            pedidos.Show();
            this.Hide();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            EditRegSuplidorescs update = new EditRegSuplidorescs(idsuplidor);
            update.Show();
            this.Hide();
        }
    }
}
