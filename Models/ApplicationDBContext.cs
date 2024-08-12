using Microsoft.EntityFrameworkCore;

namespace HSE.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        {
            
            
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Demande> Demandes { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<DetailDemande> DetailDemandes { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Frequence> frequences { get; set; }
        public DbSet<HistoriqueDeDemande> HistoriqueDeDemandes { get; set; }
        public DbSet<LogStock> LogStocks { get; set; }
        public DbSet<Position> Positions{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Stock> Stocks{ get; set; }
        public DbSet<Subcategory> Subcategories{ get; set; }
        public DbSet<Utilisateur> Utilisateurs{ get; set; }


    }
    
    
}
