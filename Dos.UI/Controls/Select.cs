using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Controls
{
    class Select
    {
        private SqlCommand _cmdSelect;
        public List<List<string>> Campos { get; set; }
        public List<List<string>> Tabelas { get; set; }
        public List<List<string>> LeftJoin { get; set; }
        public List<List<string>> InnerJoin { get; set; }
        public List<List<string>> RightJoin { get; set; }
        public List<List<string>> FullOuterJoin { get; set; }
        public List<List<string>> Where { get; set; }
        public List<List<string>> GroupBy { get; set; }
        public List<string> OrderBy { get; set; }

        public Select()
        {
            Campos = new List<List<string>>();
            Tabelas = new List<List<string>>();
        }
        public SqlCommand Command()
        {
            if (_cmdSelect == null)
                _cmdSelect = new SqlCommand(Utils.MontaSelect(Campos, Tabelas, LeftJoin, InnerJoin,
                    RightJoin, FullOuterJoin, Where, GroupBy, OrderBy), DataBase.GetDataBase.Con);
            return _cmdSelect;
        }
        public SqlDataReader DataReader()
        {
            return this.Command().ExecuteReader();
        }
    }
}
