using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SearchRepository.Domen;
using SearchRepository.Domen.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SearchRepository.Infrastructure;

public class SearchRepositoryDBContext : DbContext
{

    public DbSet<SearchRequest> SearchRequests { get; set; }
    

    public SearchRepositoryDBContext(DbContextOptions<SearchRepositoryDBContext> opt) : base(opt)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=postgres;Username=postgres;Password=12345");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SearchRequest>(ConfigureRepository);
    }
    private static void ConfigureRepository(EntityTypeBuilder<SearchRequest> builder)
    {
        builder.Property(x => x.Id).IsRequired();
    }
}
