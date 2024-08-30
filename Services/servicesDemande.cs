using HSE.Models;
using Microsoft.EntityFrameworkCore;
using HSE.Repository;
using HSE.NewFolder;

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
    
        public async Task AddAsync(AddDemandeDTO DemandeDTO)
        {

            var p = await _DemandeRepository.GetpointureAsync(DemandeDTO.Pointure);

            if (p == null)
            {
                Console.WriteLine("ERRROR!!!!!!!!!!!!!!");
            }
            else
            {
                Demande demande = new()
                {
                    MatriculeDemandeur = DemandeDTO.MatriculeDemandeur,
                    nomequipement = DemandeDTO.nomequipement,
                    Quantite = DemandeDTO.Quantite,
                    pointure = DemandeDTO.Pointure,
                    TypeDeDemande = DemandeDTO.TypeDeDemande,
                    Etat = "created",
                    DateDeDemande = DateTime.Now
                };
                await _DemandeRepository.AddAsync(demande);
                var logdemande = new HistoriqueDeDemande
                {
                    Action = "creation",
                    Etat = demande.Etat,
                    nom_equip = demande.nomequipement,
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
                nom_equip = demande.nomequipement,
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

