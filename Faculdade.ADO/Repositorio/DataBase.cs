using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Faculdade.ADO.Repositorio
{
    internal sealed class DataBase : IDisposable
    {
        static DataBase _instancia;
        private Select _select;
        public SqlConnection Con { get; }
        public Select Select => _select ?? (_select = new Select());
        public static DataBase GetDataBase => _instancia ?? (_instancia = new DataBase());
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
