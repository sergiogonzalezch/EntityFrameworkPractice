using Fundamentos_Entity_Framework_C_.Models;
using Microsoft.EntityFrameworkCore;

namespace Fundamentos_Entity_Framework_C_.Contexts;

public class TaskContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Homework> Homeworks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Category> categoriesInit = new List<Category>();

        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("d638cf70-1148-430a-9c06-04439e6c90c6"),
            Name = "Actividades pendientes",
            Description = "Actividades sin realizar",
            Time = 0
        });

        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("d638cf70-1148-430a-9c06-04439e6c90c7"),
            Name = "Actividades Personales",
            Description = "Actividades de mi interes personal",
            Time = 5
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Time);

            category.HasData(categoriesInit);

        });

        List<Homework> homeworksInit = new List<Homework>();

        homeworksInit.Add(new Homework()
        {
            HomeworkId = Guid.Parse("2fd130f6-f752-4e5e-ae63-1c1410a2c920"),
            CategoryId = Guid.Parse("d638cf70-1148-430a-9c06-04439e6c90c7"), 
            Title = "Preparar informe mensual",
            Description = "Elaborar y revisar el informe de rendimiento del mes",
            Priority = Priority.Low,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        homeworksInit.Add(new Homework()
        {
            HomeworkId = Guid.Parse("2fd130f6-f752-4e5e-ae63-1c1410a2c921"), 
            CategoryId = Guid.Parse("d638cf70-1148-430a-9c06-04439e6c90c6"), 
            Title = "Leer un libro de desarrollo personal",
            Description = "Seleccionar y leer al menos un capítulo del libro",
            Priority = Priority.Medium,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        modelBuilder.Entity<Homework>(homework =>
        {
            homework.ToTable("Homework");
            homework.HasKey(p => p.HomeworkId);
            homework.HasOne(p => p.Category).WithMany(p => p.Homeworks).HasForeignKey(p => p.CategoryId);
            homework.Property(p => p.Title).IsRequired().HasMaxLength(200);
            homework.Property(p => p.Description);
            homework.Property(p => p.Priority);
            homework.Property(p => p.CreatedAt);
            homework.Property(p => p.UpdatedAt);
            homework.Ignore(p => p.Summary);
        });

        modelBuilder.Entity<Homework>().HasData(homeworksInit);

    }
}
