using System.ComponentModel.DataAnnotations;

namespace FarmaciaV1Api.Modules.Medicamentos.Dtos;

public class CreateMedicamentoDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El laboratorio es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El laboratorio debe tener entre 2 y 100 caracteres.")]
    public string Laboratorio { get; set; } = string.Empty;

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal? Precio { get; set; }

    [Required(ErrorMessage = "El stock es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int? Stock { get; set; }

    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
    public DateTime? FechaVencimiento { get; set; }
}