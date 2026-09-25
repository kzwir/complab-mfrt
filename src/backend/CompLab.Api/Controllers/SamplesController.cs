using CompLab.Api.Contracts.Samples;
using CompLab.Application.Services.Samples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompLab.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/samples")]
public sealed class SamplesController : ControllerBase
{
    private readonly ISampleService _service;

    public SamplesController(ISampleService service)
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
        CreateSampleRequest request)
    {
        var id = await _service.CreateAsync(
            request.MixtureId,
            request.SampleNumber,
            request.ProductionDate);

        return CreatedAtAction(
            nameof(Get),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateSampleRequest request)
    {
        await _service.UpdateAsync(
            id,
            request.SampleNumber);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
