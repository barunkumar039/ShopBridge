using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryDetailsController : ControllerBase
    {
        private readonly ShopBridgeContext _context;

        public InventoryDetailsController(ShopBridgeContext context)
        {
            _context = context;
        }

        // GET: api/InventoryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDetails>>> GetInventoryDetails()
        {
            return await _context.InventoryDetails.ToListAsync();
        }

        // GET: api/InventoryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDetails>> GetInventoryDetails(int id)
        {
            var inventoryDetails = await _context.InventoryDetails.FindAsync(id);

            if (inventoryDetails == null)
            {
                return NotFound();
            }

            return inventoryDetails;
        }

        // PUT: api/InventoryDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryDetails(int id, InventoryDetails inventoryDetails)
        {
            if (id != inventoryDetails.InventoryId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InventoryDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryDetails>> PostInventoryDetails(InventoryDetails inventoryDetails)
        {
            _context.InventoryDetails.Add(inventoryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryDetails", new { id = inventoryDetails.InventoryId }, inventoryDetails);
        }

        // DELETE: api/InventoryDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryDetails(int id)
        {
            var inventoryDetails = await _context.InventoryDetails.FindAsync(id);
            if (inventoryDetails == null)
            {
                return NotFound();
            }

            _context.InventoryDetails.Remove(inventoryDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryDetailsExists(int id)
        {
            return _context.InventoryDetails.Any(e => e.InventoryId == id);
        }
    }
}
