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
        public string log;
        public string Query;

        public Service1()
        {
            InitializeComponent();
            fecha = DateTime.Today;
            Query = "UPDATE Colegios " +
                "SET fechaRegistro = {0}  where idColegio = 01";



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
