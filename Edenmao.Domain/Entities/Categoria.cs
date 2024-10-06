using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }

        [InverseProperty("IDCategoriaNav")]
        public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
