using System.Linq;
using System.Web.Mvc;
using Faculdade.Applications;
using Faculdade.Dominio.Models;

namespace Faculdade.UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AlunoApplication _appAluno;
        public AlunoController()
        {
            _appAluno = AlunoApplicationFramework.AlunoApplicationEntity();
        }
        public ActionResult Index()
        {            
            var alunos = _appAluno.Listar();
            return View(alunos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aAluno)
        {
            if (!ModelState.IsValid) return View(aAluno);            
            _appAluno.Salvar(aAluno);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int aId)
        {            
            var aluno = _appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aAluno)
        {
            if (!ModelState.IsValid) return View(aAluno);            
            _appAluno.Salvar(aAluno);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int aId)
        {            
            var aluno = _appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        public ActionResult Excluir(int aId)
        {            
            var aluno = _appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int aId)
        {            
            _appAluno.Excluir(aId);
            return RedirectToAction("Index");
        }
    }
}