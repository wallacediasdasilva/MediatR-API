using DDDAPI.Application.App.Interface;
using DDDAPI.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamApplication _teamApplication;

        public TeamController(ITeamApplication teamApplication)
        {
            _teamApplication = teamApplication;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeamCreateDTO teamDTO)
        {
            _teamApplication.Create(teamDTO);

            return Created(string.Empty, "Time cadastrato com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeamUpdateDTO teamDTO)
        {
            _teamApplication.Update(id, teamDTO);

            return Ok("Time atualizado com sucesso!");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamApplication.Delete(id);

            return Ok("Time deletado com sucesso!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_teamApplication.GetById(id));
        }
    }
}
