using HSE.Models;

namespace HSE.Services
{
    public interface IDemandeService
    {

        Task<IEnumerable<Demande>> GetAllAsync();
        Task<Demande> GetByIdAsync(int id);
        Task AddAsync(Demande demande, int poiture);
        Task UpdateAsync(int id, String newEtat, String newFeedback);
        Task DeleteAsync(int id);
    }
}
