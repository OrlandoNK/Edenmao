using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Usuarios
    {
        [Key]
        public int IDUsuario { get; set; }
        public int IDRolUsuario { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(30)]
        public string NombreUsuario { get; set; }
        [StringLength(255)]
        public string Contrasena { get; set; }
        public string Estatus { get; set; }

        [ForeignKey("IDRolUsuario")]
        public virtual Roles? IDRolUsuarioNav { get; set; }

        [InverseProperty("IDUsuarioNav")]
        public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
    }
}
