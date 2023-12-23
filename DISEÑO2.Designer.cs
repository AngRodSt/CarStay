namespace CarStay
{
    partial class CARSTAY
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CARSTAY));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnvehiculo = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-55, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 202);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnvehiculo
            // 
            this.btnvehiculo.BackColor = System.Drawing.SystemColors.Control;
            this.btnvehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnvehiculo.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvehiculo.Location = new System.Drawing.Point(25, 40);
            this.btnvehiculo.Margin = new System.Windows.Forms.Padding(5);
            this.btnvehiculo.Name = "btnvehiculo";
            this.btnvehiculo.Size = new System.Drawing.Size(230, 91);
            this.btnvehiculo.TabIndex = 1;
            this.btnvehiculo.Text = "VEHICULOS";
            this.btnvehiculo.UseVisualStyleBackColor = false;
            this.btnvehiculo.Click += new System.EventHandler(this.btnvehiculo_Click);
            this.btnvehiculo.MouseLeave += new System.EventHandler(this.btnvehiculo_MouseLeave);
            this.btnvehiculo.MouseHover += new System.EventHandler(this.btnvehiculo_MouseEnter);
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackColor = System.Drawing.SystemColors.Control;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPedidos.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidos.Location = new System.Drawing.Point(265, 40);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(5);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(230, 91);
            this.btnPedidos.TabIndex = 2;
            this.btnPedidos.Text = "PEDIDOS";
            this.btnPedidos.UseVisualStyleBackColor = false;
         
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.BackColor = System.Drawing.SystemColors.Control;
            this.btnTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransacciones.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransacciones.Location = new System.Drawing.Point(505, 40);
            this.btnTransacciones.Margin = new System.Windows.Forms.Padding(5);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Size = new System.Drawing.Size(248, 91);
            this.btnTransacciones.TabIndex = 3;
            this.btnTransacciones.Text = "TRANSACCIONES";
            this.btnTransacciones.UseVisualStyleBackColor = false;
            this.btnTransacciones.MouseEnter += new System.EventHandler(this.btnUsuario_MouseEnter);
            this.btnTransacciones.MouseLeave += new System.EventHandler(this.btnUsuario_MouseLeave);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuario.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Location = new System.Drawing.Point(771, 40);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(229, 91);
            this.btnUsuario.TabIndex = 4;
            this.btnUsuario.Text = "USUARIO";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.MouseEnter += new System.EventHandler(this.btnTransaccion_MouseEnter);
            this.btnUsuario.MouseLeave += new System.EventHandler(this.btnTransaccion_MouseLeave);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(810, 18);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(185, 43);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnTransacciones);
            this.panel1.Controls.Add(this.btnvehiculo);
            this.panel1.Controls.Add(this.btnUsuario);
            this.panel1.Controls.Add(this.btnPedidos);
            this.panel1.Location = new System.Drawing.Point(-5, 751);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 166);
            this.panel1.TabIndex = 6;
            // 
            // txtSup
            // 
            this.txtSup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.15584F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSup.Location = new System.Drawing.Point(729, 28);
            this.txtSup.Margin = new System.Windows.Forms.Padding(5);
            this.txtSup.Name = "txtSup";
            this.txtSup.Size = new System.Drawing.Size(69, 30);
            this.txtSup.TabIndex = 240;
            // 
            // CARSTAY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1015, 917);
            this.Controls.Add(this.txtSup);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CARSTAY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARSTAY";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnvehiculo;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnTransacciones;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox txtSup;
    }
}