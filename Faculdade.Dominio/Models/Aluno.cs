using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Faculdade.Dominio.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Mãe")]
        public string Mae { get; set; }
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtaNasc { get; set; }
        public enum Campos { Id, Nome, Mae, DataNascimento };
        public static readonly string[] ArrCampos = { "Id", "Nome", "Mae", "DtaNasc" };
        public const string CTabela = "Alunos";
    }
}
