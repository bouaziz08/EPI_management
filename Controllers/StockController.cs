using HSE.NewFolder;
using HSE.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AjouterStock(AddStockDTO stockDTO)
        {
            
            await _ServiceStock.AddAsync(stockDTO);

            return CreatedAtAction(nameof(Getstock), new { id = stockDTO.IdEquipement }, stockDTO);

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
