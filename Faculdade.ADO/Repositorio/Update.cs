using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Faculdade.ADO.Repositorio
{
    internal class Update
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
            return _cmdUpdate ?? (_cmdUpdate = new SqlCommand(MontaUpdate(Campos, Tabela, Valores,
                       Where), DataBase.GetDataBase.Con));
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
        public static string MontaUpdate(List<string> aCampos, string aTabela, List<string> aValores,
            List<string> aWhere)
        {
            var strUpdate = new StringBuilder("Update ");
            strUpdate.Append(aTabela);
            strUpdate.Append(" Set ");
            for (var i = 0; i < aCampos.Count; i++)
            {
                strUpdate.Append(aCampos[i]);
                strUpdate.Append(" = ");
                strUpdate.Append(aValores[i]);
                if (i < aCampos.Count - 1)
                    strUpdate.Append(", ");
            }
            for (var i = 0; i < aWhere.Count; i++)
            {
                if (i == 0)
                    strUpdate.Append(" Where ");
                strUpdate.Append(aWhere[i]);
            }
            return strUpdate.ToString();
        }
    }
}
