﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStay
{
    public partial class TipoInicio : Form
    {
        public TipoInicio()
        {
            InitializeComponent();
        }

        private void btnProvedor_Click(object sender, EventArgs e)
        {
            Login logear = new Login();
            logear.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //FUNCION PARA QUE LOS BOTONES CAMBIEN DE COLOR AL PASARLE EL MOUSE POR ENCIMA
        public void Marcar(Button button)
        {
            button.BackColor = Color.LightCoral;
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = null;
        }
        //FUNCION PARA QUE RECUPEREN SU COLOR NORMAL AL QUITAR EL MOUSE
        public void Desmarcar(Button button)
        {
            button.BackColor = SystemColors.Control;
            button.ForeColor = System.Drawing.Color.White;
            button.BackgroundImage = Image.FromFile(@"C:\Users\AngRod\source\repos\CarStay\imagenes\6222603.jpg");
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void btnProvedor_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnProvedor);
        }

        private void btnProvedor_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnProvedor);
        }

        private void btnCLiente_MouseEnter(object sender, EventArgs e)
        {
            Marcar(btnCLiente);
        }

        private void btnCLiente_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnCLiente);
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {   
            Marcar(btnSalir);

        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            Desmarcar(btnSalir);
        }
    }
    }

