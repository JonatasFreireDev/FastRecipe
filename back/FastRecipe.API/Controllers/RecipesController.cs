using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FastRecipe.API.Controllers
{
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IGenericRepository<Recipe> _repository;
        private IMapper<RecipeDTO, Recipe> _mapper;

        public RecipesController(IGenericRepository<Recipe> repository, IMapper<RecipeDTO, Recipe> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);
                var dto = _mapper.MapEntityToDTO(entity);

                return Ok(dto);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insert([FromBody] RecipeDTO recipeDto)
        {
            try
            {
                var recipe = _mapper.MapDTOToEntity(recipeDto);
                var result = await _repository.InsertAsync(recipe).ConfigureAwait(false);

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
    }
}
