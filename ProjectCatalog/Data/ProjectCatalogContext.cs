using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCatalog.Models;

namespace ProjectCatalog.Data
{
    public class ProjectCatalogContext : DbContext
    {
        public ProjectCatalogContext (DbContextOptions<ProjectCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectCatalog.Models.Repository> Repository { get; set; } = default!;
    }
}
