using Microsoft.Extensions.FileProviders;
using proyecto2_so.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5024");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<DatosService>();
builder.Services.AddTransient<TraductorService>();
builder.Services.AddHostedService<CargarDatos>();
builder.Services.AddSingleton<LogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure static files
var env = app.Environment;

var folder = Path.Combine(env.ContentRootPath, "Files");

if (!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(folder),
    RequestPath = new PathString("/Files")
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
