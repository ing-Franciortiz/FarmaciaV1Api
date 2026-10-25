using FarmaciaV1Api.Modules.Medicamentos.Repositories;
using FarmaciaV1Api.Modules.Medicamentos.Services;

namespace FarmaciaV1Api.Modules.Medicamentos;

public static class MedicamentosModule
{
    public static IServiceCollection AddMedicamentosModule(this IServiceCollection services)
    {
        services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
        services.AddScoped<IMedicamentoService, MedicamentoService>();

        return services;
    }
}