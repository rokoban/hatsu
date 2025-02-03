using Microsoft.EntityFrameworkCore;

class InstitutionDb : DbContext {
    public InstitutionDb(DbContextOptions<InstitutionDb> options) : base(options) { }
    public DbSet<Institution> Institutions => Set<Institution>();
}