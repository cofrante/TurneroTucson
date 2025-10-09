using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservasController(IReservaService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] SearchReservasRequest request)
    {

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearReservaRequest request)
    {

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {

    }

    [HttpGet("ListaDeEspera")]
    public IActionResult GetListaDeEspera([FromQuery] SearchListaEsperaRequest request)
    {

    }


    internal record SearchReservasRequest(int Page, int PageSize);

    internal record CrearReservaRequest(Guid ClienteId, DateOnly FechaReserva);

    internal record SearchListaEsperaRequest(int Page, int PageSize);

}
