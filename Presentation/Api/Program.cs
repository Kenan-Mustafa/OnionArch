using Persistence;
using Application;
using Infrastructure;
using Mapper;
using Application.Exceptions;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true);

builder.Services.AddPersistence(builder.Configuration);//Persistence daxilindeki configuration istifade edilir. Connection string fln 
builder.Services.AddApplication(); 
builder.Services.AddCustomMapper();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Youtube API", Version = "v1", Description = "Youtube API swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yaz�p bo�luk b�rakt�ktan sonra Token'� Girebilirsiniz \r\n\r\n �rne�in: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
