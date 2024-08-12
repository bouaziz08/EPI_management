using HSE.Models;

namespace HSE.Repository
{
    public interface IdemandeRepository
    {
        Task<IEnumerable<Demande>> GetAllAsync();
        Task<Demande> GetByIdAsync(int id);
        Task AddAsync(Demande demande);
        Task UpdateAsync(Demande demande);
        Task DeleteAsync(int id);
        Task<Equipement> GetpointureAsync(int pointure); 
        Task AddLogDemandeAsync(HistoriqueDeDemande logdemande);
    }
}
