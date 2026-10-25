
using FarmaciaV1Api.Modules.Medicamentos.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaV1Api.Data;

public class FarmaciaDbContext : DbContext
{
    public FarmaciaDbContext(
        DbContextOptions<FarmaciaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Medicamento> Medicamentos { get; set; }
}
