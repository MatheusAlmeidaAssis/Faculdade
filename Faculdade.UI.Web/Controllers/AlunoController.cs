using System.Linq;
using System.Web.Mvc;
using Faculdade.Applications;
using Faculdade.Dominio.Models;

namespace Faculdade.UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        public ActionResult Index()
        {
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            var alunos = appAluno.Listar();
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
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            appAluno.Salvar(aAluno);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int aId)
        {
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            var aluno = appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aAluno)
        {
            if (!ModelState.IsValid) return View(aAluno);
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            appAluno.Salvar(aAluno);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int aId)
        {
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            var aluno = appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        public ActionResult Excluir(int aId)
        {
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            var aluno = appAluno.Listar(aId);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno.FirstOrDefault());
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int aId)
        {
            var appAluno = AlunoApplicationFramework.AlunoApplicationADO();
            appAluno.Excluir(aId);
            return RedirectToAction("Index");
        }
    }
}