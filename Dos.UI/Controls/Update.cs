using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Controls
{
    class Update
    {
        private SqlCommand _cmdUpdate;
        public List<string> Campos { get; set; }
        public string Tabela { get; set; }
        public List<string> Valores { get; set; }
        public List<string> Where { get; set; }
        public Update()
        {
            Campos = new List<string>();
            Tabela = string.Empty;
            Valores = new List<string>();
            Where = new List<string>();
        }

        public SqlCommand Command()
        {
            if (_cmdUpdate == null)
                _cmdUpdate = new SqlCommand(Utils.MontaUpdate(Campos, Tabela, Valores, Where),
                    DataBase.GetDataBase.Con);
            return _cmdUpdate;
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
    }
}
