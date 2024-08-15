using HSE.Models;

namespace HSE.Services
{
    public interface IStockService
    {
        //Task<IEnumerable<Stock>> GetAllAsync();
        Task AddAsync(Stock stock);
        Task UpdateAsync(int id);
    }
}
