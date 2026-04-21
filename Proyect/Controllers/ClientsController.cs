using Microsoft.AspNetCore.Mvc;
using Proyect.Core.Services;
using Proyect.Core.Models;
using Proyect.Core.DTO;
using AutoMapper;
using Proyect.ModelDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService _clientServices, IMapper mapper)
        {
            _clientService = _clientServices;
            _mapper = mapper;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IEnumerable<ClientDTO>> Get()
        {
            var list = await _clientService.GetAllAsync();
            var DTOlist = _mapper.Map<List<ClientDTO>>(list);
            return DTOlist;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var c = await _clientService.GetByIdAsync(id);
            var cdTO = _mapper.Map<ClientDTO>(c);
            if (c == null)
            {
                return NotFound();
            }
            return Ok(cdTO);
        }


        // POST api/<ClientsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientsPostModel value)
        {
            var s = new Clients { Name = value.Name, adress = value.adress, mail = value.mail };
            var c = await _clientService.GetBynameAsync(value.Name);
            if (c == null)
            {
                await _clientService.PostAsync(s);
                return Ok(value);
            }
            return Conflict();


        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientsPostModel value)
        {
            var s = new Clients { Name = value.Name, adress = value.adress, mail = value.mail };
            var c = await _clientService.GetByIdAsync(id);
            if (c == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return NotFound();
            }
            await _clientService.PutAsync(id, s);
            return Ok(c);

        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var c = await _clientService.GetByIdAsync(id);
            if (c == null)
            {
                return BadRequest();
            }
            await _clientService.DeleteAsync(id);
            return Ok();

        }
    }
}
