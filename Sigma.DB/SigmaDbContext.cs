using Microsoft.EntityFrameworkCore;
using Sigma.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.DB
{
    public class SigmaDbContext : DbContext
    {
        public SigmaDbContext(DbContextOptions<SigmaDbContext> options) : base(options)
        {

        }
        public DbSet<ECandidate> Candidates { get; set; }
       
    }
}
