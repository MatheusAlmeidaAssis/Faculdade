using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.UI.Controls
{
    class Insert
    {        
        public List<string> Campos { get; set;}
        public string Tabela { get; set; }
        public List<string> Valores { get; set; }
        public Insert()
        {
            Campos = new List<string>();
            Tabela = string.Empty;
            Valores = new List<string>();
        }
        public void Executar()
        {

        }        
    }
}
