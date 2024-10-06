using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Personificacion
    {
        [Key]
        public int IDPersonificacion { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set;}

        [InverseProperty("IDPersonificacionNav")]
        public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
