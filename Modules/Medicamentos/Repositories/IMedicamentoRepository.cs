using FarmaciaV1Api.Modules.Medicamentos.Entities;

namespace FarmaciaV1Api.Modules.Medicamentos.Repositories;

public interface IMedicamentoRepository
{
    Task<List<Medicamento>> GetAllAsync();
    Task<Medicamento?> GetByIdAsync(Guid id);
    Task<Medicamento> CreateAsync(Medicamento medicamento);
    Task<Medicamento> UpdateAsync(Medicamento medicamento);
    Task DeleteAsync(Medicamento medicamento);
}