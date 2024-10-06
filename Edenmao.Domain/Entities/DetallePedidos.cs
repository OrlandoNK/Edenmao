using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    public class DetallePedidos
    { 
        public int IDDetallePedido { get; set; }
        public int IDPedido { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Itbis { get; set; }
        
        [ForeignKey("IDPedido")]
        public virtual Pedidos? IDPedidoNav { get; set; }

    }
}
