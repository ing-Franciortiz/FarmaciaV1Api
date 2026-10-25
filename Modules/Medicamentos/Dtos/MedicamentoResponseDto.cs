namespace FarmaciaV1Api.Modules.Medicamentos.Dtos;

public class MedicamentoResponseDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Laboratorio { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaVencimiento { get; set; }
}