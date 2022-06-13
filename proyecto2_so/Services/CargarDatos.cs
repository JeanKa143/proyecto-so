using System.Text.Json;
using proyecto2_so.Classes;

namespace proyecto2_so.Services;

public class CargarDatos : IHostedService
{
    private readonly IWebHostEnvironment env;
    private readonly DatosService datosService;
    private readonly string carpeta = "Data";

    public CargarDatos(IWebHostEnvironment env, DatosService datosService)
    {
        this.env = env;
        this.datosService = datosService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        LeerDatos();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void LeerDatos()
    { //Carga los datos contenidos en los archivos .json de la carpeta Data en memoria
        var datosIdioma = new Dictionary<string, string>(){
            {"en","animalesEn"}, {"es","animalesEs"}, {"fr","animalesFr"}
        };

        foreach (var item in datosIdioma)
        {
            var ruta = $@"{env.ContentRootPath}/{carpeta}/{item.Value}.json";
            var datosJSON = File.ReadAllText(ruta);

            var animales = JsonSerializer.Deserialize<List<Animal>>(datosJSON);
            datosService.AgregarAnimales(item.Key, animales);
        }
    }
}
