using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Business.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApi<T> : ControllerBase

    {
        IBaseService<T> _baseService;
        public BaseApi(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        // GET: api/<BaseApi>
        [HttpGet]
        public IActionResult Get()
        {
            var rs = _baseService.Get();
            if (rs != null)
                return Ok(rs);
            else
                return NoContent();
        }

        // GET api/<BaseApi>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var entity = _baseService.GetById(id);
            if (entity != null)
                return Ok(entity);
            else
                return NoContent();
        }

        // POST api/<BaseApi>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var serviceResponse = _baseService.Insert(entity);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("POST", affectRows);
            else
                return BadRequest(serviceResponse);
        }


        // PUT api/<BaseApi>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] T entity)
        
        {
           
            var affectRows = _baseService.Update(entity,id);
            if (affectRows > 0)
                return Ok(affectRows);
            else
                return NoContent();
        }

        // DELETE api/<BaseApi>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var affectRows = _baseService.Delete(id);
            if (affectRows > 0)
                return Ok(affectRows);
            else
                return NoContent();
        }
        
        [Route("GetbyCode")]
        [HttpGet]
        public IActionResult GetbyCode()
        {
            var entitycode = _baseService.GetbyCode();
            if(entitycode != null)
            {
                return Ok(entitycode);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
