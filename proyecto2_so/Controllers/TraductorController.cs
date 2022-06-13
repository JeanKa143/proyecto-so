using Microsoft.AspNetCore.Mvc;
using proyecto2_so.Services;

namespace proyecto2_so.Controllers;

[ApiController]
[Route("api/traductor")]
public class TraductorController : ControllerBase
{
    private readonly TraductorService traductorService;

    public TraductorController(TraductorService traductorService)
    {
        this.traductorService = traductorService;
    }

    [HttpGet]
    public ActionResult<string> Get([FromQuery] string origen, [FromQuery] string palabra, [FromQuery] string destino)
    {
        var palabraTraducida = traductorService.TraducirPalabra(origen,palabra,destino);

        return palabraTraducida != null
        ? palabraTraducida
        : BadRequest($"La palabra '{palabra}' no se pudo traducir :c");
    }
}
