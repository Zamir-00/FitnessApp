using Microsoft.EntityFrameworkCore;
namespace webApi
{
    public class FitnessAppDbContext : DbContext
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) 
        { }
        public DbSet<Exercise> Exercises {get; set;}
        public DbSet<Session> Sessions {get; set;}
        public DbSet<Account> Accounts {get; set;}
    }
}
