using CompLab.Api.Contracts.Tests;
using CompLab.Application.Services.Tests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompLab.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/tests")]
public sealed class TestsController : ControllerBase
{
    private readonly ITestService _service;

    public TestsController(ITestService service)
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
        CreateTestRequest request)
    {
        var id = await _service.CreateAsync(
            request.SampleId,
            request.TestType,
            request.MeasurementValue);

        return CreatedAtAction(
            nameof(Get),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTestRequest request)
    {
        await _service.UpdateAsync(
            id,
            request.MeasurementValue);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
