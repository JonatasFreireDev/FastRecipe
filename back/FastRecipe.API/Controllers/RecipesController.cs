using FastRecipe.Domain.AggregatesModel.RecipeAggregate;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Insert([FromBody] RecipeDTO dto)
        {
            return Ok(dto);
        }
    }
}
