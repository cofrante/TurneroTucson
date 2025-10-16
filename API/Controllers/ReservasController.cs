using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
using API.Responses;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservasController(IReservaService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<Reserva>>>> List([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var pagedResult = await service.ListarReservasAsync(page, pageSize);
        return Ok(pagedResult.ToApiResponse());
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<Reserva>>> Create([FromBody] CreateReservaRequest request)
    {
        var reserva = await service.RegistrarReservaAsync(request.ClienteId, request.FechaReserva, request.CantidadCubiertos);
        if (reserva == null)
            return Ok(new ApiResponse<Reserva>() { Meta = new ApiResponseMetaData { Text = "Se ha puesto en la lista de espera por falta de disponibilidad de mesas" } });

        return Ok(new ApiResponse<Reserva> { Data = reserva });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await service.EliminarReservaAsync(id);
        return NoContent();
    }

    #region Lista de Espera
    [HttpGet("espera")]
    public async Task<ActionResult<ApiResponse<IEnumerable<Espera>>>> ListListaDeEspera([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var pagedResult = await service.ListarClientesEnEsperaAsync(page, pageSize);
        return Ok(pagedResult.ToApiResponse());
    }
    #endregion
}
