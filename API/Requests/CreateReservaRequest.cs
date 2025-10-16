namespace API.Requests;

public record CreateReservaRequest(Guid ClienteId, DateOnly FechaReserva, int CantidadCubiertos);
