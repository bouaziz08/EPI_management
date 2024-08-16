using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSE.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    IdDemande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculeDemandeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEquip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    TypeDeDemande = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pointure = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdEmploye = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.IdDemande);
                });

            migrationBuilder.CreateTable(
                name: "DetailDemandes",
                columns: table => new
                {
                    IdDd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDemande = table.Column<int>(type: "int", nullable: false),
                    IdEquipement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailDemandes", x => x.IdDd);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    IdEmploye = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.IdEmploye);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    IdEquipement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Norme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurPrincipale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeEquip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pointure = table.Column<int>(type: "int", nullable: false),
                    IdSubcategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.IdEquipement);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    IdFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.IdFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "frequences",
                columns: table => new
                {
                    IdFrequence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPosition = table.Column<int>(type: "int", nullable: false),
                    IdSubcategorie = table.Column<int>(type: "int", nullable: false),
                    NomSubcategorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequenceChangement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frequences", x => x.IdFrequence);
                });

            migrationBuilder.CreateTable(
                name: "HistoriqueDeDemandes",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom_equip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdDemande = table.Column<int>(type: "int", nullable: false),
                    IdDemandeur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueDeDemandes", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "LogStocks",
                columns: table => new
                {
                    IdLogStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    IdFournisseur = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogStocks", x => x.IdLogStock);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    IdPosition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPosition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.IdPosition);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockActuelle = table.Column<int>(type: "int", nullable: false),
                    StockSecurite = table.Column<int>(type: "int", nullable: false),
                    QuantiteEntrer = table.Column<int>(type: "int", nullable: false),
                    QuantiteSortie = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEquipement = table.Column<int>(type: "int", nullable: false),
                    IdFournisseur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.IdStock);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    IdSubcategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSubcategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.IdSubcategory);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "DetailDemandes");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "frequences");

            migrationBuilder.DropTable(
                name: "HistoriqueDeDemandes");

            migrationBuilder.DropTable(
                name: "LogStocks");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
