using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStay
{
    internal class ConexionW
    {
        //Creacion variables para almacener los datos
        string servidor, clave, bd, usuario;
        public string cadena;

        //Metodo para asignar los valores a nuestras variables que almacenaran nuestra cadena de conexion
        public void conec()
        {
            servidor = "192.168.1.13";
            usuario = "Windows";
            clave = "1234";
            bd = "carstay";

            //concatenacion de los datos
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + bd;
        }
    }
}
