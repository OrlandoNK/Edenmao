using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public partial class Clientes
    {
        [Key]
        public int IDClientes  { get; set; }
        public int IDUsuario { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estatus { get; set; }
       [ForeignKey("IDUsuario")]
        public virtual Usuarios? IDUsuarioNav { get; set; }
        [InverseProperty("IDClienteNav")]
        public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
