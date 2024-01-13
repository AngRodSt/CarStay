namespace CarStay
{
    internal class Conexion
    {
        //Creacion variables para almacener los datos
        string servidor, clave, bd, usuario;
        public string cadena;

        //Metodo para asignar los valores a nuestras variables que almacenaran nuestra cadena de conexion
        public void conec()
        {
            servidor = "127.0.0.1";
            usuario = "root";
            clave = "angrod0713";
            bd = "carstay";

            //concatenacion de los datos
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + bd;
        }
    }
}
