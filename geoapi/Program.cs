using AutoMapper;
using GeoApi.API.MappingProfiles;
using GeoApi.Application.Contracts;
using GeoApi.Application.Implementations;
using GeoApi.Infrastructure.Services.ApiSettings;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Contracts;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExternalAPIsSettings>(builder.Configuration.GetSection("ExternalAPISettings"));
builder.Services.AddSingleton(new RestClient(new RestClientOptions()));
builder.Services.AddScoped<IGeoLocalizationService,GeoLocalizationService>();
builder.Services.AddScoped<IGoogleMapsApiService, GoogleMapsApiService>();


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
