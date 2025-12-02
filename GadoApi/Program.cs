using GadoApi.Repositories;
using GadoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGadoRepository, GadoRepository>();
builder.Services.AddScoped<IGadoService, GadoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
