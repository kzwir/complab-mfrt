using CompLab.Application.DTOs.Dashboard;

namespace CompLab.Application.Services.Dashboard;

public interface IDashboardService
{
    Task<DashboardDto> GetAsync();
}
