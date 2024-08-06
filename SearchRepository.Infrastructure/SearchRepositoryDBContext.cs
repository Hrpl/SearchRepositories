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
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5435;Database=postgres;Username=postgres;Password=12345;Pooling=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Repository>(ConfigureRepository);
    }
    /*private static void ConfigureRepository(EntityTypeBuilder<Repository> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }*/
}
