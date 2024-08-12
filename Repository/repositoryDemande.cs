using HSE.Models;
using Microsoft.EntityFrameworkCore;

namespace HSE.Repository
{
    public class DemandeRepository : IdemandeRepository
    {
        private readonly ApplicationDBContext _context;

        public DemandeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Demande>> GetAllAsync()
        {
            
            return await _context.Demandes.ToListAsync();
        }

        public async Task<Demande> GetByIdAsync(int id)
        {
            return await _context.Demandes.FirstOrDefaultAsync(p => p.IdDemande == id);
        }

      
        public async Task AddAsync(Demande demande)
        {
            await _context.Demandes.AddAsync(demande);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Demande demande)
        {
            _context.Demandes.Update(demande);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);

            if (demande != null)
            {
                _context.Demandes.Remove(demande);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddLogDemandeAsync(HistoriqueDeDemande logdemande)
        {
            _context.HistoriqueDeDemandes.Add(logdemande);
            await _context.SaveChangesAsync();
        }

        public async Task<Equipement> GetpointureAsync(int poiture)
        {
            return await _context.Equipements.FirstOrDefaultAsync(p => p.pointure == poiture);

        }
    }
}
