using HSE.Models;
using HSE.NewFolder;
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

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _StockRepository.GetAllAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _StockRepository.GetByIdAsync(id);
        }
        public async Task<Stock> GetByEquipAsync(int id)
        {
            return await _StockRepository.GetByEquipAsync(id);
        }
        public async Task AddAsync(AddStockDTO stockDTO)
        {
            var stockold = await _StockRepository.GetByEquipAsync(stockDTO.IdEquipement);
            Stock stock = new()
            {
                StockActuelle = stockDTO.QuantiteEntrer + stockold.StockActuelle,
                QuantiteEntrer = stockDTO.QuantiteEntrer,
                QuantiteSortie = 0,
                StockSecurite = stockold.StockSecurite,
                Date = DateTime.Now,
                IdEquipement = stockold.IdEquipement,
                IdFournisseur = stockold.IdFournisseur
            };
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

        public async Task UpdateAsync(int id, UpdateStockDTO UpdateStock)
        {
            var stock = await _StockRepository.GetByIdAsync(id);
            stock.IdEquipement = UpdateStock.IdEquipement;
            stock.StockActuelle -= UpdateStock.QuantiteSortie;
            stock.QuantiteSortie = UpdateStock.QuantiteSortie;
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

