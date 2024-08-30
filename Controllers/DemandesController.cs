using HSE.Models;
using HSE.NewFolder;
using HSE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HSE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandesController : ControllerBase
    {

       /* public async User findSupervisorAsync(User emp)
        {
            return await _context.Users.where(u => u.id == emp.superiorId).FirstAsync();
        }
        [Authorize(Roles = "Medecin")]
        public async Demande afficher_demande()
        {

            return await _context.Demande.where(u => u.type_demande == "special" && u.Etat == "pass").ToListAsync();
        }

        [Authorize(Roles = "User")]
        public async Demande afficher_demande(User emp)
        {

            return await _context.Demande.where(u => u.id_utilisateur == emp.id_utilisateur).ToListAsync();
        }

        [Authorize(Roles = "HSE")]
        public async Demande afficher_demande()
        {

            return await _context.Demande.where(u => u.Etat == "pass").ToListAsync();
        }

        [Authorize(Roles = "magasin")]
        public async Demande afficher_demande()
        {

            return await _context.Demande.where(u => u.Etat == "valid").ToListAsync();
        }
       */
        private readonly IDemandeService _ServiceDemande;
        public DemandesController(IDemandeService servicesDemande)
        {

            _ServiceDemande = servicesDemande;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDemande(int id)
        {
            var demande = await _ServiceDemande.GetByIdAsync(id);
            Console.WriteLine("/****************/",demande,"/*******************************/");
            if (demande == null)
            {
                return NotFound();
            }
            return Ok(demande);
        }

       
        ////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> CreateDemande(AddDemandeDTO demandeDTO)
        {
            await _ServiceDemande.AddAsync(demandeDTO);

            return CreatedAtAction(nameof(GetDemande), new { id = demandeDTO.IdDemande }, demandeDTO);

        }
        ///////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> valid_demandeAsync(int id,String newEtat, String newFeedback)
        {
            var demande = await _ServiceDemande.GetByIdAsync(id);

            if (id != demande.IdDemande)
            {
                return BadRequest();
            }

            await _ServiceDemande.UpdateAsync(id, newEtat, newFeedback);
            return NoContent();

        }
        ///////////////////////////////////////////////////////////////////
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemande(int id)
        {
            await _ServiceDemande.DeleteAsync(id);
            return NoContent();

        }

    }
}
