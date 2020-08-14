using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FastRecipe.Domain.AggregatesModel.UserAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Implementations;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using FastRecipe.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastRecipe.API.Controllers
{
    [Route("v1/[controller]")]
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
                var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);
                var dto = _mapper.MapEntityToDTO(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
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
            var update = Builders<User>.Update;

            if (string.IsNullOrWhiteSpace(dto.Id))
                throw new ArgumentNullException(nameof(dto.Id), $"Field cannot be null or empty");

            var listOfUpdates = await GetUserAndCreateUpdatePerField(dto, update).ConfigureAwait(false);

            return update.Combine(listOfUpdates);
        }

        private async Task<List<UpdateDefinition<User>>> GetUserAndCreateUpdatePerField(UserDTO dto, UpdateDefinitionBuilder<User> update)
        {
            var listToReturn = new List<UpdateDefinition<User>>();

            var user = await _repository.GetByIdAsync(dto.Id).ConfigureAwait(false);

            if (user.Name != dto.Name && string.IsNullOrWhiteSpace(dto.Name) == false)
                listToReturn.Add(update.Set(p => p.Name, dto.Name));

            return listToReturn;
        }
    }
}
