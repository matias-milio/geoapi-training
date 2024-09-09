using GeoApi.Infrastructure.Services.ApiSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExternalAPIsSettings>(builder.Configuration.GetSection("ExternalAPISettings"));
builder.Services.AddSingleton(new RestClient(new RestClientOptions()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
