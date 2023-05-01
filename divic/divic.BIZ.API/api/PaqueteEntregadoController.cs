using COMMON.DTO;
using divic.DAL.SQLSERVER;
using Microsoft.AspNetCore.Mvc;

namespace divic.BIZ.API.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteEntregadoController : GenericApiController<PaqueteEntregado>
    {
        public PaqueteEntregadoController() : base(FabricRepository.PaqueteEntregado())
        {
        }
    }
}
