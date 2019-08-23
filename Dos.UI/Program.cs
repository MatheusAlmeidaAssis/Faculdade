using Dos.UI.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dos.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do aluno: ");
            string strNome = Console.ReadLine();
            Console.Write("Digite o nome da mãe do aluno: ");
            string strMae = Console.ReadLine();
            Console.Write("Digite a data de nascimento do aluno: ");
            string strData = Console.ReadLine();
            DateTime dtaDataNasc = Convert.ToDateTime(strData);

            Select alunos = DataBase.GetDataBase.Select;
            alunos.Campos.Add(new List<string>
            {
                "Nome",
                "Mae",
                "DtaNasc"
            });
            alunos.Tabelas.Add(new List<string>
            {
                "Alunos"
            });
            Insert insertAluno = alunos.Insert;
            insertAluno.Valores = new List<string>
            {
                "@Nome",
                "@Mae",
                "@DtaNasc"
            };
            var parametros = insertAluno.Command().Parameters;
            parametros.AddWithValue("@Nome", strNome);
            parametros.AddWithValue("@Mae", strMae);
            parametros.AddWithValue("@DtaNasc", dtaDataNasc);
            insertAluno.Executar();
            alunos.Campos[0].Add("Id");
            SqlDataReader dados = alunos.DataReader();
            while (dados.Read())
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Mãe:{2}, Data de Nascimento:{3}", dados["Id"], dados["Nome"], dados["Mae"], dados["DtaNasc"]);
            }
            Console.Read();
        }
    }
}
