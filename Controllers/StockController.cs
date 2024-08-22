using HSE.Models;
using HSE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _ServiceStock;
        public StockController(IStockService servicesStock)
        {
            _ServiceStock = servicesStock;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Getstock(int id)
        {
            var stock = await _ServiceStock.GetByIdAsync(id);
            Console.WriteLine("/****************/", stock, "/*******************************/");
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        ////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> AjouterStock(Stock stock, int id_equip, int quantite_entre)
        {
            
            await _ServiceStock.AddAsync(stock, id_equip, quantite_entre);

            return CreatedAtAction(nameof(Getstock), new { id = stock.IdStock }, stock);

        }
        ///////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> modifierstock(int id, int quantite_sortie)
        {
            var stock = await _ServiceStock.GetByIdAsync(id);

            if (id != stock.IdStock)
            {
                return BadRequest();
            }

            await _ServiceStock.UpdateAsync(id, quantite_sortie);
            return NoContent();

        }
    }
}
