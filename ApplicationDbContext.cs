using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
    }
    
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Diretor> Diretores { get; set; }
}