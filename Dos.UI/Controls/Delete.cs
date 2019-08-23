using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Controls
{
    class Delete
    {
        private SqlCommand _cmdDelete;        
        public string Tabela { get; set; }        
        public List<string> Where { get; set; }
        public Delete()
        {            
            Tabela = string.Empty;        
            Where = new List<string>();
        }

        public SqlCommand Command()
        {
            if (_cmdDelete == null)
                _cmdDelete = new SqlCommand(Utils.MontaDelete(Tabela, Where), DataBase.GetDataBase.Con);
            return _cmdDelete;
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
    }
}
