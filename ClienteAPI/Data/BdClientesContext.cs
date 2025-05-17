using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class BdClientesContext : DbContext
    {
        public BdClientesContext(DbContextOptions<BdClientesContext> options)
            : base(options)
        {
        }

        // Agrega tus DbSet<Entidad> aquí si tienes entidades
    }
} 