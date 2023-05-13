using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Proyecto_09
{
	internal class Conectar
	{
		public Conectar()
		{
		}

		public static MySqlConnection Conecta()
		{
			MySqlConnection mySqlConnection;
			string servidor = "localhost";
			string db = "proyecto";
			string usuario = "root";
			string password = "usbw";
			string ruta = string.Concat(new string[] { "DataBase=", db, ";Data Source=", servidor, ";User Id=", usuario, ";Password=", password, ";port=3307" });
			try
			{
				mySqlConnection = new MySqlConnection(ruta);
			}
			catch (Exception exception)
			{
				Exception ex = exception;
				MessageBox.Show(string.Concat("Error al conectar con la base de datos: ", ex.Message));
				mySqlConnection = null;
			}
			return mySqlConnection;
		}
	}
}