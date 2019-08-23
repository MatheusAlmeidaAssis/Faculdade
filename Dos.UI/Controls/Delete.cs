using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
                _cmdDelete = new SqlCommand(MontaDelete(Tabela, Where), DataBase.GetDataBase.Con);
            return _cmdDelete;
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
        public static string MontaDelete(string aTabela, List<string> aWhere)
        {
            StringBuilder strDelete = new StringBuilder("Delete ");
            strDelete.Append("From ");
            strDelete.Append(aTabela);
            for (int i = 0; i < aWhere.Count; i++)
            {
                if (i == 0)
                    strDelete.Append(" Where ");                
                strDelete.Append(aWhere[i][i]);                
            }
            return strDelete.ToString();
        }
    }
}
