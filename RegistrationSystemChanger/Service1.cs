using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;


namespace RegistrationSystemChanger
{
    public partial class Service1 : ServiceBase
    {
        public Timer tiempo;
        public DateTime fecha;
        public string fechastr;
        public int dia;
        public string log;
        public string Query;
        SqlHerramientas sqlherramientas;


        public Service1()
        {
            InitializeComponent();
            sqlherramientas = SqlHerramientas.Instancia;

            fecha = DateTime.Today.Date;
            dia = Int32.Parse(fecha.Day.ToString() ) - 1;
            fechastr = dia + "/"+fecha.Month.ToString() + "/"  + fecha.Year.ToString();
            //Estos datos provienen de un archivo de configuracion, se debe probar su funcionalidad
            Query = string.Format("UPDATE {0} " +
                "SET {1} = {2}  where {3} = {4}",
                Properties.Settings.Default.tabla,
                Properties.Settings.Default.campo,
                fechastr,
                Properties.Settings.Default.where,
                Properties.Settings.Default.equal



            );
            sqlherramientas.Ejecutar(Query);
            tiempo = new Timer();
        }

        private void EscribirLog(string filename)
        {

        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
