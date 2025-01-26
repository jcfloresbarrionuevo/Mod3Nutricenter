using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Infraestructure.DBContext;

public partial class AppDbContext :  DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PlanAlimentario> PlanAlimentario { get; set; }
    public virtual DbSet<Receta> Receta { get; set; }
    public virtual DbSet<IngredienteReceta> IngredienteReceta { get; set; }
    public virtual DbSet<TiempoComida> TiempoComida { get; set; }
    public virtual DbSet<PlanRecetaTiempo> PlanRecetaTiempo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<PlanAlimentario>()
        //.HasMany(p => p.PlanRecetaTiempos)
        //.WithOne()
        //.HasForeignKey(pl => pl.PlanAlimentarioId);

        //modelBuilder.Entity<PlanRecetaTiempo>()
        //.HasMany(p => p.PlanAlimentario)
        //.WithOne()
        //.HasForeignKey(r => r.Id);

        //modelBuilder.Entity<PlanRecetaTiempo>()
        //.HasMany(p => p.Recetas)
        //.WithOne()
        //.HasForeignKey(r => r.Id);

        //modelBuilder.Entity<PlanRecetaTiempo>()
        //.HasMany(p => p.TiemposComida)
        //.WithOne()
        //.HasForeignKey(r => r.Id);

        modelBuilder.Entity<Receta>()
            .HasMany(p => p.Ingredientes)
            .WithOne()
            .HasForeignKey(i=>i.RecetaId);
    }
    //
}
