using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.DTO
{
    public class PaqueteEntregado : BaseDTO
    {
        public int Id { get; set; }
        public int IdPaquete { get; set; }
        public string NombreRecibe { get; set; }
        public string TipoPersonaRecibe { get; set; }
        public string UrlImagen { get; set; }
        public string CurpRecibe { get; set; }
    }
}
