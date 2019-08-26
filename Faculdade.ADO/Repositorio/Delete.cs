using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Faculdade.ADO.Repositorio
{
    internal class Delete
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
            return _cmdDelete ?? (_cmdDelete = new SqlCommand(MontaDelete(Tabela, Where), DataBase.GetDataBase.Con));
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
        public static string MontaDelete(string aTabela, List<string> aWhere)
        {
            var strDelete = new StringBuilder("Delete ");
            strDelete.Append("From ");
            strDelete.Append(aTabela);
            for (var i = 0; i < aWhere.Count; i++)
            {
                if (i == 0)
                    strDelete.Append(" Where ");
                strDelete.Append(aWhere[i]);
            }
            return strDelete.ToString();
        }
    }
}
