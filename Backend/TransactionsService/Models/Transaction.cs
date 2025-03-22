using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsService.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public DateTime FechaTransaccion { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public string TipoTransaccion { get; set; } = string.Empty;

        public int RemitenteId { get; set; } 
        public string NombreRemitente { get; set; }  = string.Empty;
        public string CuentaOrigen { get; set; }  = string.Empty;

        public int DestinatarioId { get; set; } 
        public string CuentaDestino { get; set; }  = string.Empty;
        public string NombreDestinatario { get; set; }  = string.Empty;

        public string MetodoPago { get; set; } = string.Empty;
        public string CodigoAutorizacion { get; set; } = string.Empty;
        public string IpTransaccion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

        public string AprobadoPor { get; set; }  = string.Empty;
        public DateTime FechaAprobacion { get; set; } = DateTime.MinValue;
    }

}