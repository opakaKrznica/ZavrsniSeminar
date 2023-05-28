using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expert.WebShop.Backend.Api.MojaBaza;

namespace Expert.WebShop.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCardsController : ControllerBase
    {
        private readonly WebShopVjezba2Context _context;

        public ShoppingCardsController(WebShopVjezba2Context context)
        {
            _context = context;
        }

        // GET: api/ShoppingCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCard>>> GetShoppingCards()
        {
          if (_context.ShoppingCards == null)
          {
              return NotFound();
          }
            return await _context.ShoppingCards.ToListAsync();
        }

        // GET: api/ShoppingCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCard>> GetShoppingCard(int id)
        {
          if (_context.ShoppingCards == null)
          {
              return NotFound();
          }
            var shoppingCard = await _context.ShoppingCards.FindAsync(id);

            if (shoppingCard == null)
            {
                return NotFound();
            }

            return shoppingCard;
        }

        // PUT: api/ShoppingCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCard(int id, ShoppingCard shoppingCard)
        {
            if (id != shoppingCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCardExists(id))
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

        // POST: api/ShoppingCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingCard>> PostShoppingCard(ShoppingCard shoppingCard)
        {
          if (_context.ShoppingCards == null)
          {
              return Problem("Entity set 'WebShopVjezba2Context.ShoppingCards'  is null.");
          }
            _context.ShoppingCards.Add(shoppingCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCard", new { id = shoppingCard.Id }, shoppingCard);
        }

        // DELETE: api/ShoppingCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCard(int id)
        {
            if (_context.ShoppingCards == null)
            {
                return NotFound();
            }
            var shoppingCard = await _context.ShoppingCards.FindAsync(id);
            if (shoppingCard == null)
            {
                return NotFound();
            }

            _context.ShoppingCards.Remove(shoppingCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingCardExists(int id)
        {
            return (_context.ShoppingCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
