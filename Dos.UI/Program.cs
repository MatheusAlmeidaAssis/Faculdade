using Faculdade.Applications;
using Faculdade.Dominio.Models;
using System;

namespace Faculdade.UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Digite o nome do aluno: ");
            var strNome = Console.ReadLine();
            Console.Write("Digite o nome da mãe do aluno: ");
            var strMae = Console.ReadLine();
            Console.Write("Digite a data de nascimento do aluno: ");
            var strData = Console.ReadLine();
            var alunoInsert = new Aluno
            {
                Nome = strNome,
                Mae = strMae,
                DtaNasc = Convert.ToDateTime(strData)
            };
            var alunoControl = AlunoApplicationFramework.AlunoApplicationADO();
            alunoControl.Salvar(alunoInsert);
            var alunos = alunoControl.Listar();
            foreach (var aluno in alunos)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Mãe:{2}, Data de Nascimento:{3}", aluno.Id,
                    aluno.Nome, aluno.Mae, aluno.DtaNasc);
            }
            Console.Read();
        }
    }
}
