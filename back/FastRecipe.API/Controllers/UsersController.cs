using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastRecipe.API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _repository;
        private IMapper<UserDTO, User> _mapper;

        public UsersController(IGenericRepository<User> repository, IMapper<UserDTO, User> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("")]
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
                var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);
                var dto = _mapper.MapEntityToDTO(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] UserDTO dto)
        {
            try
            {
                var update = await CreateUpdate(dto).ConfigureAwait(false);

                if (await _repository.UpdateAsync(dto.Id, update).ConfigureAwait(false))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<UpdateDefinition<User>> CreateUpdate(UserDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Id))
                throw new ArgumentNullException(nameof(dto.Id), $"Field cannot be null or empty");

            var user = await _repository.GetByIdAsync(dto.Id).ConfigureAwait(false);
            var listOfUpdates = GetUserAndCreateUpdatePerField(dto, user);

            return Builders<User>.Update.Combine(listOfUpdates);
        }

        private static List<UpdateDefinition<User>> GetUserAndCreateUpdatePerField(UserDTO dto, User user)
        {
            var update = Builders<User>.Update;
            var listOfUpdates = new List<UpdateDefinition<User>>();

            if (user.Name != dto.Name && string.IsNullOrWhiteSpace(dto.Name) == false)
                listOfUpdates.Add(update.Set(p => p.Name, dto.Name));

            return listOfUpdates;
        }
    }
}
