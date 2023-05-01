using COMMON.DTO;
using COMMON.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace divic.BIZ.API.api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class GenericApiController<T> : ControllerBase where T : BaseDTO
    {
        readonly IGenericRepository<T> repository;
        public GenericApiController(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get() 
        {
            try
            {
                return Ok(repository.Read);
            }
            catch (Exception)
            {
                return BadRequest(repository.Error);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            try
            {
                return Ok(repository.SearchById(id));
            }
            catch (Exception)
            {

                return BadRequest(repository.Error);
            }
        }
        [HttpPost]
        public ActionResult<bool> Post([FromBody] T entity)
        {
            try
            {
                return Ok(repository.Create(entity));
            }
            catch (Exception)
            {

                return BadRequest(repository.Error);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(repository.Delete(id));
            }
            catch (Exception)
            {
                return BadRequest(repository.Error);
            }

        }
        [HttpPut]
        public ActionResult<bool> Put([FromBody] T entity)
        {
            try
            {
                return Ok(repository.Update(entity));
            }
            catch (Exception)
            {
                return BadRequest(repository.Error);
            }
        }
    }
}
