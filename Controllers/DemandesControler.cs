using HSE.Models;
using HSE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HSE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandesControler : ControllerBase
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDemande(int id)
        {
            var demande = await _ServiceDemande.GetByIdAsync(id);
            if (demande == null)
            {
                return NotFound();
            }
            return Ok(demande);
        }

        public DemandesControler(IDemandeService servicesDemande)
        {

            _ServiceDemande = servicesDemande;
        }
        ////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> CreateDemande(Demande demande)
        {
            await _ServiceDemande.AddAsync(demande);

            return CreatedAtAction(nameof(GetDemande), new { id = demande.IdDemande }, demande);

        }
        ///////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> valid_demandeAsync(int id, Demande demande,String newEtat, String newFeedback)
        {
            if (id != demande.IdDemande)
            {
                return BadRequest();
            }

            await _ServiceDemande.UpdateAsync(id, newEtat, newFeedback);
            return NoContent();

        }
        ///////////////////////////////////////////////////////////////////
        [Authorize(Roles = "User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemande(int id)
        {
            await _ServiceDemande.DeleteAsync(id);
            return NoContent();

        }

    }
}
