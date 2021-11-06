using RegistroUsuariosWPF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosWPF.BLL
{
    public class LoginBLL
    {
        public static bool validar(string email, string password)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var Validar = from Usuario in contexto.Usuarios where Usuario.email == email && Usuario.password == password select Usuario;
                if (Validar.Count() > 0)
                    paso = true;
                else
                    paso = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
    }
}
