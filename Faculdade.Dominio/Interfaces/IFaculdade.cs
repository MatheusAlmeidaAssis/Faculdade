using System.Collections.Generic;

namespace Faculdade.Dominio.Interfaces
{
    public interface IFaculdade<T> where T : class
    {
        void Salvar(T aEntidade);
        IEnumerable<T> Listar(int aId = 0);
        void Excluir(int aId);
    }
}
