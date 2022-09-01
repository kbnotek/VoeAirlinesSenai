using DinkToPdf;
using DinkToPdf.Contracts;
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Injeção de dependência abaixo - BRQ
builder.Services.AddDbContext<VoeAirlinesContext>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<ManutencaoService>();
builder.Services.AddTransient<VooService>();
builder.Services.AddTransient<CancelamentoService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
