
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace RegistrationSystemChanger
{
	public class SqlHerramientas
	{
		private static SqlHerramientas instancia;
        FileWriter fr = new FileWriter();

        private SqlConnection sqlConnection;

		public static SqlHerramientas Instancia
		{
			get
			{
				if (SqlHerramientas.instancia == null)
				{
					SqlHerramientas.instancia = new SqlHerramientas();
				}
				return SqlHerramientas.instancia;
			}
		}

		private SqlHerramientas()
		{
            string connectionString = Properties.Settings.Default.SqlConnectionString;
			this.sqlConnection = new SqlConnection(connectionString);
		}

		public string ObtenerUnValor(string consulta)
		{
			SqlCommand comm = new SqlCommand(consulta, this.sqlConnection);
			comm.Connection.Open();
			string result;
			try
			{
				consulta = comm.ExecuteScalar().ToString();
				comm.Connection.Close();
				result = consulta;
			}
			catch (Exception ex)
			{
				comm.Connection.Close();
                fr.WriteFile(ex.Message);
                result = null;
			}
			return result;
		}

		

		
		public bool ExisteDatos(string consulta)
		{
			SqlCommand comm = new SqlCommand(consulta, this.sqlConnection);
			bool result;
			try
			{
				comm.Connection.Open();
				object resultadoConsulta = comm.ExecuteScalar();
				comm.Connection.Close();
				result = (resultadoConsulta != null);
			}
			catch (Exception ex)
			{
				comm.Connection.Close();
                fr.WriteFile(ex.Message);
				result = false;
			}
			return result;
		}

		public SqlHerramientaEstatud Ejecutar(string consulta)
		{
			SqlCommand adjunt = new SqlCommand(consulta, this.sqlConnection);
			SqlHerramientaEstatud sqlHerramientaEstatud = new SqlHerramientaEstatud();
			adjunt.Connection.Open();
			try
			{
				adjunt.ExecuteNonQuery();
				sqlHerramientaEstatud.FueExitoso = true;
			}
			catch (Exception ex)
			{
				sqlHerramientaEstatud.FueExitoso = false;
				if (ex.InnerException != null)
				{
					sqlHerramientaEstatud.Descripcion = ex.InnerException.Message;
				}
				fr.WriteFile(ex.Message);
			}
			adjunt.Connection.Close();
			return sqlHerramientaEstatud;
		}

		public bool ConexionValida()
		{
			bool conexionValida = false;
			try
			{
				this.sqlConnection.Open();
				conexionValida = true;
			}
			catch (Exception ex)
			{
                
                fr.WriteFile(ex.Message);
				

			}
			finally
			{
				this.sqlConnection.Close();
			}
			return conexionValida;
		}

		

		public SqlConnectionStringBuilder GetConnectionInfo()
		{
			return new SqlConnectionStringBuilder(this.sqlConnection.ConnectionString);
		}

		
	}
}
