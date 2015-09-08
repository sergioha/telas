using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ScadaTelas.Modelo
{
    class ServidorDB
    {
        string usuario, contrasena, baseDeDatos, cadenaConexion;
        MySqlConnection conexion;

        public ServidorDB(string usuario, string contrasena, string baseDeDatos)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.baseDeDatos = baseDeDatos;
            this.cadenaConexion = "SERVER=localhost;" + "DATABASE=" + this.baseDeDatos + 
                               ";" + "UID=" + this.usuario + ";" + "PASSWORD=" + this.contrasena + ";";
        }

        public bool conectar()
        {
            try
            {
                this.conexion = new MySqlConnection(cadenaConexion);
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        private int AbrirConexion(String mensaje)
        {
            try
            {
                conexion.Open();
                return 1;
            }
            catch (MySqlException ex)
            {
                //0: nose puede conectar servidor.
                //1045: Error en el nombre de usuario o contrasena.
                //    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator")
                //    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                return ex.Number;
            }
        }

        private bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
