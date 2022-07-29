using API.Models.Data;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        public DataController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost("GetData")]
        public async Task<ActionResult> Get([FromBody] GetDataRequest dto)
        {

            if (dto == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    var json = _dataRepository.GetJsonData(dto.Name, dto.ParamList);

                    return Ok(json);
                }
                catch (Exception ex)
                {

                    return NotFound(ex);
                }

            }

        }

    }
}
