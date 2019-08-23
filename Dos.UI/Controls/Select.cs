using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
                _insert.Campos = Campos[0];
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
                _cmdSelect = new SqlCommand(MontaSelect(Campos, Tabelas, LeftJoin, InnerJoin,
                    RightJoin, FullOuterJoin, Where, GroupBy, OrderBy), DataBase.GetDataBase.Con);
            return _cmdSelect;
        }
        public SqlDataReader DataReader()
        {
            return Command().ExecuteReader();
        }

        public static string MontaSelect(List<List<string>> aCampos, List<List<string>> aTabelas, List<List<string>> aLefJoin = null,
            List<List<string>> aInnerJoin = null, List<List<string>> aRightJoin = null, List<List<string>> aFullOuterJoin = null,
            List<List<string>> aWhere = null, List<List<string>> aGroupBy = null, List<string> aOrderBy = null)
        {
            StringBuilder strSql = new StringBuilder(string.Empty);
            for (int i = 0; i < aCampos.Count; i++)
            {
                if (i > 0)
                    strSql.Append("Union All ");
                strSql.Append("Select ");
                strSql.Append(Utils.StringListToString(aCampos[i]));
                strSql.Append(" From ");
                strSql.Append(Utils.StringListToString(aTabelas[i]));
                if (aLefJoin != null)
                {
                    if (aLefJoin[i] != null)
                    {
                        foreach (var leftJoin in aLefJoin)
                        {
                            strSql.Append(" Left Join ");
                            strSql.Append(leftJoin);
                        }
                    }
                }
                if (aInnerJoin != null)
                {
                    if (aInnerJoin[i] != null)
                    {
                        foreach (var innerJoin in aInnerJoin)
                        {
                            strSql.Append(" Inner Join ");
                            strSql.Append(innerJoin);
                        }
                    }
                }
                if (aRightJoin != null)
                {
                    if (aRightJoin[i] != null)
                    {
                        foreach (var rightJoin in aRightJoin)
                        {
                            strSql.Append(" Rigth Join ");
                            strSql.Append(rightJoin);
                        }
                    }
                }
                if (aFullOuterJoin != null)
                {
                    if (aFullOuterJoin[i] != null)
                    {
                        foreach (var fullOuterJoin in aFullOuterJoin)
                        {
                            strSql.Append(" Full Outer Join ");
                            strSql.Append(fullOuterJoin);
                        }
                    }
                }
                if (aWhere != null)
                {
                    if (aWhere[i] != null)
                    {
                        for (int j = 0; j < aWhere[i].Count; j++)
                        {
                            if (j == 0)
                                strSql.Append(" Where ");                            
                            strSql.Append(aWhere[i][j]);                            
                        }
                    }
                }
                if (aGroupBy != null)
                {
                    if (aGroupBy[i] != null)
                    {
                        strSql.Append(" Group By ");
                        strSql.Append(Utils.StringListToString(aGroupBy[i]));
                    }
                }
            }
            if (aOrderBy != null)
            {
                strSql.Append(" Order By ");
                strSql.Append(Utils.StringListToString(aOrderBy));
            }
            return strSql.ToString();
        }
    }
}
