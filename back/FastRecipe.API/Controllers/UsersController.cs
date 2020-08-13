using System;
using System.Threading.Tasks;
using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Implementations;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using FastRecipe.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRecipe.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _repository;
        private MapperUser _mapper;

        public UsersController(UsersRepository repository, MapperUser mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserDTO userDto)
        {
            try
            {
                var user = _mapper.MapDTOToEntity(userDto);
                var result = await _repository.InsertAsync(user).ConfigureAwait(false);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _repository.DeleteAsync(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id).ConfigureAwait(false);
                var dto = _mapper.MapEntityToDTO(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserDTO update)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
