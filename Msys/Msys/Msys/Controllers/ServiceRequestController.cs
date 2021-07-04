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
        private readonly IGenericRepository<ServiceRequestEntity> _repository;
        public ServiceRequestController(IGenericRepository<ServiceRequestEntity> repository)
        {
            _repository = repository;
            _repository.SetDefaultData();
        }

        //api/servicerequest/Get
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ServiceRequestEntity>>> Get()
        {
            try
            {
                 var retObj = _repository.GetAll();
                if (retObj != null)
                    return Ok(retObj);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        //api/servicerequest/Get/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestEntity>> Get(Guid id)
        {
            try
            {

                var serviceRequest = _repository.GetById(id);
                if (serviceRequest == null)
                {
                    return NotFound();
                }
                return Ok(serviceRequest);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        //api/servicerequest/Post
        [HttpPost]
        public ActionResult<ServiceRequestEntity> Post([FromBody] ServiceRequestEntity service)
        {
            try
            {
                bool isDataCreated = _repository.Add(service);
                //return CreatedAtAction("Get", new { id = service.Id }, service);
                if (isDataCreated)
                    return Created(string.Empty, "created service request with id");
                else
                    return Ok("Data already exist");
            }
            catch(Exception e)
            {
                return BadRequest();
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
                var isUpdated = _repository.Update(id, service);
                if (isUpdated)
                    return Ok("updated service request");
                else
                    return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        //api/servicerequest/Delete/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            try
            {
                var serviceRequest = _repository.GetById(id);
                if (serviceRequest == null)
                {
                    return NotFound("not found");
                }
                var isRecordDeleted = _repository.Delete(id, serviceRequest);
                if (isRecordDeleted)
                    return Created(string.Empty, "Deleted Successfully");
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
