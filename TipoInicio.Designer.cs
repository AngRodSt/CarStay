namespace CarStay
{
    partial class TipoInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoInicio));
            this.btnCLiente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnProvedor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCLiente
            // 
            this.btnCLiente.BackColor = System.Drawing.SystemColors.Control;
            this.btnCLiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCLiente.BackgroundImage")));
            this.btnCLiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCLiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCLiente.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLiente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCLiente.Location = new System.Drawing.Point(202, 622);
            this.btnCLiente.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCLiente.Name = "btnCLiente";
            this.btnCLiente.Size = new System.Drawing.Size(358, 69);
            this.btnCLiente.TabIndex = 13;
            this.btnCLiente.Text = "CLIENTE";
            this.btnCLiente.UseVisualStyleBackColor = false;
            this.btnCLiente.Click += new System.EventHandler(this.btnCLiente_Click);
            this.btnCLiente.MouseEnter += new System.EventHandler(this.btnCLiente_MouseEnter);
            this.btnCLiente.MouseLeave += new System.EventHandler(this.btnCLiente_MouseLeave);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(543, 82);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(202, 45);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // btnProvedor
            // 
            this.btnProvedor.BackColor = System.Drawing.SystemColors.Control;
            this.btnProvedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProvedor.BackgroundImage")));
            this.btnProvedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProvedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProvedor.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProvedor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProvedor.Location = new System.Drawing.Point(202, 542);
            this.btnProvedor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnProvedor.Name = "btnProvedor";
            this.btnProvedor.Size = new System.Drawing.Size(358, 69);
            this.btnProvedor.TabIndex = 11;
            this.btnProvedor.Text = "PROVEEDOR";
            this.btnProvedor.UseVisualStyleBackColor = false;
            this.btnProvedor.Click += new System.EventHandler(this.btnProvedor_Click);
            this.btnProvedor.MouseEnter += new System.EventHandler(this.btnProvedor_MouseEnter);
            this.btnProvedor.MouseLeave += new System.EventHandler(this.btnProvedor_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(68, 82);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(637, 471);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // TipoInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 752);
            this.Controls.Add(this.btnCLiente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProvedor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TipoInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TipoInicio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCLiente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnProvedor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}