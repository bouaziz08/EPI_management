using HSE.Models;
using HSE.NewFolder;
using System.Threading.Tasks;

namespace HSE.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        // Task<Stock> GeteleBydateAsync(DateTime startdate, DateTime enddate);

        Task<Stock> GetByEquipAsync(int id);
        Task<Stock> GetByIdAsync(int id);
        Task AddAsync(AddStockDTO stockDTO);
        Task UpdateAsync(int id, UpdateStockDTO updateStock);
    }
}
