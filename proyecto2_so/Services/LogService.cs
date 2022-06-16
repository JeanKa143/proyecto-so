using Microsoft.AspNetCore.Http.Extensions;

namespace proyecto2_so.Services;

public class LogService
{
    private readonly IWebHostEnvironment env;
    private readonly IHttpContextAccessor httpContextAccessor;
    private static Mutex mutex = new Mutex();

    public LogService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
        this.env = env;
        this.httpContextAccessor = httpContextAccessor;
    }

    public void Log()
    {
        var id = httpContextAccessor.HttpContext.Connection.Id;
        var url = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
        var method = httpContextAccessor.HttpContext.Request.Method;

        var nuevoHilo = new Thread(() =>
        {
            mutex.WaitOne();
            LogMensaje($"{id}: {url} - {method}");
            mutex.ReleaseMutex();
        });

        nuevoHilo.Start();
    }

    private void LogMensaje(string mensaje)
    {
        var rutaArchivo = $@"{env.ContentRootPath}/Files/log.txt";

        using (var streamWriter = new StreamWriter(rutaArchivo, append: true))
        {
            streamWriter.WriteLine(mensaje);
        }
    }
}