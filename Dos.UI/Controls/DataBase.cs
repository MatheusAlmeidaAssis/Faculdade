using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dos.UI.Controls
{
    sealed class DataBase : IDisposable
    {        
        static DataBase _instancia;
        public SqlConnection Con { get;}
        public static DataBase GetDataBase
        {
            get { return _instancia ?? (_instancia = new DataBase()); }
        }
        public DataBase()
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Faculdade"].ConnectionString);
            Con.Open();
        }
        public void Dispose()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
        }
    }
}
