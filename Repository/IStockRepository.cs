using HSE.Models;

namespace HSE.Repository
{
    public interface IStockRepository
    {
        Task<Stock> GetByIdAsync(int id);
        Task<IEnumerable<Stock>> GetAllAsync();
        Task AddAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task AddLogStockAsync(LogStock logstock);
    }
}
