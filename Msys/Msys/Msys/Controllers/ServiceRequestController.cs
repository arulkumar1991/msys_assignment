using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
namespace Msys.Controllers
{
    // Author Arulkumar.   
    // Msys Company.   
    // Created on 3rd July 2012 6:05:34 P.M.
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRepository _repository;
        public ServiceRequestController(IServiceRepository repository)
        {
            _repository = repository;
            _repository.SetDefaultData();
        }

        //api/servicerequest/Get
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ServiceRequestEntity>>> Get()
        {
             var retObj = await _repository.GetAllAsync();
            return Ok(retObj);
        }

        //api/servicerequest/Get/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestEntity>> Get(Guid id)
        {
            var serviceRequest = await _repository.GetByIdAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return serviceRequest;
        }
        //api/servicerequest/Post
        [HttpPost]
        public ActionResult<ServiceRequestEntity> Post([FromBody] ServiceRequestEntity service)
        {
            try
            {
                _repository.Add(service);
                //return CreatedAtAction("Get", new { id = service.Id }, service);
                return Ok("created service request with id");
            }
            catch(Exception e)
            {
                return BadRequest("bad request");
            }
        }

        //api/servicerequest/Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ServiceRequestEntity service)
        {
            try
            {
                if (id != service.Id)
                {
                    return BadRequest();
                }
                _repository.Update(id, service);
                return Ok("updated service request");
            }
            catch(Exception e)
            {
                return BadRequest("bad service request");
            }
        }

        //api/servicerequest/Delete/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            try
            {
                var Service = await _repository.GetByIdAsync(id);
                if (Service == null)
                {
                    return NotFound("not found");
                }
                var isRecordDeleted = _repository.Delete(id, Service);
                if (isRecordDeleted)
                    return Ok("Successful");
                else
                    return BadRequest("Bad Request");
            }
            catch (Exception e)
            {
                return BadRequest("bad request");
            }
        }
    }
}
