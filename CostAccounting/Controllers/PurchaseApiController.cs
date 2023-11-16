using CostAccounting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CostAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseApiController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public PurchaseApiController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchase()
        {
            return Ok(await dbContext.Purchases.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseById([FromRoute] int id)
        {
            var purchase = await dbContext.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase(Purchase purchase)
        {
            await dbContext.Purchases.AddAsync(purchase);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeletePurchase([FromRoute] int id)
        {
            var purchase = await dbContext.Purchases.FindAsync(id);

            if (purchase == null) 
            {
                return NotFound();
            }
            dbContext.Remove(purchase);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
