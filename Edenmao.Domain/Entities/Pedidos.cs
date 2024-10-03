using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.Entities
{
    internal class Pedidos
    {
        public int IDPedidos { get; set;}
        public int IDCliente { get; set;}
        public decimal Subtotal { get; set;}
        public decimal TotalDescuento { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEmisión { get; set; }
        public string Estatus { get; set; }
    }
}
