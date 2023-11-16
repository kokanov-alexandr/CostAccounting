using CostAccounting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CostAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CategoriesApiController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GatCategoryById([FromRoute] int id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]

        public async Task<IActionResult> AddCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            dbContext.Remove(category);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
