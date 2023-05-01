using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.DTO
{
    public class PaqueteEnTransito : BaseDTO
    {
        public int Id { get; set; }
        public int IdPaquete { get; set; }
        public int IdDelivery { get; set; }
    }
}
