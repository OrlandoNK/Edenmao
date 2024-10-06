using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class DetallePedidos_Articulos
    {
        [Key]
        public int IDDetalleArticulo { get; set; }
        public int IDPedido { get; set; }
        public int IDArticulo { get; set; }

        [ForeignKey("IDPedido")]
        public virtual Pedidos? IDPedidoNav { get; set; }

        [ForeignKey("IDArticulo")]
        public virtual Personificacion? IDArticuloNav { get; set; }
    }
}
