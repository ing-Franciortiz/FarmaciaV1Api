using System.ComponentModel.DataAnnotations;

namespace FarmaciaV1Api.Modules.Medicamentos.Dtos;

public class UpdateMedicamentoDto
{
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string? Nombre { get; set; }

    [StringLength(100, MinimumLength = 2, ErrorMessage = "El laboratorio debe tener entre 2 y 100 caracteres.")]
    public string? Laboratorio { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal? Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int? Stock { get; set; }

    public DateTime? FechaVencimiento { get; set; }
}