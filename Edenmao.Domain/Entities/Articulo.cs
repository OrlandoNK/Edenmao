using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class Articulo
    {
        [Key]
        public int IDArticulo { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IDcategoria { get; set; }
        public int IDPersonificacion { get; set; }
        public string Estatus { get; set; }
        [ForeignKey ("IDCategoria")]
        public virtual Categoria? IDCategoriaNav { get; set; }

        [ForeignKey("IDPersonificacion")]
        public virtual Personificacion? IDPersonificacionNav { get; set; }
        
        [InverseProperty("IDArticuloNav")]
        public virtual ICollection<DetallePedidos> DetallePedidos { get; set; } = new List<DetallePedidos>();
    }
}
