using Faculdade.Dominio.Interfaces;
using Faculdade.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade.Applications
{
    public class AlunoApplication : IFaculdade<Aluno>
    {
        private readonly IFaculdade<Aluno> _faculdade;
        public AlunoApplication(IFaculdade<Aluno> faculdade)
        {
            _faculdade = faculdade;
        }
        public void Excluir(int aId)
        {
            _faculdade.Excluir(aId);
        }
        public IEnumerable<Aluno> Listar(int aId = 0)
        {
            return _faculdade.Listar(aId);
        }
        public void Salvar(Aluno aEntidade)
        {
            _faculdade.Salvar(aEntidade);
        }
    }
}
