using FarmaciaV1Api.Modules.Medicamentos.Dtos;

namespace FarmaciaV1Api.Modules.Medicamentos.Services;

public interface IMedicamentoService
{
    Task<List<MedicamentoResponseDto>> GetAllAsync();
    Task<MedicamentoResponseDto?> GetByIdAsync(Guid id);
    Task<MedicamentoResponseDto> CreateAsync(CreateMedicamentoDto dto);
    Task<MedicamentoResponseDto?> UpdateAsync(Guid id, UpdateMedicamentoDto dto);
    Task<bool> DeleteAsync(Guid id);
}