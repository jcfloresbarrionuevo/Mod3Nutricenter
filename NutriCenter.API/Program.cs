using Microsoft.EntityFrameworkCore;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Implementation;
using NutriCenter.Infraestructure.Interfaces;
using NutriCenter.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbNur"));
});

builder.Services.AddHttpClient();

builder.Services.AddScoped<IPlanAlimentarioRepositorio, PlanAlimentarioRepositorio>();
builder.Services.AddScoped<IRecetasRepositorio, RecetasRepositorio>();
builder.Services.AddScoped<ITiempoComidaRepositorio,TiempoComidaRepositorio>();
builder.Services.AddScoped<IPlanRecetaTiempoRepositorio, PlanRecetaTiempoRepositorio>();

// Inyección de Handlers
builder.Services.AddScoped<CrearRecetasCommandHandler>();
builder.Services.AddScoped<ObtenerRecetasQueryHandler>();

builder.Services.AddScoped<CrearTiempoCommandHandler>();
builder.Services.AddScoped<ObtenerTiempoQueryHandler>();

builder.Services.AddScoped<CrearPlanCommandHandler>();
builder.Services.AddScoped<ObtenerPlanQueryHandler>();
//

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options => {
    options.AddPolicy("PoliticaAcceso", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//
app.UseCors("PoliticaAcceso");
//

app.UseAuthorization();

app.MapControllers();

app.Run();
