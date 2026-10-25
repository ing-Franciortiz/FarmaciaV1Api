namespace FarmaciaV1Api.Modules.Medicamentos.Entities;

public class Medicamento
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public string Laboratorio { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaVencimiento { get; set; }
}