using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public partial class Roles
    {
        [Key]
        public int IDRolUsuario { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }

        [InverseProperty("IDRolUsuarioNav")]
        public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    }
}
