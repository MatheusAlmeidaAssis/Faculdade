using Faculdade.ADO.Applications;
using Faculdade.Entity.Applications;

namespace Faculdade.Applications
{
    public static class AlunoApplicationFramework
    {
        public static AlunoApplication AlunoApplicationADO()
        {
            return new AlunoApplication(new AlunoApplicationAdo());
        }
        public static AlunoApplication AlunoApplicationEntity()
        {
            return new AlunoApplication(new AlunoApplicationEntity());
        }
    }
}
