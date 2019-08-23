using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Models
{
    class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Mae { get; set; }
        public DateTime DataNascimento { get; set; }
        public enum Campos { Id, Nome, Mae, DataNascimento };
        public static readonly string[] arrCampos = { "Id", "Nome", "Mae", "DtaNasc" };
        public const string cTabela = "Alunos";
    }
}
