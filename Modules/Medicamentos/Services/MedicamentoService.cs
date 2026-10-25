using FarmaciaV1Api.Modules.Medicamentos.Dtos;
using FarmaciaV1Api.Modules.Medicamentos.Entities;
using FarmaciaV1Api.Modules.Medicamentos.Repositories;

namespace FarmaciaV1Api.Modules.Medicamentos.Services;

public class MedicamentoService : IMedicamentoService
{
    private readonly IMedicamentoRepository _repository;

    public MedicamentoService(IMedicamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicamentoResponseDto>> GetAllAsync()
    {
        var medicamentos = await _repository.GetAllAsync();
        return medicamentos.Select(ToResponse).ToList();
    }

    public async Task<MedicamentoResponseDto?> GetByIdAsync(Guid id)
    {
        var medicamento = await _repository.GetByIdAsync(id);
        return medicamento is null ? null : ToResponse(medicamento);
    }

    public async Task<MedicamentoResponseDto> CreateAsync(CreateMedicamentoDto dto)
    {
        var medicamento = new Medicamento
        {
            Nombre = dto.Nombre.Trim(),
            Laboratorio = dto.Laboratorio.Trim(),
            Precio = dto.Precio!.Value,
            Stock = dto.Stock!.Value,
            FechaVencimiento = dto.FechaVencimiento!.Value
        };

        var creado = await _repository.CreateAsync(medicamento);
        return ToResponse(creado);
    }

    public async Task<MedicamentoResponseDto?> UpdateAsync(Guid id, UpdateMedicamentoDto dto)
    {
        var medicamento = await _repository.GetByIdAsync(id);
        if (medicamento is null)
            return null;

        if (dto.Nombre is not null) medicamento.Nombre = dto.Nombre.Trim();
        if (dto.Laboratorio is not null) medicamento.Laboratorio = dto.Laboratorio.Trim();
        if (dto.Precio.HasValue) medicamento.Precio = dto.Precio.Value;
        if (dto.Stock.HasValue) medicamento.Stock = dto.Stock.Value;
        if (dto.FechaVencimiento.HasValue) medicamento.FechaVencimiento = dto.FechaVencimiento.Value;

        var actualizado = await _repository.UpdateAsync(medicamento);
        return ToResponse(actualizado);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var medicamento = await _repository.GetByIdAsync(id);
        if (medicamento is null)
            return false;

        await _repository.DeleteAsync(medicamento);
        return true;
    }

    private static MedicamentoResponseDto ToResponse(Medicamento m) => new()
    {
        Id = m.Id,
        Nombre = m.Nombre,
        Laboratorio = m.Laboratorio,
        Precio = m.Precio,
        Stock = m.Stock,
        FechaVencimiento = m.FechaVencimiento
    };
}