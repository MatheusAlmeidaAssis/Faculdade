using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Faculdade.ADO.Class;

namespace Faculdade.ADO.Repositorio
{
    internal class Select
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
                _insert.Campos = Campos.FirstOrDefault();
                _insert.Tabela = (Tabelas.FirstOrDefault() ?? throw new InvalidOperationException()).FirstOrDefault();
                return _insert;
            }
        }
        public Update Update
        {
            get
            {
                if (_update == null)
                    _update = new Update();
                _update.Tabela = (Tabelas.FirstOrDefault() ?? throw new InvalidOperationException()).FirstOrDefault();
                _update.Where = Where.FirstOrDefault();
                return _update;
            }
        }
        public Delete Delete
        {
            get
            {
                if (_delete == null)
                    _delete = new Delete();
                _delete.Tabela = (Tabelas.FirstOrDefault() ?? throw new InvalidOperationException()).FirstOrDefault();
                _delete.Where = Where.FirstOrDefault();
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
            return _cmdSelect ?? (_cmdSelect = new SqlCommand(MontaSelect(Campos, Tabelas, LeftJoin, InnerJoin,
                       RightJoin, FullOuterJoin, Where, GroupBy, OrderBy), DataBase.GetDataBase.Con));
        }
        public SqlDataReader DataReader()
        {
            return Command().ExecuteReader();
        }

        public static string MontaSelect(List<List<string>> aCampos, List<List<string>> aTabelas, List<List<string>> aLefJoin = null,
            List<List<string>> aInnerJoin = null, List<List<string>> aRightJoin = null, List<List<string>> aFullOuterJoin = null,
            List<List<string>> aWhere = null, List<List<string>> aGroupBy = null, List<string> aOrderBy = null)
        {
            var strSql = new StringBuilder(string.Empty);
            for (var i = 0; i < aCampos.Count; i++)
            {
                if (i > 0)
                    strSql.Append(" Union All ");
                strSql.Append("Select ");
                strSql.Append(Utils.StringListToString(aCampos[i]));
                strSql.Append(" From ");
                strSql.Append(Utils.StringListToString(aTabelas[i]));
                if (aLefJoin?[i] != null)
                {
                    foreach (var leftJoin in aLefJoin)
                    {
                        strSql.Append(" Left Join ");
                        strSql.Append(leftJoin);
                    }
                }
                if (aInnerJoin?[i] != null)
                {
                    foreach (var innerJoin in aInnerJoin)
                    {
                        strSql.Append(" Inner Join ");
                        strSql.Append(innerJoin);
                    }
                }
                if (aRightJoin?[i] != null)
                {
                    foreach (var rightJoin in aRightJoin)
                    {
                        strSql.Append(" Rigth Join ");
                        strSql.Append(rightJoin);
                    }
                }
                if (aFullOuterJoin?[i] != null)
                {
                    foreach (var fullOuterJoin in aFullOuterJoin)
                    {
                        strSql.Append(" Full Outer Join ");
                        strSql.Append(fullOuterJoin);
                    }
                }
                if (aWhere?[i] != null)
                {
                    for (var j = 0; j < aWhere[i].Count; j++)
                    {
                        if (j == 0)
                            strSql.Append(" Where ");
                        strSql.Append(aWhere[i][j]);
                    }
                }
                if (aGroupBy?[i] == null) continue;
                strSql.Append(" Group By ");
                strSql.Append(Utils.StringListToString(aGroupBy[i]));
            }
            if (aOrderBy == null) return strSql.ToString();
            strSql.Append(" Order By ");
            strSql.Append(Utils.StringListToString(aOrderBy));
            return strSql.ToString();
        }
    }
}
