using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Controls
{
    static class Utils
    {        
        public static string MontaSelect(List<List<string>> aCampos, List<List<string>> aTabelas, List<List<string>> aLefJoin = null,
            List<List<string>> aInnerJoin = null, List<List<string>> aRightJoin = null, List<List<string>> aFullOuterJoin = null, 
            List<List<string>> aWhere = null, List<List<string>> aGroupBy = null, List<string> aOrderBy = null)
        {
            StringBuilder strSql = new StringBuilder(string.Empty);
            for (int i = 0; i < aCampos.Count; i++)
            {
                if (i > 0)
                    strSql.AppendLine("Union All");
                strSql.AppendLine("Select ");
                strSql.Append(StringListToString(aCampos[i]));
                strSql.AppendLine("From ");
                strSql.Append(StringListToString(aTabelas[i]));
                if (aLefJoin != null)
                {
                    if (aLefJoin[i] != null)
                    {
                        foreach (var leftJoin in aLefJoin)
                        {
                            strSql.AppendLine("Left Join ");
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
                            strSql.AppendLine("Inner Join ");
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
                            strSql.AppendLine("Rigth Join ");
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
                            strSql.AppendLine("Full Outer Join ");
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
                                strSql.AppendLine("Where ");
                            strSql.AppendLine("(");
                            strSql.Append(aWhere[i][j]);
                            strSql.Append(")");
                        }
                    }
                }
                if (aGroupBy != null)
                {
                    if (aGroupBy[i] != null)
                    {
                        strSql.AppendLine("Group By ");
                        strSql.Append(StringListToString(aGroupBy[i]));
                    }
                }
            }
            if (aOrderBy != null)
            {
                strSql.AppendLine("Order By ");
                strSql.Append(StringListToString(aOrderBy));
            }
            return strSql.ToString();
        }        

        public static string MontaInsert(List<string> aCampos, string aTabela, List<string> aValores)
        {
            StringBuilder strInsert = new StringBuilder("Insert Into");
            strInsert.AppendLine(aTabela);
            strInsert.AppendLine("(");
            strInsert.Append(StringListToString(aCampos));
            strInsert.Append(") Values (");
            strInsert.Append(StringListToString(aValores));
            strInsert.Append(")");
            return strInsert.ToString();
        }
        
        public static string MontaUpdate(List<string> aCampos, string aTabela, List<string> aValores, List<string> aWhere)
        {
            StringBuilder strUpdate = new StringBuilder("Update ");
            strUpdate.AppendLine(aTabela);
            strUpdate.AppendLine("Set (");
            for (int i = 0; i < aCampos.Count; i++)
            {               
                strUpdate.Append(aCampos[i]);
                strUpdate.Append(" = ");
                strUpdate.Append(aValores[i]);
                if (i < aCampos.Count - 1)
                    strUpdate.Append(", ");
            }
            for (int i = 0; i < aWhere.Count; i++)
            {
                if (i == 0)
                    strUpdate.AppendLine("Where ");
                strUpdate.AppendLine("(");
                strUpdate.Append(aWhere[i][i]);
                strUpdate.Append(")");
            }
            return strUpdate.ToString();
        }
        public static string MontaDelete(string aTabela, List<string> aWhere)
        {
            StringBuilder strDelete = new StringBuilder("Delete ");            
            strDelete.AppendLine("From ");
            strDelete.Append(aTabela);            
            for (int i = 0; i < aWhere.Count; i++)
            {
                if (i == 0)
                    strDelete.AppendLine("Where ");
                strDelete.AppendLine("(");
                strDelete.Append(aWhere[i][i]);
                strDelete.Append(")");
            }
            return strDelete.ToString();
        }
        public static string StringListToString(List<string> aStringList, string aTextoQuebra = ", ")
        {
            StringBuilder strString = new StringBuilder(string.Empty);
            for (int i = 0; i < aStringList.Count; i++)
            {
                if (i > 0)
                    strString.Append(aStringList[i] + aTextoQuebra);
                else
                    strString.Append(aStringList[i]);
            }
            return strString.ToString();
        }
        public static string StringArrayToString(string[] aArrayString, string aTextoQuebra = ", ")
        {
            StringBuilder strString = new StringBuilder(string.Empty);
            for (int i = 0; i < aArrayString.Length; i++)
            {
                if (i > 0)
                    strString.Append(aArrayString[i] + aTextoQuebra);
                else
                    strString.Append(aArrayString[i]);
            }
            return strString.ToString();
        }                
    }
}
