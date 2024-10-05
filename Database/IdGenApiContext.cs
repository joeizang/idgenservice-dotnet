using System;
using System.Diagnostics.CodeAnalysis;
using idgenapi.IdGeneratedFeature;
using Microsoft.EntityFrameworkCore;

namespace idgenapi.Database;

public class IdGenApiContext : DbContext
{
    public IdGenApiContext(DbContextOptions<IdGenApiContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdGenApiContext).Assembly);
    }

    public DbSet<IdGenerated> IdsGenerated { get; set; } = default!;
}
