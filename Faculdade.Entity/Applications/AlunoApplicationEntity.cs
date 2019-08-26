using System;
using System.Collections.Generic;
using System.Linq;
using Faculdade.Dominio.Interfaces;
using Faculdade.Dominio.Models;
using Faculdade.Entity.Repositorio;

namespace Faculdade.Entity.Applications
{
    public class AlunoApplicationEntity : IFaculdade<Aluno>
    {
        private readonly Contexto _contexto;

        public AlunoApplicationEntity()
        {
            _contexto = new Contexto();
        }
        public void Salvar(Aluno aEntidade)
        {
            if (aEntidade.Id > 0)
            {
                var aluno = _contexto.Alunos.First(x => x.Id == aEntidade.Id);
                if (aluno.Nome != aEntidade.Nome)
                    aluno.Nome = aEntidade.Nome;
                if (aluno.Mae != aEntidade.Mae)
                    aluno.Mae = aEntidade.Mae;
                if (aluno.DtaNasc != aEntidade.DtaNasc)
                    aluno.DtaNasc = aEntidade.DtaNasc;
            }
            else
                _contexto.Alunos.Add(aEntidade);
            _contexto.SaveChanges();
        }

        public IEnumerable<Aluno> Listar(int aId = 0)
        {
            if (aId > 0)
            {
                var alunos = new List<Aluno>();
                var aluno = _contexto.Alunos.First(x => x.Id == aId);
                alunos.Add(aluno);
                return alunos;
            }
            return _contexto.Alunos;
        }

        public void Excluir(int aId)
        {
            var aluno = _contexto.Alunos.First(x => x.Id == aId);
            _contexto.Set<Aluno>().Remove(aluno);
            _contexto.SaveChanges();
        }
    }
}
