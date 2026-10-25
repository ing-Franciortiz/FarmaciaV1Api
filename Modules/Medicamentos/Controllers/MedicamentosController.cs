using FarmaciaV1Api.Modules.Medicamentos.Dtos;
using FarmaciaV1Api.Modules.Medicamentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaV1Api.Modules.Medicamentos.Controllers;

[ApiController]
[Route("medicamentos")]
public class MedicamentosController : ControllerBase
{
    private readonly IMedicamentoService _service;

    public MedicamentosController(IMedicamentoService service)
    {
        _service = service;
    }

    // GET /medicamentos -> 200
    [HttpGet]
    public async Task<ActionResult<List<MedicamentoResponseDto>>> GetAll()
    {
        var medicamentos = await _service.GetAllAsync();
        return Ok(medicamentos);
    }

    // GET /medicamentos/{id} -> 200 | 404
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MedicamentoResponseDto>> GetById(Guid id)
    {
        var medicamento = await _service.GetByIdAsync(id);
        if (medicamento is null)
            return NotFound(new { message = $"No existe un medicamento con el id {id}." });

        return Ok(medicamento);
    }

    // POST /medicamentos -> 201 | 400
    [HttpPost]
    public async Task<ActionResult<MedicamentoResponseDto>> Create(CreateMedicamentoDto dto)
    {
        var creado = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    // PATCH /medicamentos/{id} -> 200 | 400 | 404
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<MedicamentoResponseDto>> Update(Guid id, UpdateMedicamentoDto dto)
    {
        var actualizado = await _service.UpdateAsync(id, dto);
        if (actualizado is null)
            return NotFound(new { message = $"No existe un medicamento con el id {id}." });

        return Ok(actualizado);
    }

    // DELETE /medicamentos/{id} -> 200 | 404
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var eliminado = await _service.DeleteAsync(id);
        if (!eliminado)
            return NotFound(new { message = $"No existe un medicamento con el id {id}." });

        return Ok(new { message = "Medicamento eliminado correctamente." });
    }
}