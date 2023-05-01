using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.DTO
{
    public class Paquete : BaseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string DireccionEntrega { get; set; }
        public string Estatus { get; set; }
        public string Contacto { get; set; }
    }
}
