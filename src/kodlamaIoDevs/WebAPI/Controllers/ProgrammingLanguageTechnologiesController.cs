using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologyTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommand createProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(createProgrammingLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(updateProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getListProgrammingLanguageTechnologyQuery = new GetListProgrammingLanguageTechnologyQuery { PageRequest = pageRequest };
            var result = await Mediator.Send(getListProgrammingLanguageTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnologyQuery)
        {
            var programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageTechnologyQuery);
            return Ok(programmingLanguageGetByIdDto);
        }
    }
}
