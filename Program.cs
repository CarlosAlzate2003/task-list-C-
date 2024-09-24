using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectoef;
using projectoef.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/dbconexion", async ([FromServices] TareasContext DbContext) =>
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + DbContext.Database.IsInMemory());
});

app.MapPost("/api/Ingresartareas", async ([FromServices] TareasContext DbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await DbContext.AddAsync(tarea);
    await DbContext.SaveChangesAsync();
    return Results.Ok("La tarea ha sido ingresado");
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext DbContext) =>
{
    return Results.Ok(DbContext.Tareas);
});

app.MapPut("/api/actualizar/{id}", async ([FromServices] TareasContext DbContext, [FromRoute] Guid id, [FromBody] Tarea tarea) =>
{
    var tareaEncontrada = await DbContext.Tareas.FindAsync(id);

    if (tareaEncontrada is null)
    {
        return Results.NotFound("No se ha encontrado " + id);
    }
    else
    {
        tareaEncontrada.Titulo = tarea.Titulo;
        tareaEncontrada.Descripcion = tarea.Descripcion;
        tareaEncontrada.PrioridadTarea = tarea.PrioridadTarea;
        tareaEncontrada.FechaCreacion = DateTime.Now;

        DbContext.Update(tareaEncontrada);
        await DbContext.SaveChangesAsync();
        return Results.Ok("Se ha actualizado el " + id);
    }
});

app.MapDelete("/api/eliminar/{id}", async ([FromServices] TareasContext DbContext, [FromRoute] Guid id) =>
{
    var tareaEncontrada = await DbContext.Tareas.FindAsync(id);

    if (tareaEncontrada is null)
    {
        return Results.NotFound("No se ha encontrado " + id);
    }
    else
    {
        DbContext.Remove(tareaEncontrada);
        await DbContext.SaveChangesAsync();
        return Results.Ok("Se ha eliminado el " + id);
    }
});


app.Run();
