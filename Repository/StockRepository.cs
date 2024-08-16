using HSE.Models;
using Microsoft.EntityFrameworkCore;

namespace HSE.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }
        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(p => p.IdStock == id);
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
        }

        public async Task AddLogStockAsync(LogStock logstock)
        {
            _context.LogStocks.Add(logstock);
            await _context.SaveChangesAsync();
        }

        public async Task<Stock> GetBydateAsync(DateTime date)
        {
            return await _context.Stocks.FirstOrDefaultAsync(p => p.Date == date);
        }
    }

}
