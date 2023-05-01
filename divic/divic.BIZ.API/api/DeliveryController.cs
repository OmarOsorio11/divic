using COMMON.DTO;
using divic.DAL.SQLSERVER;
using Microsoft.AspNetCore.Mvc;

namespace divic.BIZ.API.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : GenericApiController<Delivery>
    {
        public DeliveryController() : base(FabricRepository.Delivery())
        {
        }
    }
}
