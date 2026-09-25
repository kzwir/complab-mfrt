using CompLab.Api.Contracts.Mixtures;
using CompLab.Application.Services.Mixtures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompLab.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/mixtures")]
public sealed class MixturesController : ControllerBase
{
    private readonly IMixtureService _service;

    public MixturesController(IMixtureService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMixtureRequest request)
    {
        var id = await _service.CreateAsync(
            request.Code,
            request.PolymerPercent,
            request.QuartzitePercent);

        return CreatedAtAction(
            nameof(Get),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateMixtureRequest request)
    {
        await _service.UpdateAsync(
            id,
            request.PolymerPercent,
            request.QuartzitePercent);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
