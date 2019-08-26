using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Faculdade.ADO.Class;

namespace Faculdade.ADO.Repositorio
{
    internal class Insert
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
            return _cmdInsert ?? (_cmdInsert = new SqlCommand(MontaInsert(Campos, Tabela, Valores),
                       DataBase.GetDataBase.Con));
        }
        public void Executar()
        {
            Command().ExecuteNonQuery();
        }
        public static string MontaInsert(List<string> aCampos, string aTabela, List<string> aValores)
        {
            var strInsert = new StringBuilder("Insert Into ");
            strInsert.Append(aTabela);
            strInsert.Append("(");
            strInsert.Append(Utils.StringListToString(aCampos));
            strInsert.Append(") Values (");
            strInsert.Append(Utils.StringListToString(aValores));
            strInsert.Append(")");
            return strInsert.ToString();
        }
    }
}
