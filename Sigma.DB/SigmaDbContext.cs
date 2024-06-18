using Microsoft.EntityFrameworkCore;
using Sigma.Entity;


namespace Sigma.DB
{
    public class SigmaDbContext : DbContext
    {
        public SigmaDbContext(DbContextOptions<SigmaDbContext> options) : base(options)
        {

        }
        public SigmaDbContext()
        {

        }

        
        public DbSet<ECandidate> Candidates { get; set; }
       
    }
}
