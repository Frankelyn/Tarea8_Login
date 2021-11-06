using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosWPF.BLL
{
    public class Utilidades
    {
        public static int Toint(string valor)
        {
            int retorno;

            int.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
