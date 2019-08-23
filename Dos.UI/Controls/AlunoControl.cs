using Dos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dos.UI.Controls
{
    class AlunoControl : Controller
    {
        private Select _select = new Select();
        public void Insert(Alunos aAluno)
        {
            _select.Campos = new List<List<string>>
            {
                Alunos.arrCampos.ToList()
            };
            _select.Tabelas = new List<List<string>>
            {
                new List<string>{ Alunos.cTabela }
            };           
        }
    }
}
