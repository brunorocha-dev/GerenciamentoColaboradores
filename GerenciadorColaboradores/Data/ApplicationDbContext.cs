using GerenciadorColaboradores.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorColaboradores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ColaboradorModel> Gerenciador {  get; set; }

    }
}
