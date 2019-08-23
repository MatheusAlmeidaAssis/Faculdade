using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace Dos.UI.Controls
{
    class Insert
    {
        private SqlCommand _cmdInsert;
        public List<string> Campos { get; set; }
        public string Tabela { get; set; }
        public List<string> Valores { get; set; }
        public Insert()
        {
            Campos = new List<string>();
            Tabela = string.Empty;
            Valores = new List<string>();
        }

        public SqlCommand Command()
        {
            if (_cmdInsert == null)
                _cmdInsert = new SqlCommand(Utils.MontaInsert(Campos, Tabela, Valores),
                    DataBase.GetDataBase.Con);
            return _cmdInsert;
        }
        public void Executar()
        {
           this.Command().ExecuteNonQuery();
        }
    }
}
