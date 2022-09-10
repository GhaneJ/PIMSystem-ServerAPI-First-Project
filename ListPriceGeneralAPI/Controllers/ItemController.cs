using ListPriceGeneralAPI.Data;
using ListPriceGeneralAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListPriceGeneralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly PriceListDbContext _dbContext;

        public ItemController(PriceListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return _dbContext.Items.ToList();
        }

        [HttpGet("{itemName}")]
        public ActionResult<Item> GetUser(string itemName)
        {
            return _dbContext.Items.FirstOrDefault(x => x.ItemName == itemName);
        }

        [HttpPost("createitem")]
        public async Task<ActionResult<string>> CreateItem(Item item)
        {
            var newItem = new Item()
            {
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice,
            };

            _dbContext.Items.Add(newItem);
            await _dbContext.SaveChangesAsync();

            return "Item created successfully";
        }

        [HttpPost("updateitem")]
        public async Task<ActionResult<string>> UpdateItem(Item item)
        {
            var currentItem = _dbContext.Items.Where(x => x.ItemName == item.ItemName).FirstOrDefault();
            if (currentItem != null)
            {
                currentItem.ItemName = item.ItemName;
                currentItem.ItemPrice = item.ItemPrice;
            }
            else
            {
                return "User not found";
            }
            await _dbContext.SaveChangesAsync();

            return "Item updated successfully";
        }

        [HttpDelete("deleteitem")]
        public async Task<ActionResult<string>> DeleteItem(string itemName)
        {
            if (itemName == null)
            {
                return BadRequest("Not a valid item");
            }
            var currentItem = _dbContext.Items.Where(x => x.ItemName == itemName).FirstOrDefault();

            if (currentItem != null)
            {
                _dbContext.Entry(currentItem).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return "Item not found";
            }
            return "Item deleted successfully";
        }
    }
}
