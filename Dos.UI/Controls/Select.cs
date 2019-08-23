using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dos.UI.Controls
{
    class Select
    {
        private SqlCommand _cmdSelect;
        private Update _update;
        private Delete _delete;
        private Insert _insert;
        public List<List<string>> Campos { get; set; }
        public List<List<string>> Tabelas { get; set; }
        public List<List<string>> LeftJoin { get; set; }
        public List<List<string>> InnerJoin { get; set; }
        public List<List<string>> RightJoin { get; set; }
        public List<List<string>> FullOuterJoin { get; set; }
        public List<List<string>> Where { get; set; }
        public List<List<string>> GroupBy { get; set; }
        public List<string> OrderBy { get; set; }
        public Insert Insert
        {
            get
            {
                if (_insert == null)
                    _insert = new Insert();
                _insert.Tabela = Tabelas[0][0];
                return _insert;
            }
        }
        public Update Update
        {
            get
            {
                if (_update == null)
                    _update = new Update();
                _update.Tabela = Tabelas[0][0];
                _update.Where = Where[0];
                return _update;
            }
        }
        public Delete Delete
        {
            get
            {
                if (_delete == null)
                    _delete = new Delete();
                _delete.Tabela = Tabelas[0][0];
                _delete.Where = Where[0];
                return _delete;
            }
        }

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
            return Command().ExecuteReader();
        }
    }
}
