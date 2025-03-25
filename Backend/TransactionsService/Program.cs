using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using TransactionsService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger y CORS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // URL del frontend
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configurar HttpClient para conectarse con el servicio de productos
builder.Services.AddHttpClient("ProductService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5184/api/Products"); // Asegúrate de que es la URL correcta
});

// Configuración de localización
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = new[] { new CultureInfo("en-US") };
    options.SupportedUICultures = new[] { new CultureInfo("en-US") };
});

// Añadir controladores
builder.Services.AddControllers();

// Configuración de Entity Framework con SQL Server
builder.Services.AddDbContext<TransactionsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Verifica la conexión en appsettings.json

// Configurar Kestrel para escuchar en el puerto 5200
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5200);
});

var app = builder.Build();

// Middleware de CORS
app.UseCors("AllowLocalhost");

// Middleware de localización
app.UseRequestLocalization();

// Configuración de Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de seguridad y autorización
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();
