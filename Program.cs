using Fundamentos_Entity_Framework_C_.Contexts;
using Fundamentos_Entity_Framework_C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(opt => opt.UseInMemoryDatabase("TaskDB"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TaskContext dbContext) =>
{
   dbContext.Database.EnsureCreated();
   return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});


app.MapGet("/api/homeworks", async ([FromServices] TaskContext dbContext) =>
{
    //return Results.Ok(dbContext.Homeworks.Include(p=>p.Category).Where(p => p.Priority == Fundamentos_Entity_Framework_C_.Models.Priority.Low));
    return Results.Ok(dbContext.Homeworks.Include(p=>p.Category));
});

app.MapPost("/api/homeworks", async ([FromServices] TaskContext dbContext, [FromBody] Homework homework) =>
{
    homework.HomeworkId = Guid.NewGuid();
    homework.CreatedAt = DateTime.Now;
    homework.UpdatedAt = DateTime.Now;
    await dbContext.AddAsync(homework);
    //await dbContext.Homeworks.AddAsync(homework);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/homeworks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] Homework homework, [FromRoute] Guid id) =>
{
    var actualHomework = dbContext.Homeworks.Find(id);

    if(actualHomework != null)
    {
        actualHomework.CategoryId = homework.CategoryId;
        actualHomework.Title = homework.Title;
        actualHomework.Description = homework.Description;
        actualHomework.Priority = homework.Priority;
        actualHomework.UpdatedAt = DateTime.Now;
        await dbContext.SaveChangesAsync();
        return Results.Ok();

    }
    return Results.NotFound();
});

app.MapDelete("/api/homeworks/{id}", async ([FromServices] TaskContext dbContext, [FromRoute] Guid id) =>
{
    var actualHomework = dbContext.Homeworks.Find(id);

    if(actualHomework != null)
    {
        dbContext.Homeworks.Remove(actualHomework);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapGet("/api/categories", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Categories);
});

app.Run();
