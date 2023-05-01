using COMMON.DTO;
using divic.DAL.SQLSERVER;
using Microsoft.AspNetCore.Mvc;

namespace divic.BIZ.API.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteEnTransitoController : GenericApiController<PaqueteEnTransito>
    {
        public PaqueteEnTransitoController() : base(FabricRepository.PaqueteEnTransito())
        {
        }
    }
}
