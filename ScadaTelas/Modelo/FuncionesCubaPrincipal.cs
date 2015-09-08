using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ScadaTelas.Modelo
{
    public abstract class FuncionesCubaPrincipal
    {
        
    }

    public class SubProcesoCubaPrincipal
    {
        /* Valores definidos */
        public static int NIVELBAJO = 0, NIVELMEDIO = 1, NIVELALTO = 2;
        public static string MLLENAR = "M200", MLLENADO = "M204", MNIVELES = "M203", MRECIRCULACION = "M208";
        public static string RNIVEL = "R60", RTCIRCULACION = "R62";
        public static int LLENADO = 1, CALENTADO = 2, ENFRIADO = 3, VACIADO = 4;
        public static int MAXTEMPERATURA = 100;
        public static int MINTEMPERATURA = 0;

        /*Valores almacenados en la base de Datos*/
        private String nombre;
        private int idSubProceso;
        private bool hNiveles = false, hRecirculacion = false;
        private int VNivel = -1, tiempoRecirculacion = 0;
        private bool calentar = false, hTiempoCalentar = false;
        private int temperaturaCalentar = -1, tiempoTemperaturaCalentar = 0;
        private bool hEnfriar;
        private int temperaturaEnfriar;
        private bool hVaciado = false, hVaciadoDirecto = false;
        private int temperaturaVaciado = -1, tiempoVaciado = 0;

        public void Llenar(bool habilitarLlenado, bool habilitarNivel, int nivel, bool habilitarRecirculacion, int tiempoRecirculacion)
        {
            this.hNiveles = habilitarNivel;
            this.VNivel = nivel;
            this.hRecirculacion = habilitarRecirculacion;
            this.tiempoRecirculacion = tiempoRecirculacion;
        }

        public void Calentar(bool calentar, int temperatura, bool habilitarTiempoCalentar, int tiempoTemperatura)
        {
            this.calentar = calentar;
            this.temperaturaCalentar = temperatura;
            this.hTiempoCalentar = habilitarTiempoCalentar;
            this.tiempoTemperaturaCalentar = tiempoTemperatura;  
        }

        public void Enfriar(bool habilitar, int temperatura)
        {
            this.hEnfriar = habilitar;
            this.temperaturaEnfriar = temperatura; 
        }

        public void Vaciar(bool habilitar, int temperatura, int tiempoVaciado, bool vaciadoDirecto)
        {
            this.hVaciado = habilitar;
            this.temperaturaVaciado = temperatura;
            this.tiempoVaciado = tiempoVaciado;
            this.hVaciadoDirecto = vaciadoDirecto; 
        }

        public static void MaximaTemperatura(int temperatura)
        {
            MAXTEMPERATURA = temperatura;
        }

        public static void minimaTemperatura(int temperatura)
        {
            MINTEMPERATURA = temperatura;
        }

        public bool validarTemperatura(int temperatura)
        {
            if ((temperatura >= MINTEMPERATURA) & (temperatura <= MAXTEMPERATURA))
            {
                return true;
            }
            return false;
        }

        public float ConvertirTemperatura(int temperatura)
        {
            return temperatura / 10;
        }

        public bool validarNivel(int nivel)
        {
            if ((nivel >= 0) & (nivel <=3)){
                return true;
            }
            return false;
        }

        public bool guardarSubProceso(MySqlConnection conexion)
        {
            conexion.BeginTransaction();
            MySqlCommand comando = new MySqlCommand("insert into SubProceso (nombre, llenado, hNivel, hRecirculacion, htiempoRecirculacion," +
                                                     "calentar, hTiempoCalentar, enfriar, temperaturaEnfriar, hVaciado, temperaturaVaciado, tiempoVaciado, vaciadoDirecto) values"+
                                                    "(@idSubProceso, @nombre, @llenar, @hNivel, @hRecirculacion, @htiempoRecirculacion," +
                                                     "@calentar, @hTiempoCalentar, @enfriar, @temperaturaEnfriar, @vaciar, @temperaturaVaciado, @tiempoVaciado, @vaciadoDirecto)");
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar, 50);
            comando.Parameters.Add("@llenado", MySqlDbType.Bit, 1);
            comando.Parameters.Add("@hNivel", MySqlDbType.Bit, 1);
            comando.Parameters.Add("@hRecirculacion", MySqlDbType.Bit, 1);
            comando.Parameters.Add("@htiempoRecirculacion", MySqlDbType.UInt16);
            comando.Parameters.Add("@calentar", MySqlDbType.Bit, 1);
            comando.Parameters.Add("@hTiempoCalentar", MySqlDbType.UInt16);  
            comando.Parameters.Add("@enfriar", MySqlDbType.Bit, 1); 
            comando.Parameters.Add("@temperaturaEnfriar", MySqlDbType.UInt16);
            comando.Parameters.Add("@vaciar", MySqlDbType.Bit, 1);
            comando.Parameters.Add("@temperaturaVaciado", MySqlDbType.UInt16);
            comando.Parameters.Add("@tiempoVaciado", MySqlDbType.UInt16); 
            comando.Parameters.Add("@vaciadoDirecto", MySqlDbType.Bit, 1);
            comando.Prepare();
            comando.Parameters[@nombre].Value = d
            try 
            {
                conexion.Open();

            }catch (MySqlException ex) {

            }finally 
            {  
              if (conexion != null) 
              {
                  conexion.Close();
              }
            }
            comando.BeginExecuteNonQuery();
        }
    }
}
