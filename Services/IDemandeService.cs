using HSE.Models;
using HSE.NewFolder;

namespace HSE.Services
{
    public interface IDemandeService
    {

        Task<IEnumerable<Demande>> GetAllAsync();
        Task<Demande> GetByIdAsync(int id);
        Task AddAsync(AddDemandeDTO demandeDTO);
        Task UpdateAsync(int id, String newEtat, String newFeedback);
        Task DeleteAsync(int id);
    }
}
