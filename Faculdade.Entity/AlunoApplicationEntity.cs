using System;
using System.Collections.Generic;
using Faculdade.Dominio.Interfaces;
using Faculdade.Dominio.Models;

namespace Faculdade.Entity
{
    public class AlunoApplicationEntity : IFaculdade<Aluno>
    {
        private readonly Contexto _Contexto;

        public AlunoApplicationEntity()
        {
            _Contexto = new Contexto();
        }
        public void Salvar(Aluno aEntidade)
        {
            if (aEntidade.Id > 0)
            {
                var aluno = _Contexto.
            }
            else
            {
                
            }
        }

        public IEnumerable<Aluno> Listar(int aId = 0)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int aId)
        {
            throw new NotImplementedException();
        }
    }
}
