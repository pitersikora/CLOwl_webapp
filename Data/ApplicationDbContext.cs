using ClowlWebApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClowlWebApp.Data
{
    // W razie potrzeby utworzenia zmian w bazie danych 
    // Tools > Nuget Package Manager > Packet Manager Console
    // Add-migration <nazwa>
    // Remowe-migration w razie usunięcia migracji
    // update-database <nazwa> w celu zapisania modeli bazy danych w zadanej wersji
    // (bez nazwy zapisze bazę danych w najnowszej migracji)
    public class ApplicationUser : IdentityUser
    {
        // bez określenia atrybutu StringLength konfiguracja zadaje "Max"
        // która jest zbyt duża na nasze potrzeby
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address1 { get; set; }
        [StringLength(250)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string PostCode { get; set; }
    }
    // Klasa dziedziczy kolumny które są zdefiniowane w klasie ApplicationUser
    // Customowe tabele jako DbSet
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<Content> Content { get; set; }

    }
}
