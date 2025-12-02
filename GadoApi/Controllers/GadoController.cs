using GadoApi.Models;
using GadoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GadoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GadoController : ControllerBase
{
    private readonly IGadoService _service;

    public GadoController(IGadoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var gado = _service.GetById(id);
        return gado is null ? NotFound() : Ok(gado);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Gado gado)
    {
        var created = _service.Create(gado);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Gado gado)
    {
        if (!_service.Update(id, gado))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_service.Delete(id))
            return NotFound();

        return NoContent();
    }
}
