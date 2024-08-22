using HSE.Models;
using System.Threading.Tasks;

namespace HSE.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        // Task<Stock> GeteleBydateAsync(DateTime startdate, DateTime enddate);

        Task<Stock> GetByEquipAsync(int id);
        Task<Stock> GetByIdAsync(int id);
        Task AddAsync(Stock stock, int id_equip, int qe);
        Task UpdateAsync(int id, int qs);
    }
}
