using System;
using System.Threading.Tasks;
using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Implementations;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRecipe.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _repository;
        private IMapper<UserDTO, User> _mapper;

        public UsersController(IGenericRepository<User> repository, MapperUser mapper)
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
                await _repository.InsertAsync(user).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteAsync(id);
        }
    }
}
