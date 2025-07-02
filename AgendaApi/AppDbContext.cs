using AgendaApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
           

        //public DbSet<User> Users { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
