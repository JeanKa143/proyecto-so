namespace proyecto2_so.Services;

public class TraductorService
{
    private readonly DatosService datosService;

    public TraductorService(DatosService datosService)
    {
        this.datosService = datosService;
    }

    public string TraducirPalabra(string idiomaOrigen, string palabra, string idiomaDestino)
    {
        var palabraId = datosService.ObtenerAnimalPorNombre(idiomaOrigen, palabra)?.Id;

        return palabraId != null
        ? datosService.ObtenerAnimalPorId(idiomaDestino, (int)palabraId)?.Nombre
        : null;
    }
}
