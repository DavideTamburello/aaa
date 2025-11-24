using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TamburelloDavideMusicManager.Model;

namespace TamburelloDavideMusicManager.Data;

public class MusicContext:DbContext
{
    readonly string DbPath;
    public MusicContext()
    {
        var folder = AppContext.BaseDirectory;
        DbPath = Path.Combine(folder, "../../../MusicContext.db");
    }

    public DbSet<Etichetta> Etichette { get; set; }
    public DbSet<Cantante> Cantanti { get; set; }
    public DbSet<Festival> Festival { get; set; }
    public DbSet<Esibizione> Esibizioni { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cantante>()
            .HasOne(c => c.Etichetta)
            .WithMany(e => e.Cantanti)
            .HasForeignKey(c => c.EtichettaId)
            .IsRequired();
        
        modelBuilder.Entity<Esibizione>()
            .HasKey(e => new {e.FestivalId, e.CantanteId});
        
        modelBuilder.Entity<Esibizione>()
            .HasOne(e => e.Festival)
            .WithMany(f => f.Esibizioni)
            .HasForeignKey(e => e.FestivalId)
            .IsRequired();

        modelBuilder.Entity<Esibizione>()
            .HasOne(e => e.Cantante)
            .WithMany(c => c.Esibizioni)
            .HasForeignKey(e => e.CantanteId)
            .IsRequired();
    }
}
