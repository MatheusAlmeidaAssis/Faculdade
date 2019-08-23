using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dos.UI.Controls
{
    sealed class DataBase : IDisposable
    {
        static DataBase _instancia;
        private Select _select;
        public SqlConnection Con { get; }
        public Select Select
        {
            get
            {
                if (_select == null)
                    _select = new Select();
                return _select;
            }
        }
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
