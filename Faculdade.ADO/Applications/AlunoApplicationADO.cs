using Faculdade.ADO.Repositorio;
using Faculdade.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Faculdade.Dominio.Interfaces;

namespace Faculdade.ADO.Applications
{
    public class AlunoApplicationAdo : IFaculdade<Aluno>
    {
        public void Salvar(Aluno aAluno)
        {
            if (aAluno.Id > 0)
            {
                Alterar(aAluno);
            }
            else
            {
                Inserir(aAluno);
            }
        }
        private Aluno CarregaAluno(IDataRecord aDados)
        {
            var aluno = new Aluno()
            {
                Id = (int)aDados[Aluno.ArrCampos[(int)Aluno.Campos.Id]],
                Nome = (string)aDados[Aluno.ArrCampos[(int)Aluno.Campos.Nome]],
                Mae = (string)aDados[Aluno.ArrCampos[(int)Aluno.Campos.Mae]],
                DataNascimento = (DateTime)aDados[Aluno.ArrCampos[(int)Aluno.Campos.DataNascimento]]
            };
            return aluno;
        }
        private void Inserir(Aluno aAluno)
        {
            var insert = new Insert
            {
                Campos = Aluno.ArrCampos.ToList(),
                Tabela = Aluno.CTabela,
                Valores = new List<string>
                {
                    "@Nome",
                    "@Mae",
                    "@DtaNasc"
                }
            };
            insert.Campos.RemoveAt(0);
            var parametros = insert.Command().Parameters;
            parametros.AddWithValue("@Nome", aAluno.Nome);
            parametros.AddWithValue("@Mae", aAluno.Mae);
            parametros.AddWithValue("@DtaNasc", aAluno.DataNascimento);
            insert.Executar();
        }
        public IEnumerable<Aluno> Listar(int aId = 0)
        {
            var alunos = new List<Aluno>();
            var select = new Select
            {
                Campos = new List<List<string>> { Aluno.ArrCampos.ToList() },
                Tabelas = new List<List<string>> { new List<string> { Aluno.CTabela } }
            };
            if (aId > 0)
            {
                var filtro = new List<string>
                {
                    "(" + Aluno.ArrCampos[(int)Aluno.Campos.Id] + " = " + aId + ")"
                };
                select.Where = new List<List<string>>() { filtro };
            }
            var dados = select.DataReader();
            while (dados.Read())
            {
                alunos.Add(CarregaAluno(dados));
            }
            dados.Close();
            return alunos;
        }
        private void Alterar(Aluno aAluno)
        {
            var aluno = Listar(aAluno.Id).FirstOrDefault();
            var update = new Update { Tabela = Aluno.CTabela };
            if (aluno.Nome != aAluno.Nome)
            {
                update.Campos.Add(Aluno.ArrCampos[(int)Aluno.Campos.Nome]);
                update.Valores.Add("@Nome");
            }
            if (aluno.Mae != aAluno.Mae)
            {
                update.Campos.Add(Aluno.ArrCampos[(int)Aluno.Campos.Mae]);
                update.Valores.Add("@Mae");
            }
            if (aluno.DataNascimento != aAluno.DataNascimento)
            {
                update.Campos.Add(Aluno.ArrCampos[(int)Aluno.Campos.DataNascimento]);
                update.Valores.Add("@DtaNasc");
            }
            update.Where.Add(Aluno.ArrCampos[(int)Aluno.Campos.Id] + " = " + aAluno.Id);
            var parametros = update.Command().Parameters;
            if (aluno.Nome != aAluno.Nome)
                parametros.AddWithValue("@Nome", aAluno.Nome);
            if (aluno.Mae != aAluno.Mae)
                parametros.AddWithValue("@Mae", aAluno.Mae);
            if (aluno.DataNascimento != aAluno.DataNascimento)
                parametros.AddWithValue("@DtaNasc", aAluno.DataNascimento);
            update.Executar();
        }
        public void Excluir(int aId)
        {
            var delete = new Delete
            {
                Tabela = Aluno.CTabela,
                Where = new List<string>
                {
                    "(" + Aluno.ArrCampos[(int)Aluno.Campos.Id] + " = " + aId + ")"
                }
            };
            delete.Executar();
        }
    }
}
