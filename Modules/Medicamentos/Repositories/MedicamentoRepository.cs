using FarmaciaV1Api.Data;
using FarmaciaV1Api.Modules.Medicamentos.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaV1Api.Modules.Medicamentos.Repositories;

public class MedicamentoRepository : IMedicamentoRepository
{
    private readonly FarmaciaDbContext _context;

    public MedicamentoRepository(FarmaciaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos.AsNoTracking().ToListAsync();
    }

    public async Task<Medicamento?> GetByIdAsync(Guid id)
    {
        return await _context.Medicamentos.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Medicamento> CreateAsync(Medicamento medicamento)
    {
        _context.Medicamentos.Add(medicamento);
        await _context.SaveChangesAsync();
        return medicamento;
    }

    public async Task<Medicamento> UpdateAsync(Medicamento medicamento)
    {
        _context.Medicamentos.Update(medicamento);
        await _context.SaveChangesAsync();
        return medicamento;
    }

    public async Task DeleteAsync(Medicamento medicamento)
    {
        _context.Medicamentos.Remove(medicamento);
        await _context.SaveChangesAsync();
    }
}