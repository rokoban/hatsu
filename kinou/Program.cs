using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InstitutionDb>(opt => opt.UseInMemoryDatabase("Institutions"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/institutions", async (InstitutionDb db) => 
    await db.Institutions.ToListAsync());

app.MapGet("/institutions/{id}", async (int id, InstitutionDb db) => 
    await db.Institutions.FindAsync(id) is Institution institution ? Results.Ok(institution) : Results.NotFound());

app.MapPost("/institutions", async (Institution institution, InstitutionDb db) => {
    db.Institutions.Add(institution);
    await db.SaveChangesAsync();
    return Results.Created($"/institutions/{institution.Id}", institution);
});

app.MapPut("/institutions/{id}", async (int id, Institution inputInstitution, InstitutionDb db) => {
    var institution = await db.Institutions.FindAsync(id);
    if (institution is null) return Results.NotFound();
    
    institution.Name = inputInstitution.Name;
    institution.Email = inputInstitution.Email;
    institution.Location = inputInstitution.Location;
    institution.PhoneNumbers = inputInstitution.PhoneNumbers;
    institution.Type = inputInstitution.Type;
    institution.Website = inputInstitution.Website;

    await db.SaveChangesAsync();
    
    return Results.NoContent();
});

app.MapDelete("/institutions/{id}", async (int id, InstitutionDb db) => {
    if (await db.Institutions.FindAsync(id) is Institution institution) {
        db.Institutions.Remove(institution);
        await db.SaveChangesAsync();
        
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
