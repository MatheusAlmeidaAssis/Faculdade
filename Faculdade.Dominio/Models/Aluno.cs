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
        public DateTime DataNascimento { get; set; }
        public enum Campos { Id, Nome, Mae, DataNascimento };
        public static readonly string[] ArrCampos = { "AlunoId", "Nome", "Mae", "DtaNasc" };
        public const string CTabela = "Aluno";
    }
}
