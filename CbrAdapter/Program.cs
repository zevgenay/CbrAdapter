using CbrAdapter.Database;
using CbrAdapter.Database.Repositories;
using CbrAdapter.Profiles;
using CbrAdapter.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CbrAdapterDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CbrAdapterDatabase")));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(CbrAdapterMappingProfle));

builder.Services.AddScoped<IKeyRateService, KeyRateService>();

builder.Services.AddScoped<IKeyRateRepository, KeyRateRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
