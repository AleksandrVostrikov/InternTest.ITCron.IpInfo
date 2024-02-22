using InternTest.ITCron.IpInfo.Application.Services;
using InternTest.ITCron.IpInfo.DataAcces;
using InternTest.ITCron.IpInfo.DataAcces.Repositories;
using InternTest.ITCron.IpInfo.Domain;
using InternTest.ITCron.IpInfo.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RsponseDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("IpInfoConnectionString")));

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenIP"));

builder.Services.AddScoped<IResponsesRepository, ResponsesRepository>();
builder.Services.AddScoped<IResponseService, ResponseService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
