using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedeSocialAT.Models;

namespace RedeSocialAT.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<RedeSocialAT.Models.Perfil> Perfil { get; set; }
        public DbSet<RedeSocialAT.Models.Post> Post { get; set; }
        public DbSet<RedeSocialAT.Models.Comentario> Comentario { get; set; }
    }
}