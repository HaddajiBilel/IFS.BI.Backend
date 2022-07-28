using API.Data;
using API.Entities;
using API.Models.StoredProcedure;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoredProcedureController : ControllerBase
    {
        private readonly IRepository<StoredProcedure> _storedProcedureRepository;
        public StoredProcedureController(IRepository<StoredProcedure> storedProcedureRepository)
        {
            _storedProcedureRepository = storedProcedureRepository;
        }
        [HttpGet("all")]
        public IActionResult Get()
        { 
            var data = _storedProcedureRepository.GetAll();
            return Ok(data);

        }

        [HttpGet("id")]
        public IActionResult GetById(Guid id)
        {
            var sp = _storedProcedureRepository.Get(id);
            return sp == null ? NotFound() : Ok(sp);
        }

        [HttpPost("add")]
        public IActionResult AddStoredProcedure([FromBody] AddStoredProcedureRequest addStoredProcedureRequest)
        {
            List<Parameter> paramList = new List<Parameter>();
            var spGuid = Guid.NewGuid();


            foreach (var item in addStoredProcedureRequest.Parameters)
            {
                paramList.Add(new Parameter
                {
                    ParameterId = Guid.NewGuid(),
                    Name = item.Name,
                    ParameterSide = item.ParameterSide,
                    ParameterType = item.ParameterType,
                    Required = item.Required,
                    InsertDateTime = DateTime.Now
                });
                    
            }

            var sp = new StoredProcedure
            {
                StoredProcedureId = Guid.NewGuid(),
                Name = addStoredProcedureRequest.Name,
                Description = addStoredProcedureRequest.Description,
                Parameters = paramList,
                InsertDateTime = DateTime.Now
            };
             _storedProcedureRepository.Add(sp);

            return Accepted();
        }
    }
}
