using HSE.Models;
using Microsoft.EntityFrameworkCore;
using HSE.Repository;

namespace HSE.Services
{

    public class servicesDemande: IDemandeService
    {

    private readonly IdemandeRepository _DemandeRepository;

        public servicesDemande(IdemandeRepository repository)
        {
            _DemandeRepository = repository;
        }

        public async Task<IEnumerable<Demande>> GetAllAsync()
        {
            return await _DemandeRepository.GetAllAsync();
        }

        public async Task<Demande> GetByIdAsync(int id)
        {
            return await _DemandeRepository.GetByIdAsync(id);
        }
    
        public async Task AddAsync(Demande demande, int pointure)
        {

            var p = await _DemandeRepository.GetpointureAsync(pointure);

            if (p == null)
            {
                Console.WriteLine("ERRROR!!!!!!!!!!!!!!");
            }
            else    
            {
                demande.Etat = "created";

                await _DemandeRepository.AddAsync(demande);

                var logdemande = new HistoriqueDeDemande
                {
                    Action = "creation",
                    Etat = demande.Etat,
                    nom_equip = demande.NomEquip,
                    DateModification = DateTime.Now,
                    IdUtilisateur = demande.IdEmploye,
                    IdDemande = demande.IdDemande,
                    IdDemandeur = demande.IdUtilisateur
                };
    
            await _DemandeRepository.AddLogDemandeAsync(logdemande);
           }

        }
        
        public async Task UpdateAsync(int id, String newEtat, String newFeedback)
        {

            var demande = await _DemandeRepository.GetByIdAsync(id);

            if (demande.Etat == "created" && demande.TypeDeDemande == "Special")
            {
                demande.Etat = "passdoctor";
            }
            else
            {
                demande.Etat = newEtat;
            }

            if (demande.Etat == "reject")
            {
                demande.Feedback = newFeedback;
            }

            await _DemandeRepository.UpdateAsync(demande);

            var logdemande = new HistoriqueDeDemande
            {
                Action = "Update",
                Etat = demande.Etat,
                nom_equip = demande.NomEquip,
                DateModification = DateTime.Now,
                IdUtilisateur = demande.IdEmploye,
                IdDemande = demande.IdDemande,
                IdDemandeur = demande.IdUtilisateur
            };
    
        await _DemandeRepository.AddLogDemandeAsync(logdemande);


        }
        
        public async Task DeleteAsync(int id)
        {

            await _DemandeRepository.DeleteAsync(id);

        }
    }
}

