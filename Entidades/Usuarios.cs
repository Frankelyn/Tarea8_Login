using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuariosWPF.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string apellidos { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public int RolId { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [ForeignKey("RolId")]
        public virtual Roles Rol { get; set; }

    }
}
