using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using proyecto2_so.Services;

namespace proyecto2_so.Controllers;

[ApiController]
[Route("api/traductor")]
public class TraductorController : ControllerBase
{
    private readonly TraductorService traductorService;
    private readonly LogService logService;

    public TraductorController(TraductorService traductorService, LogService logService)
    {
        this.traductorService = traductorService;
        this.logService = logService;
    }

    [HttpGet]
    public ActionResult<string> Get([FromQuery] string origen, [FromQuery] string palabra, [FromQuery] string destino)
    {
        var palabraTraducida = traductorService.TraducirPalabra(origen, palabra, destino);

        logService.Log();

        return palabraTraducida != null
        ? palabraTraducida
        : BadRequest($"La palabra '{palabra}' no se pudo traducir :c");
    }
}
