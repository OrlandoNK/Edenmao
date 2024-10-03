using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    internal class DetallePedidos_Articulos
    {
        public int IDDetalleArticulo { get; set; }
        public int IDPedido { get; set; }
        public int IDArticulo { get; set; }
    }
}
