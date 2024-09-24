using Microsoft.EntityFrameworkCore;
using projectoef.Models;

namespace projectoef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf6c"), Nombre = "Actividades Pendientes", Importancia = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf02"), Nombre = "Actividades Personales", Importancia = 50 });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Importancia);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf01"), CategoriaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf6c"), Titulo = "Estudiar C#", Descripcion = "Estudiar C# desde cero", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf05"), CategoriaId = Guid.Parse("5d8c1bcb-4242-41ae-ac34-f44922c5bf02"), Titulo = "Terminar de ver peliculas en Netflix", Descripcion = "Ver Netflix", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}