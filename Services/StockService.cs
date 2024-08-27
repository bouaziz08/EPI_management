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

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _StockRepository.GetAllAsync();
        }

       /* public async Task<Stock> GeteleBydateAsync(DateTime sdate, DateTime edate)
        {
            var startdate = await _StockRepository.GetBydateAsync(sdate);
            var enddate = await _StockRepository.GetBydateAsync(edate);

            
        }*/

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _StockRepository.GetByIdAsync(id);
        }
        public async Task<Stock> GetByEquipAsync(int id)
        {
            return await _StockRepository.GetByEquipAsync(id);
        }
        public async Task AddAsync(Stock stock,int id_equi, int quantite_entre)
        {
            var stockold = await _StockRepository.GetByEquipAsync(id_equi);
            stock.IdEquipement = id_equi;
            stock.StockActuelle = quantite_entre + stockold.StockActuelle;
            stock.QuantiteEntrer = quantite_entre;
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

        public async Task UpdateAsync(int id, int quantite_sortie)
        {
            var stock = await _StockRepository.GetByIdAsync(id);

            stock.StockActuelle -= quantite_sortie;
            stock.QuantiteSortie = quantite_sortie;
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

