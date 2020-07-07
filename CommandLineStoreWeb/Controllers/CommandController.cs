using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandLineStore.DataAccess.Contract;
using CommandLineStore.Entities;
using CommandLineStoreDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CommandLineStoreWeb.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandLineData _commandLineData;
        private readonly IMapper _mapper;

        public CommandController(ICommandLineData commandLineData, IMapper mapper)
        {
            _commandLineData = commandLineData;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommandLineViewDto>>> GetAll()
        {
            return Ok(_mapper.Map<List<CommandLineViewDto>>(await _commandLineData.GetAll()));
        }

        [HttpGet("{id}", Name ="Get")]
        public async Task<ActionResult<CommandLineViewDto>> Get(string id)
        {
            var foundCommand = await _commandLineData.GetById(id);

            if(foundCommand == null)
                return NotFound(id);

            return Ok(_mapper.Map<CommandLineViewDto>(foundCommand));
        }

        [HttpPost]
        public async Task<ActionResult<CommandLineViewDto>> Add(CommandLineCreateDto commandDto)
        {
            if(ModelState.IsValid)
            {
                var createCommand = _mapper.Map<CommandLine>(commandDto);

                if(await _commandLineData.Add(createCommand))
                    return CreatedAtRoute(nameof(Get), new { id = createCommand.Id }, createCommand);
            }

            return ValidationProblem(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCommand = await _commandLineData.GetById(id);

            if(deleteCommand == null)
            {
                return NotFound(deleteCommand);
            }
            else
            {
                if(await _commandLineData.Delete(id))
                    return NoContent();
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, JsonPatchDocument<CommandLineOperationDto> jsonPatchDoc)
        {
            var updateCommand = await _commandLineData.GetById(id);

            if(updateCommand == null)
                return NotFound(updateCommand);

            var commandToPatch = _mapper.Map<CommandLineOperationDto>(updateCommand);

            jsonPatchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(jsonPatchDoc))
                return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, updateCommand);

            if (await _commandLineData.Update(updateCommand))
                return NoContent();

            return BadRequest();
        }
    }
}
