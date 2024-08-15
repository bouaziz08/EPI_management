using HSE.Models;
using HSE.Repository;

namespace HSE.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _StockRepository;

        public StockService(IStockRepository repository)
        {
            _StockRepository = repository;
        }

        public async Task AddAsync(Stock stock)
        {

            await _StockRepository.AddAsync(stock);

            var logstock = new LogStock
            {
                Action = "creation",
                Quantite = stock.StockActuelle,
                DateModification = DateTime.Now,
                IdFournisseur = stock.IdFournisseur,
                
            };

            await _StockRepository.AddLogStockAsync(logstock);
        }

        public async Task UpdateAsync(int id)
        {
            var stock = await _StockRepository.GetByIdAsync(id);

            await _StockRepository.UpdateAsync(stock);

            var logstock = new LogStock
            {
                Action = "Update",
                Quantite = stock.StockActuelle,
                DateModification = DateTime.Now,
                IdFournisseur = stock.IdFournisseur,
                
            };

            await _StockRepository.AddLogStockAsync(logstock);
        }
    }
}

