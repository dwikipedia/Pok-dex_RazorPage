using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace AppContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pokemon>()
        //        .ToTable("Pokemon");
        //    modelBuilder.Entity<Pokemon>()
        //        .Property(s => s.PokemonId)
        //        .HasColumnName("PokemonId");
        //    modelBuilder.Entity<Pokemon>()
        //        .Property(s => s.Name)
        //        .IsRequired()
        //        .HasMaxLength(50);
        //    modelBuilder.Entity<Pokemon>()
        //        .Property(s => s.Name)
        //        .IsRequired(false);
        //}

        public DbSet<PokemonModel> Pokemons { get; set; }
    }
}
